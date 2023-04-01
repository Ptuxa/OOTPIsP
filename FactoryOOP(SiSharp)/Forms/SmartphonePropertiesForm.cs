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
    public partial class SmartphonePropertiesForm : Form
    {
        private Smartphone deviceSmartphone;

        public SmartphonePropertiesForm()
        {
            InitializeComponent();
        }

        public SmartphonePropertiesForm(Smartphone deviceSmartphone) : this()
        {
            txtbxAudioTypeSupportLinks.Text = deviceSmartphone.GetAudioTypeSupportLinks();
            txtbxConnectionConnector.Text = deviceSmartphone.GetConnectionConnector();
            chkbxFrontLightning.Checked = deviceSmartphone.GetFrontLightning();
            txtbxClockFrequency.Text = deviceSmartphone.GetProcessor().GetClockFrequency().ToString();
            txtbxCPUMicroarchitecture.Text = deviceSmartphone.GetProcessor().GetCPUMicroarchitecture();
            chkbxNFC.Checked = deviceSmartphone.GetNFC();
            txtbxBluetooth.Text = deviceSmartphone.GetBluetooth();
        }

        private bool checkIsCorrectInputAllData(DataMistake mistakeObj, TextBox txtbxClockFrequency, TextBox txtbxCPUMicroarchitecture, TextBox txtbxBluetooth, TextBox txtbxlblAudioTypeSupportLinks, TextBox txtbxConnectionConnector)
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
            else if (!mistakeObj.checkStringValueNotEmpty(txtbxlblAudioTypeSupportLinks.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxlblAudioTypeSupportLinks.Name, DataMistake.INFO_STRING_EMPTY_MISTAKE);
            }
            else if (!mistakeObj.checkStringValueNotEmpty(txtbxConnectionConnector.Text))
            {
                mistakeObj.outputMistakeInputInfo(txtbxlblAudioTypeSupportLinks.Name, DataMistake.INFO_STRING_EMPTY_MISTAKE);
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

            if (checkIsCorrectInputAllData(mistakeObj, txtbxClockFrequency, txtbxCPUMicroarchitecture, txtbxBluetooth, txtbxAudioTypeSupportLinks, txtbxConnectionConnector))
            {
                ProcessorInfo processorDevicePC = new ProcessorInfo(txtbxCPUMicroarchitecture.Text, Int32.Parse(txtbxClockFrequency.Text));

                deviceSmartphone = new Smartphone(txtbxAudioTypeSupportLinks.Text, txtbxConnectionConnector.Text, chkbxFrontLightning.Checked, processorDevicePC, chkbxNFC.Checked, txtbxBluetooth.Text);

                DialogResult = DialogResult.OK;

                this.Close();
            }
        }

        public InteractionInterfaceGeneral GetDeviceSmartphone()
        {
            return deviceSmartphone;
        }
    }
}
