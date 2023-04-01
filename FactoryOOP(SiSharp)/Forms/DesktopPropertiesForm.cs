using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Factories;
using FactoryOOP_SiSharp_.Checks;

namespace FactoryOOP_SiSharp_.Forms
{
    public partial class DesktopPropertiesForm : Form
    {
        private DesktopPC devicePC;        

        public DesktopPropertiesForm()
        {
            InitializeComponent();
        }
        
        public DesktopPropertiesForm(DesktopPC devicePC) : this()
        {
            txtbxMaximumUSBTransferRate.Text = devicePC.GetMaximumUSBTransferRate().ToString();
            chkbxMonoblock.Checked = devicePC.GetMonoblock();
            txtbxClockFrequency.Text = Convert.ToString(devicePC.GetProcessor().GetClockFrequency());
            txtbxCPUMicroarchitecture.Text = devicePC.GetProcessor().GetCPUMicroarchitecture();
            chkbxNFC.Checked = devicePC.GetNFC();
            txtbxBluetooth.Text = devicePC.GetBluetooth();
        }

        private bool checkIsCorrectInputAllData(DataMistake mistakeObj, TextBox txtbxMaximumUSBTransferRate, TextBox txtbxClockFrequency, TextBox txtbxCPUMicroarchitecture, TextBox txtbxBluetooth)
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

            if (checkIsCorrectInputAllData(mistakeObj, txtbxMaximumUSBTransferRate, txtbxClockFrequency, txtbxCPUMicroarchitecture, txtbxBluetooth))
            {
                ProcessorInfo processorDevicePC = new ProcessorInfo(txtbxCPUMicroarchitecture.Text, Int32.Parse(txtbxClockFrequency.Text));

                devicePC = new DesktopPC(chkbxMonoblock.Checked, Int32.Parse(txtbxMaximumUSBTransferRate.Text), processorDevicePC, chkbxNFC.Checked, txtbxBluetooth.Text);

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        public InteractionInterfaceGeneral GetDevicePC()
        {
            return devicePC;
        }
    }
}
