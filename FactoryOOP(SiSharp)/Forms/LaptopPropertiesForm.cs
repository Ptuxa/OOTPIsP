using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryOOP_SiSharp_.Checks;

namespace FactoryOOP_SiSharp_.Forms
{
    public partial class LaptopPropertiesForm : Form
    {       
        private Laptop deviceLaptop;

        public LaptopPropertiesForm()
        {
            InitializeComponent();
        }

        public LaptopPropertiesForm(Laptop deviceLaptop) : this()
        {
            txtbxMaximumUSBTransferRate.Text = deviceLaptop.GetMaximumUSBTransferRate().ToString();
            txtbxBatteryAutonomy.Text = deviceLaptop.GetBatteryAutonomy().ToString();
            txtbxClockFrequency.Text = deviceLaptop.GetProcessor().GetClockFrequency().ToString();
            txtbxCPUMicroarchitecture.Text = deviceLaptop.GetProcessor().GetCPUMicroarchitecture();
            chkbxNFC.Checked = deviceLaptop.GetNFC();
            txtbxBluetooth.Text = deviceLaptop.GetBluetooth();
        }

        private bool checkIsCorrectInputAllData(DataMistake mistakeObj, TextBox txtbxMaximumUSBTransferRate, TextBox txtbxClockFrequency, TextBox txtbxCPUMicroarchitecture, TextBox txtbxBluetooth, TextBox txtbxBatteryAutonomy)
        {
            bool isCorrect = false;

            if (!mistakeObj.checkStringValueNotEmpty(txtbxCPUMicroarchitecture.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxCPUMicroarchitecture.Name, DataMistake.INFO_STRING_EMPTY_MISTAKE);
            }
            else if (!mistakeObj.checkIntValue(txtbxClockFrequency.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxClockFrequency.Name, DataMistake.INFO_INT_MISTAKE);
            }
            else if (!mistakeObj.checkStringValueNotEmpty(txtbxBluetooth.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxBluetooth.Name, DataMistake.INFO_STRING_EMPTY_MISTAKE);
            }
            else if (!mistakeObj.checkIntValue(txtbxBatteryAutonomy.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxBatteryAutonomy.Name, DataMistake.INFO_INT_MISTAKE);
            }
            else if (!mistakeObj.checkIntValue(txtbxMaximumUSBTransferRate.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxMaximumUSBTransferRate.Name, DataMistake.INFO_INT_MISTAKE);
            }                                               
            else
            {
                isCorrect = true;
            }

            return isCorrect;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataMistake mistakeObj = new DataMistake();

            if (checkIsCorrectInputAllData(mistakeObj, txtbxMaximumUSBTransferRate, txtbxClockFrequency, txtbxCPUMicroarchitecture, txtbxBluetooth, txtbxBatteryAutonomy))
            {
                ProcessorInfo processorDevicePC = new ProcessorInfo(txtbxCPUMicroarchitecture.Text, Int32.Parse(txtbxClockFrequency.Text));

                deviceLaptop = new Laptop(Int32.Parse(txtbxBatteryAutonomy.Text), Int32.Parse(txtbxMaximumUSBTransferRate.Text), processorDevicePC, chkbxNFC.Checked, txtbxBluetooth.Text);

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        public InteractionInterfaceGeneral GetDeviceLaptop()
        {
            return deviceLaptop;
        }
    }
}
