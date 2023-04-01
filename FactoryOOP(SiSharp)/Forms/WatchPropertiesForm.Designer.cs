namespace FactoryOOP_SiSharp_.Forms
{
    partial class WatchPropertiesForm
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
            this.lblProcessor = new System.Windows.Forms.Label();
            this.lblCPUMicroarchitecture = new System.Windows.Forms.Label();
            this.txtbxCPUMicroarchitecture = new System.Windows.Forms.TextBox();
            this.lblClockFrequency = new System.Windows.Forms.Label();
            this.txtbxClockFrequency = new System.Windows.Forms.TextBox();
            this.chkbxNFC = new System.Windows.Forms.CheckBox();
            this.lblInterface = new System.Windows.Forms.Label();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.chkbxFrontLightning = new System.Windows.Forms.CheckBox();
            this.chkbxBloodPressure = new System.Windows.Forms.CheckBox();
            this.chkbxECGSensor = new System.Windows.Forms.CheckBox();
            this.lblBluetooth = new System.Windows.Forms.Label();
            this.txtbxBluetooth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblProcessor
            // 
            this.lblProcessor.AutoSize = true;
            this.lblProcessor.Location = new System.Drawing.Point(24, 34);
            this.lblProcessor.Name = "lblProcessor";
            this.lblProcessor.Size = new System.Drawing.Size(57, 13);
            this.lblProcessor.TabIndex = 10;
            this.lblProcessor.Text = "Processor:";
            // 
            // lblCPUMicroarchitecture
            // 
            this.lblCPUMicroarchitecture.AutoSize = true;
            this.lblCPUMicroarchitecture.Location = new System.Drawing.Point(35, 68);
            this.lblCPUMicroarchitecture.Name = "lblCPUMicroarchitecture";
            this.lblCPUMicroarchitecture.Size = new System.Drawing.Size(114, 13);
            this.lblCPUMicroarchitecture.TabIndex = 13;
            this.lblCPUMicroarchitecture.Text = "CPU Microarchitecture";
            // 
            // txtbxCPUMicroarchitecture
            // 
            this.txtbxCPUMicroarchitecture.Location = new System.Drawing.Point(155, 65);
            this.txtbxCPUMicroarchitecture.Name = "txtbxCPUMicroarchitecture";
            this.txtbxCPUMicroarchitecture.Size = new System.Drawing.Size(100, 20);
            this.txtbxCPUMicroarchitecture.TabIndex = 12;
            // 
            // lblClockFrequency
            // 
            this.lblClockFrequency.AutoSize = true;
            this.lblClockFrequency.Location = new System.Drawing.Point(35, 103);
            this.lblClockFrequency.Name = "lblClockFrequency";
            this.lblClockFrequency.Size = new System.Drawing.Size(104, 13);
            this.lblClockFrequency.TabIndex = 17;
            this.lblClockFrequency.Text = "Clock frequency (hz)";
            // 
            // txtbxClockFrequency
            // 
            this.txtbxClockFrequency.Location = new System.Drawing.Point(145, 100);
            this.txtbxClockFrequency.Name = "txtbxClockFrequency";
            this.txtbxClockFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtbxClockFrequency.TabIndex = 16;
            // 
            // chkbxNFC
            // 
            this.chkbxNFC.AutoSize = true;
            this.chkbxNFC.Location = new System.Drawing.Point(38, 205);
            this.chkbxNFC.Name = "chkbxNFC";
            this.chkbxNFC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbxNFC.Size = new System.Drawing.Size(47, 17);
            this.chkbxNFC.TabIndex = 27;
            this.chkbxNFC.Text = "NFC";
            this.chkbxNFC.UseVisualStyleBackColor = true;
            // 
            // lblInterface
            // 
            this.lblInterface.AutoSize = true;
            this.lblInterface.Location = new System.Drawing.Point(24, 174);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(52, 13);
            this.lblInterface.TabIndex = 29;
            this.lblInterface.Text = "Interface:";
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(245, 262);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 30;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // chkbxFrontLightning
            // 
            this.chkbxFrontLightning.AutoSize = true;
            this.chkbxFrontLightning.Location = new System.Drawing.Point(398, 123);
            this.chkbxFrontLightning.Name = "chkbxFrontLightning";
            this.chkbxFrontLightning.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbxFrontLightning.Size = new System.Drawing.Size(92, 17);
            this.chkbxFrontLightning.TabIndex = 38;
            this.chkbxFrontLightning.Text = "Front lightning";
            this.chkbxFrontLightning.UseVisualStyleBackColor = true;
            // 
            // chkbxBloodPressure
            // 
            this.chkbxBloodPressure.AutoSize = true;
            this.chkbxBloodPressure.Location = new System.Drawing.Point(316, 89);
            this.chkbxBloodPressure.Name = "chkbxBloodPressure";
            this.chkbxBloodPressure.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbxBloodPressure.Size = new System.Drawing.Size(174, 17);
            this.chkbxBloodPressure.TabIndex = 37;
            this.chkbxBloodPressure.Text = "Measurement of blood pressure";
            this.chkbxBloodPressure.UseVisualStyleBackColor = true;
            // 
            // chkbxECGSensor
            // 
            this.chkbxECGSensor.AutoSize = true;
            this.chkbxECGSensor.Location = new System.Drawing.Point(409, 55);
            this.chkbxECGSensor.Name = "chkbxECGSensor";
            this.chkbxECGSensor.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbxECGSensor.Size = new System.Drawing.Size(81, 17);
            this.chkbxECGSensor.TabIndex = 36;
            this.chkbxECGSensor.Text = "ECGSensor";
            this.chkbxECGSensor.UseVisualStyleBackColor = true;
            // 
            // lblBluetooth
            // 
            this.lblBluetooth.AutoSize = true;
            this.lblBluetooth.Location = new System.Drawing.Point(12, 240);
            this.lblBluetooth.Name = "lblBluetooth";
            this.lblBluetooth.Size = new System.Drawing.Size(52, 13);
            this.lblBluetooth.TabIndex = 62;
            this.lblBluetooth.Text = "Bluetooth";
            // 
            // txtbxBluetooth
            // 
            this.txtbxBluetooth.Location = new System.Drawing.Point(70, 237);
            this.txtbxBluetooth.Name = "txtbxBluetooth";
            this.txtbxBluetooth.Size = new System.Drawing.Size(100, 20);
            this.txtbxBluetooth.TabIndex = 61;
            // 
            // WatchPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 313);
            this.Controls.Add(this.lblBluetooth);
            this.Controls.Add(this.txtbxBluetooth);
            this.Controls.Add(this.chkbxFrontLightning);
            this.Controls.Add(this.chkbxBloodPressure);
            this.Controls.Add(this.chkbxECGSensor);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblInterface);
            this.Controls.Add(this.chkbxNFC);
            this.Controls.Add(this.lblClockFrequency);
            this.Controls.Add(this.txtbxClockFrequency);
            this.Controls.Add(this.lblCPUMicroarchitecture);
            this.Controls.Add(this.txtbxCPUMicroarchitecture);
            this.Controls.Add(this.lblProcessor);
            this.Name = "WatchPropertiesForm";
            this.Text = "Digital watchess properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblProcessor;
        private System.Windows.Forms.Label lblCPUMicroarchitecture;
        private System.Windows.Forms.TextBox txtbxCPUMicroarchitecture;
        private System.Windows.Forms.Label lblClockFrequency;
        private System.Windows.Forms.TextBox txtbxClockFrequency;
        private System.Windows.Forms.CheckBox chkbxNFC;
        private System.Windows.Forms.Label lblInterface;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.CheckBox chkbxFrontLightning;
        private System.Windows.Forms.CheckBox chkbxBloodPressure;
        private System.Windows.Forms.CheckBox chkbxECGSensor;
        private System.Windows.Forms.Label lblBluetooth;
        private System.Windows.Forms.TextBox txtbxBluetooth;
    }
}