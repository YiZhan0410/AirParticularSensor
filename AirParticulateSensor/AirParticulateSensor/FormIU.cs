using System;
using System.Threading;
using System.Windows.Forms;

namespace AirParticulateSensor
{
    public partial class FormIU : Form, IUserInterface
    {
        public ILocationFileReader IOhandler { get; }
        private ConfigData configData;
        private LocationList locationList;

        public FormIU(ILocationFileReader IOhandler)
        {
            InitializeComponent();
            this.IOhandler = IOhandler;
        }

        public void SetupConfigData()
        {
            // Create object for ConfigData
            configData = new ConfigData();

            // Generate configuration data from bin/Debug folder of the project
            configData.configRecords.Add(new ConfigRecord("Particulates-01.xml"));
            configData.configRecords.Add(new ConfigRecord("Particulates-02.xml"));
            configData.configRecords.Add(new ConfigRecord("Particulates-03.xml"));
            configData.configRecords.Add(new ConfigRecord("Particulates-04.xml"));
            configData.configRecords.Add(new ConfigRecord("Particulates-05.xml"));
            configData.configRecords.Add(new ConfigRecord("Particulates-06.xml"));
        }

        public void RunProducerConsumer()
        {
            // Create location list
            locationList = new LocationList();

            // Create progress manager
            var progManager = new ProgressManager(configData.configRecords.Count);

            // Create PCQueue with a capacity of 4
            var pcQueue = new PCQueue(4);
            
            // Create 2 Producers and 2 Consumers and they can execute threads respectively
            Producer[] producers = {new Producer("P1", pcQueue, configData, IOhandler),
                                    new Producer("P2", pcQueue, configData,IOhandler)};

            Consumer[] consumers = {new Consumer("C1", pcQueue, locationList, progManager),
                                    new Consumer("C2", pcQueue, locationList, progManager)};

            // Keep produce and consume until work items completed
            while (progManager.ItemsRemaining > 0) ;

            // Deactivate the PCQueue to provent waiting producer or consumer thread
            pcQueue.Active = false;

            // Iterate through consumers and signal them to finish
            foreach (var c in consumers)
            {
                c.Finished = true;
            }

            // Wait until consumers to finish
            while (Consumer.RunningThreads > 0)
            {
                lock(pcQueue)
                {
                    // Pulse PCQueue to signal waiting threads
                    Monitor.Pulse(pcQueue);
                }
            }

            // Iterate through producers and signal them to finish
            foreach (var p in producers)
            {
                p.Finished = true;
            }

            // Wait producers to finish
            while (Producer.RunningThreads > 0)
            {
                lock(pcQueue)
                {
                    // Pulse PCQueue to signal waiting threads
                    Monitor.Pulse(pcQueue);
                }
            }
        }

        private void BtnCreateConfig_Click(object sender, EventArgs e)
        {
            // Clear items in the listbox
            lstLocation.Items.Clear();

            SetupConfigData();

            // Update form object properties
            lblResult.Text = "Config data loaded. Waiting for user to press load";
            btnLoad.Enabled = true;
            btnLocations.Enabled = false;
            btnDates.Enabled = false;
            btnLargestParticulates.Enabled = false;
            btnLocationReadings.Enabled = false;
            btnCreateConfig.Enabled = false;
        }

        private void BtnLoad_Click(object sender, EventArgs e)
        {
            // Clear items in the listbox
            lstLocation.Items.Clear();

            lblResult.Text = "Running producer/consumer queue";
            lblResult.Refresh();

            // Run producer/consumer queue to load location data
            RunProducerConsumer();

            // Update form object properties
            lblResult.Text = "Readings loaded";
            btnLocations.Enabled = true;
            btnDates.Enabled = true;
            btnLargestParticulates.Enabled = true;
            btnLocationReadings.Enabled = true;
            btnLoad.Enabled = false;
        }

        private void BtnLocations_Click(object sender, EventArgs e)
        {
            lstLocation.Items.Clear();
            lstReading.Items.Clear();
            DisplayLocations();
            DisplayDatesOnly();
        }

        public void DisplayLocations()
        {
            foreach (var location in locationList.DisplayLocationAscending())
            {
                lstLocation.Items.Add(location);
                lstLocation.Items.Add("");
            }
        }

        public void DisplayDates()
        {

            foreach (var l in locationList.DisplayDates())
            {
                lstReading.Items.Add(l);
            }
        }

        public void DisplayLargestParticulates()
        {
            foreach (var location in locationList.DisplayLargest())
            {
                lstReading.Items.Add(location);
            }
        }

        private void BtnDates_Click(object sender, EventArgs e)
        {
            lstLocation.Items.Clear();
            lstReading.Items.Clear();
            DisplayDates();
        }

        private void BtnLargestParticulates_Click(object sender, EventArgs e)
        {
            lstLocation.Items.Clear();
            lstReading.Items.Clear();
            DisplayLargestParticulates();
        }

        private void lstLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayLocationReadings();
        }

        public void DisplayLocationReadings()
        {
            lstReading.Items.Clear();

            var location = (Location)lstLocation.SelectedItem;

            // Having finished generating data and display location data on form
            foreach (var l in location.Readings)
            {
                lstReading.Items.Add(l);
            }
        }

        private void btnLocationReadings_Click(object sender, EventArgs e)
        {
            lstLocation.Items.Clear();
            lstReading.Items.Clear();

            foreach (var l in locationList.Locations)
            {
                lstLocation.Items.Add(l);
            }
        }

        public void DisplayDatesOnly()
        {

            foreach (var l in locationList.DisplayDatesOnly())
            {
                lstReading.Items.Add(l);
            }
        }
    }
}
