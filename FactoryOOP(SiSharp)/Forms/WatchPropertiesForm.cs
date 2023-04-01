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
    public partial class WatchPropertiesForm : Form
    {
        private ElectronicWatches deviceWatches;

        public WatchPropertiesForm()
        {
            InitializeComponent();
        }

        public WatchPropertiesForm(ElectronicWatches deviceWatches) : this()
        {
            chkbxECGSensor.Checked = deviceWatches.GetECGSensor();
            chkbxBloodPressure.Checked = deviceWatches.GetBloodPressureMeasurement();
            chkbxFrontLightning.Checked = deviceWatches.GetFrontLightning();
            txtbxClockFrequency.Text = deviceWatches.GetProcessor().GetClockFrequency().ToString();
            txtbxCPUMicroarchitecture.Text = deviceWatches.GetProcessor().GetCPUMicroarchitecture();
            chkbxNFC.Checked = deviceWatches.GetNFC();
            txtbxBluetooth.Text = deviceWatches.GetBluetooth();
        }

        private bool checkIsCorrectInputAllData(DataMistake mistakeObj, TextBox txtbxClockFrequency, TextBox txtbxCPUMicroarchitecture, TextBox txtbxBluetooth)
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
            else
            {
                isCorrect = true;
            }

            return isCorrect;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataMistake mistakeObj = new DataMistake();

            if (checkIsCorrectInputAllData(mistakeObj, txtbxClockFrequency, txtbxCPUMicroarchitecture, txtbxBluetooth))
            {
                ProcessorInfo processorDevicePC = new ProcessorInfo(txtbxCPUMicroarchitecture.Text, Int32.Parse(txtbxClockFrequency.Text));

                deviceWatches = new ElectronicWatches(chkbxECGSensor.Checked, chkbxBloodPressure.Checked, chkbxFrontLightning.Checked, processorDevicePC, chkbxNFC.Checked, txtbxBluetooth.Text);

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        public InteractionInterfaceGeneral GetDeviceWatches()
        {
            return deviceWatches;
        }
    }
}
