using System;
using System.Threading;

namespace AirParticulateSensor
{
    // The Consumer class runs on its own thread and continues to run until instructed to finish
    class Consumer
    {
        private static int runningThreads = 0; // Class wide count of consumer threads that are running
        private static object locker = new object(); // Used for MUTEX contril of static properties

        private string id; // Consumer's identifier

        public Thread T { get; }// Thread upon which this instance of a consumer runs
        private bool finished; // Flag to contril if this consumer has finished or if it should continue to consume
        private PCQueue pcQueue; // Shared PCQueue that this consumer is consuming work items from

        private int duration = 100000000; // Increase or decrease thsi value to slow down or speed up the consumer

        private LocationList locationList; // List of reading which will be added to

        private ProgressManager progManager;

        public static int RunningThreads // Property getter/setter methods
        {
            get
            {
                lock(locker)
                {
                    return runningThreads;
                }
            }

            private set
            {
                lock(locker)
                {
                    // MUTEX control for potential multiple thread access to this property
                    runningThreads = value;
                }
            }
        }

        public bool Finished // Property getter/setter methods
        {
            get
            {
                lock(locker)
                {
                    // MUTEX control for potential multiple thread access to the finished flag
                    return finished;
                }
            }

            set
            {
                lock(locker)
                {
                    finished = value;
                }
            }
        }

        public Consumer(string id, PCQueue pcQueue, LocationList locationList, ProgressManager progManager)
        {
            this.id = id;  // Initially not finished
            finished = false;
            this.pcQueue = pcQueue;
            this.locationList = locationList;
            this.progManager = progManager;

            T = new Thread(run); // Create a new thread for consumer
            T.Start(); // Get it started

            RunningThreads++; // Increment the number of running consumer threads
        }

        public void run()
        {
            // Dequeue a work item form PCQueue and consume the work item while not finished
            while(!Finished)
            {
                // Dequeue work item
                var item = pcQueue.dequeueItem();

                if(!ReferenceEquals(null, item))
                {
                    // Invoke the work item's ReadData() method
                    Location location = item.ReadData();

                    // Ensure null returns are ignored
                    if(!ReferenceEquals(null, location))
                    {
                        // Add this location to the location list
                        lock (locationList)
                        {
                            locationList.Locations.Add(location);
                        }

                        // Output to the console
                        Console.WriteLine("Consumer:{0} has consumed Work Item:{1}", id, item.configRecord.ToString());
                    }
                    else
                    {
                        // Output to the console
                        Console.WriteLine("Consumer:{0} has rejected Work Item {1}", id, item.configRecord.ToString());
                    }

                    // Simulate long running consumer activity
                    for (int i = 0; i < duration; i++)
                    {
                        Math.Sqrt(i);
                    }

                    // Update Progress Manager to indicate that one more piece of data has been consumed
                    progManager.ItemsRemaining--;
                }
            }

            // Decrement for the running consumer threads
            RunningThreads--;

            // Output to the console that consumer has finished
            Console.WriteLine("Consumer:{0} has finished", id);
        }
    }
}
