namespace FactoryOOP_SiSharp_.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.mnSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cmbxSelectDevices = new System.Windows.Forms.ComboBox();
            this.lblSelectDevices = new System.Windows.Forms.Label();
            this.lblListDevices = new System.Windows.Forms.Label();
            this.lstbxDevices = new System.Windows.Forms.ListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lblInfoDevices = new System.Windows.Forms.Label();
            this.txtbxDeviceProperties = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnFile});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(538, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnFile
            // 
            this.mnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnOpen,
            this.mnSave,
            this.toolStripMenuItem1,
            this.mnExit});
            this.mnFile.Name = "mnFile";
            this.mnFile.Size = new System.Drawing.Size(37, 20);
            this.mnFile.Text = "File";
            // 
            // mnOpen
            // 
            this.mnOpen.Name = "mnOpen";
            this.mnOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnOpen.Size = new System.Drawing.Size(154, 22);
            this.mnOpen.Text = "Open";
            // 
            // mnSave
            // 
            this.mnSave.Name = "mnSave";
            this.mnSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.mnSave.Size = new System.Drawing.Size(154, 22);
            this.mnSave.Text = "Save";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(151, 6);
            // 
            // mnExit
            // 
            this.mnExit.Name = "mnExit";
            this.mnExit.Size = new System.Drawing.Size(154, 22);
            this.mnExit.Text = "Exit";
            // 
            // cmbxSelectDevices
            // 
            this.cmbxSelectDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbxSelectDevices.FormattingEnabled = true;
            this.cmbxSelectDevices.Location = new System.Drawing.Point(15, 62);
            this.cmbxSelectDevices.Name = "cmbxSelectDevices";
            this.cmbxSelectDevices.Size = new System.Drawing.Size(183, 21);
            this.cmbxSelectDevices.TabIndex = 1;
            // 
            // lblSelectDevices
            // 
            this.lblSelectDevices.AutoSize = true;
            this.lblSelectDevices.Location = new System.Drawing.Point(15, 46);
            this.lblSelectDevices.Name = "lblSelectDevices";
            this.lblSelectDevices.Size = new System.Drawing.Size(75, 13);
            this.lblSelectDevices.TabIndex = 2;
            this.lblSelectDevices.Text = "Select device:";
            // 
            // lblListDevices
            // 
            this.lblListDevices.AutoSize = true;
            this.lblListDevices.Location = new System.Drawing.Point(12, 95);
            this.lblListDevices.Name = "lblListDevices";
            this.lblListDevices.Size = new System.Drawing.Size(75, 13);
            this.lblListDevices.TabIndex = 3;
            this.lblListDevices.Text = "Select device:";
            // 
            // lstbxDevices
            // 
            this.lstbxDevices.FormattingEnabled = true;
            this.lstbxDevices.Location = new System.Drawing.Point(15, 111);
            this.lstbxDevices.Name = "lstbxDevices";
            this.lstbxDevices.Size = new System.Drawing.Size(276, 381);
            this.lstbxDevices.TabIndex = 4;
            this.lstbxDevices.SelectedIndexChanged += new System.EventHandler(this.lstbxDevices_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(216, 62);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(49, 508);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 6;
            this.btnEdit.Text = "Edit";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(170, 508);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 7;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lblInfoDevices
            // 
            this.lblInfoDevices.AutoSize = true;
            this.lblInfoDevices.Location = new System.Drawing.Point(311, 85);
            this.lblInfoDevices.Name = "lblInfoDevices";
            this.lblInfoDevices.Size = new System.Drawing.Size(101, 13);
            this.lblInfoDevices.TabIndex = 8;
            this.lblInfoDevices.Text = "Properties of device";
            // 
            // txtbxDeviceProperties
            // 
            this.txtbxDeviceProperties.Location = new System.Drawing.Point(314, 111);
            this.txtbxDeviceProperties.Multiline = true;
            this.txtbxDeviceProperties.Name = "txtbxDeviceProperties";
            this.txtbxDeviceProperties.Size = new System.Drawing.Size(212, 381);
            this.txtbxDeviceProperties.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 552);
            this.Controls.Add(this.txtbxDeviceProperties);
            this.Controls.Add(this.lblInfoDevices);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstbxDevices);
            this.Controls.Add(this.lblListDevices);
            this.Controls.Add(this.lblSelectDevices);
            this.Controls.Add(this.cmbxSelectDevices);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Devices";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnFile;
        private System.Windows.Forms.ToolStripMenuItem mnOpen;
        private System.Windows.Forms.ToolStripMenuItem mnSave;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnExit;
        private System.Windows.Forms.ComboBox cmbxSelectDevices;
        private System.Windows.Forms.Label lblSelectDevices;
        private System.Windows.Forms.Label lblListDevices;
        private System.Windows.Forms.ListBox lstbxDevices;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label lblInfoDevices;
        private System.Windows.Forms.TextBox txtbxDeviceProperties;
    }
}

