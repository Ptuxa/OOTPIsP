namespace FactoryOOP_SiSharp_.Forms
{
    partial class LaptopPropertiesForm
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
            this.lblClockFrequency = new System.Windows.Forms.Label();
            this.txtbxClockFrequency = new System.Windows.Forms.TextBox();
            this.lblCPUMicroarchitecture = new System.Windows.Forms.Label();
            this.txtbxCPUMicroarchitecture = new System.Windows.Forms.TextBox();
            this.lblProcessor = new System.Windows.Forms.Label();
            this.lblInterface = new System.Windows.Forms.Label();
            this.chkbxNFC = new System.Windows.Forms.CheckBox();
            this.lblConnectionConnector = new System.Windows.Forms.Label();
            this.txtbxMaximumUSBTransferRate = new System.Windows.Forms.TextBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblBatteryAutonomy = new System.Windows.Forms.Label();
            this.txtbxBatteryAutonomy = new System.Windows.Forms.TextBox();
            this.lblBluetooth = new System.Windows.Forms.Label();
            this.txtbxBluetooth = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblClockFrequency
            // 
            this.lblClockFrequency.AutoSize = true;
            this.lblClockFrequency.Location = new System.Drawing.Point(36, 108);
            this.lblClockFrequency.Name = "lblClockFrequency";
            this.lblClockFrequency.Size = new System.Drawing.Size(104, 13);
            this.lblClockFrequency.TabIndex = 22;
            this.lblClockFrequency.Text = "Clock frequency (hz)";
            // 
            // txtbxClockFrequency
            // 
            this.txtbxClockFrequency.Location = new System.Drawing.Point(146, 105);
            this.txtbxClockFrequency.Name = "txtbxClockFrequency";
            this.txtbxClockFrequency.Size = new System.Drawing.Size(100, 20);
            this.txtbxClockFrequency.TabIndex = 21;
            // 
            // lblCPUMicroarchitecture
            // 
            this.lblCPUMicroarchitecture.AutoSize = true;
            this.lblCPUMicroarchitecture.Location = new System.Drawing.Point(36, 73);
            this.lblCPUMicroarchitecture.Name = "lblCPUMicroarchitecture";
            this.lblCPUMicroarchitecture.Size = new System.Drawing.Size(114, 13);
            this.lblCPUMicroarchitecture.TabIndex = 20;
            this.lblCPUMicroarchitecture.Text = "CPU Microarchitecture";
            // 
            // txtbxCPUMicroarchitecture
            // 
            this.txtbxCPUMicroarchitecture.Location = new System.Drawing.Point(156, 70);
            this.txtbxCPUMicroarchitecture.Name = "txtbxCPUMicroarchitecture";
            this.txtbxCPUMicroarchitecture.Size = new System.Drawing.Size(100, 20);
            this.txtbxCPUMicroarchitecture.TabIndex = 19;
            // 
            // lblProcessor
            // 
            this.lblProcessor.AutoSize = true;
            this.lblProcessor.Location = new System.Drawing.Point(25, 39);
            this.lblProcessor.Name = "lblProcessor";
            this.lblProcessor.Size = new System.Drawing.Size(57, 13);
            this.lblProcessor.TabIndex = 18;
            this.lblProcessor.Text = "Processor:";
            // 
            // lblInterface
            // 
            this.lblInterface.AutoSize = true;
            this.lblInterface.Location = new System.Drawing.Point(25, 159);
            this.lblInterface.Name = "lblInterface";
            this.lblInterface.Size = new System.Drawing.Size(52, 13);
            this.lblInterface.TabIndex = 35;
            this.lblInterface.Text = "Interface:";
            // 
            // chkbxNFC
            // 
            this.chkbxNFC.AutoSize = true;
            this.chkbxNFC.Location = new System.Drawing.Point(39, 190);
            this.chkbxNFC.Name = "chkbxNFC";
            this.chkbxNFC.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkbxNFC.Size = new System.Drawing.Size(47, 17);
            this.chkbxNFC.TabIndex = 33;
            this.chkbxNFC.Text = "NFC";
            this.chkbxNFC.UseVisualStyleBackColor = true;
            // 
            // lblConnectionConnector
            // 
            this.lblConnectionConnector.AutoSize = true;
            this.lblConnectionConnector.Location = new System.Drawing.Point(323, 105);
            this.lblConnectionConnector.Name = "lblConnectionConnector";
            this.lblConnectionConnector.Size = new System.Drawing.Size(176, 13);
            this.lblConnectionConnector.TabIndex = 46;
            this.lblConnectionConnector.Text = "Maximum USB TransferRate (MB/s)";
            // 
            // txtbxMaximumUSBTransferRate
            // 
            this.txtbxMaximumUSBTransferRate.Location = new System.Drawing.Point(505, 101);
            this.txtbxMaximumUSBTransferRate.Name = "txtbxMaximumUSBTransferRate";
            this.txtbxMaximumUSBTransferRate.Size = new System.Drawing.Size(100, 20);
            this.txtbxMaximumUSBTransferRate.TabIndex = 45;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(238, 278);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 47;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblBatteryAutonomy
            // 
            this.lblBatteryAutonomy.AutoSize = true;
            this.lblBatteryAutonomy.Location = new System.Drawing.Point(323, 70);
            this.lblBatteryAutonomy.Name = "lblBatteryAutonomy";
            this.lblBatteryAutonomy.Size = new System.Drawing.Size(146, 13);
            this.lblBatteryAutonomy.TabIndex = 49;
            this.lblBatteryAutonomy.Text = "Battery Autonomy (milliamp/h)";
            // 
            // txtbxBatteryAutonomy
            // 
            this.txtbxBatteryAutonomy.Location = new System.Drawing.Point(470, 66);
            this.txtbxBatteryAutonomy.Name = "txtbxBatteryAutonomy";
            this.txtbxBatteryAutonomy.Size = new System.Drawing.Size(100, 20);
            this.txtbxBatteryAutonomy.TabIndex = 48;
            // 
            // lblBluetooth
            // 
            this.lblBluetooth.AutoSize = true;
            this.lblBluetooth.Location = new System.Drawing.Point(36, 226);
            this.lblBluetooth.Name = "lblBluetooth";
            this.lblBluetooth.Size = new System.Drawing.Size(52, 13);
            this.lblBluetooth.TabIndex = 62;
            this.lblBluetooth.Text = "Bluetooth";
            // 
            // txtbxBluetooth
            // 
            this.txtbxBluetooth.Location = new System.Drawing.Point(94, 223);
            this.txtbxBluetooth.Name = "txtbxBluetooth";
            this.txtbxBluetooth.Size = new System.Drawing.Size(100, 20);
            this.txtbxBluetooth.TabIndex = 61;
            // 
            // LaptopPropertiesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 333);
            this.Controls.Add(this.lblBluetooth);
            this.Controls.Add(this.txtbxBluetooth);
            this.Controls.Add(this.lblBatteryAutonomy);
            this.Controls.Add(this.txtbxBatteryAutonomy);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblConnectionConnector);
            this.Controls.Add(this.txtbxMaximumUSBTransferRate);
            this.Controls.Add(this.lblInterface);
            this.Controls.Add(this.chkbxNFC);
            this.Controls.Add(this.lblClockFrequency);
            this.Controls.Add(this.txtbxClockFrequency);
            this.Controls.Add(this.lblCPUMicroarchitecture);
            this.Controls.Add(this.txtbxCPUMicroarchitecture);
            this.Controls.Add(this.lblProcessor);
            this.Name = "LaptopPropertiesForm";
            this.Text = "Laptop properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClockFrequency;
        private System.Windows.Forms.TextBox txtbxClockFrequency;
        private System.Windows.Forms.Label lblCPUMicroarchitecture;
        private System.Windows.Forms.TextBox txtbxCPUMicroarchitecture;
        private System.Windows.Forms.Label lblProcessor;
        private System.Windows.Forms.Label lblInterface;
        private System.Windows.Forms.CheckBox chkbxNFC;
        private System.Windows.Forms.Label lblConnectionConnector;
        private System.Windows.Forms.TextBox txtbxMaximumUSBTransferRate;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblBatteryAutonomy;
        private System.Windows.Forms.TextBox txtbxBatteryAutonomy;
        private System.Windows.Forms.Label lblBluetooth;
        private System.Windows.Forms.TextBox txtbxBluetooth;
    }
}