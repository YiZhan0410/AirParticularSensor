namespace AirParticulateSensor
{
    partial class FormIU
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCreateConfig = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnLocations = new System.Windows.Forms.Button();
            this.btnDates = new System.Windows.Forms.Button();
            this.btnLargestParticulates = new System.Windows.Forms.Button();
            this.btnLocationReadings = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.lstLocation = new System.Windows.Forms.ListBox();
            this.lstReading = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCreateConfig
            // 
            this.btnCreateConfig.Location = new System.Drawing.Point(38, 119);
            this.btnCreateConfig.Name = "btnCreateConfig";
            this.btnCreateConfig.Size = new System.Drawing.Size(177, 85);
            this.btnCreateConfig.TabIndex = 0;
            this.btnCreateConfig.Text = "Create Config Data";
            this.btnCreateConfig.UseVisualStyleBackColor = true;
            this.btnCreateConfig.Click += new System.EventHandler(this.BtnCreateConfig_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Enabled = false;
            this.btnLoad.Location = new System.Drawing.Point(38, 278);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(177, 85);
            this.btnLoad.TabIndex = 1;
            this.btnLoad.Text = "Load Particulate Data";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.BtnLoad_Click);
            // 
            // btnLocations
            // 
            this.btnLocations.Enabled = false;
            this.btnLocations.Location = new System.Drawing.Point(574, 561);
            this.btnLocations.Name = "btnLocations";
            this.btnLocations.Size = new System.Drawing.Size(194, 91);
            this.btnLocations.TabIndex = 2;
            this.btnLocations.Text = "Display Locations Alphabetically";
            this.btnLocations.UseVisualStyleBackColor = true;
            this.btnLocations.Click += new System.EventHandler(this.BtnLocations_Click);
            // 
            // btnDates
            // 
            this.btnDates.Enabled = false;
            this.btnDates.Location = new System.Drawing.Point(835, 561);
            this.btnDates.Name = "btnDates";
            this.btnDates.Size = new System.Drawing.Size(194, 91);
            this.btnDates.TabIndex = 3;
            this.btnDates.Text = "Display Dates";
            this.btnDates.UseVisualStyleBackColor = true;
            this.btnDates.Click += new System.EventHandler(this.BtnDates_Click);
            // 
            // btnLargestParticulates
            // 
            this.btnLargestParticulates.Enabled = false;
            this.btnLargestParticulates.Location = new System.Drawing.Point(1099, 561);
            this.btnLargestParticulates.Name = "btnLargestParticulates";
            this.btnLargestParticulates.Size = new System.Drawing.Size(194, 91);
            this.btnLargestParticulates.TabIndex = 4;
            this.btnLargestParticulates.Text = "Display Largest Particulates";
            this.btnLargestParticulates.UseVisualStyleBackColor = true;
            this.btnLargestParticulates.Click += new System.EventHandler(this.BtnLargestParticulates_Click);
            // 
            // btnLocationReadings
            // 
            this.btnLocationReadings.Enabled = false;
            this.btnLocationReadings.Location = new System.Drawing.Point(324, 561);
            this.btnLocationReadings.Name = "btnLocationReadings";
            this.btnLocationReadings.Size = new System.Drawing.Size(194, 91);
            this.btnLocationReadings.TabIndex = 5;
            this.btnLocationReadings.Text = "Display Location Readings";
            this.btnLocationReadings.UseVisualStyleBackColor = true;
            this.btnLocationReadings.Click += new System.EventHandler(this.btnLocationReadings_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(319, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(79, 25);
            this.lblStatus.TabIndex = 6;
            this.lblStatus.Text = "Status:";
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(404, 60);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(144, 25);
            this.lblResult.TabIndex = 7;
            this.lblResult.Text = "Awaiting Data";
            // 
            // lstLocation
            // 
            this.lstLocation.FormattingEnabled = true;
            this.lstLocation.ItemHeight = 25;
            this.lstLocation.Location = new System.Drawing.Point(324, 119);
            this.lstLocation.Name = "lstLocation";
            this.lstLocation.Size = new System.Drawing.Size(356, 404);
            this.lstLocation.TabIndex = 8;
            this.lstLocation.SelectedIndexChanged += new System.EventHandler(this.lstLocation_SelectedIndexChanged);
            // 
            // lstReading
            // 
            this.lstReading.FormattingEnabled = true;
            this.lstReading.ItemHeight = 25;
            this.lstReading.Location = new System.Drawing.Point(756, 119);
            this.lstReading.Name = "lstReading";
            this.lstReading.Size = new System.Drawing.Size(537, 404);
            this.lstReading.TabIndex = 10;
            // 
            // FormIU
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1414, 734);
            this.Controls.Add(this.lstReading);
            this.Controls.Add(this.lstLocation);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnLocationReadings);
            this.Controls.Add(this.btnLargestParticulates);
            this.Controls.Add(this.btnDates);
            this.Controls.Add(this.btnLocations);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnCreateConfig);
            this.Name = "FormIU";
            this.Text = "Air Particulate Sensor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCreateConfig;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnLocations;
        private System.Windows.Forms.Button btnDates;
        private System.Windows.Forms.Button btnLargestParticulates;
        private System.Windows.Forms.Button btnLocationReadings;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.ListBox lstLocation;
        private System.Windows.Forms.ListBox lstReading;
    }
}

