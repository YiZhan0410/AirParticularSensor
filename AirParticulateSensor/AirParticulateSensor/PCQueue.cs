using System;
using System.Collections.Generic;
using System.Threading;

namespace AirParticulateSensor
{
    public class PCQueue
    {
        private Queue<Work> queue = new Queue<Work>(); // Embedded queue collection to hold work items
        public int Capacity { get;} // Maximum number of work items allowed on the queue
        public bool Active { get; set; } // Only allows enqueue and dequeue of work items

        public PCQueue()
        {
            // Defaults to an unbounded queue size and capacity equals to 0
            Capacity = 0;
            Active = true;
        }


        public PCQueue(int capacity)
        {
            // Sets a bounded queue size = capacity
            this.Capacity = Math.Max(capacity, 0); // negative capacity not allowed
            Active = true;
        }

        public void enqueueItem(Work item)
        {
            lock(this)
            {
                // Use this instance of the PCQueue as the locking obkcet for the concurrency related critical regions
                // and thread synchronisation
                while(Active && (Capacity != 0) && (queue.Count == Capacity))
                {
                    // While this PCQueue is active and full, wait (remember a capactiy = 0 means never full)
                    Monitor.Wait(this);
                }

                // If this PCQueue is active it now has space for a work item so enqueue it
                if(Active)
                {
                    queue.Enqueue(item);

                    // us e pulse to inform that the queue is now not empty
                    Monitor.Pulse(this);
                }
            }
        }

        public Work dequeueItem()
        {
            // Use this instance of the PCQueue as the locking object for the concurrency realted critical regions
            // and thread synchronisation
            Work item = null;

            lock(this)
            {
                // while this PCQueue is active and empty, wait
                while(Active && (queue.Count == 0))
                {
                    Monitor.Wait(this);
                }

                // If this PCQueue is active it now has a work item so dequeue a work item and return its reference
                // or return null if the PCQueue is not active
                if(Active)
                {
                    item = queue.Dequeue();

                    // Use pulse to inform that thr queue is now not full
                    Monitor.Pulse(this);
                }

            }

            return item;

        }
    }
}
