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
using FactoryOOP_SiSharp_.Structure;


namespace FactoryOOP_SiSharp_.Forms
{
    public partial class MainForm : Form
    {
        List<DeviceTypeIndexing> listTypesDevices = new List<DeviceTypeIndexing>()
        {
            new DeviceTypeIndexing(DeviceTypeEnum.DESKTOP_PC, "DesktopPC"),
            new DeviceTypeIndexing(DeviceTypeEnum.LAPTOP, "Laptop"),
            new DeviceTypeIndexing(DeviceTypeEnum.SMARTPHONE, "Smartphone"),
            new DeviceTypeIndexing(DeviceTypeEnum.ELECTRONIC_WATCHES, "ElectronicWatches")
        };

        List<DeviceData> listEndDevices = new List<DeviceData>();

        DeviceFactory abstractFactory = new DeviceFactory();



        private void loadTypesDevicesInComboBox(ref ComboBox cmbxSelectDevices, List<DeviceTypeIndexing> listTypesDevices)
        {
            foreach (DeviceTypeIndexing listTypesDevicesItem in listTypesDevices)
            {
                cmbxSelectDevices.Items.Add(listTypesDevicesItem.getName());
            }

            if (cmbxSelectDevices.Items.Count > 0)
            {
                cmbxSelectDevices.SelectedIndex = 0;
            }            
        }

        public MainForm()
        {
            InitializeComponent();
            loadTypesDevicesInComboBox(ref cmbxSelectDevices, listTypesDevices);
        }



        private void outputDescriptionInTextBox(ref TextBox textBox, string description)
        {
            string[] arrStrTemp = description.Split('\n');

            textBox.Clear();
            for (int i = 0; i < arrStrTemp.Length; i++)
            {                
                textBox.AppendText(arrStrTemp[i]);
                textBox.AppendText(Environment.NewLine);
            }
        }
              
        private void btnAdd_Click(object sender, EventArgs e)
        {
            DeviceInterface definiteFactory = abstractFactory.definiteSpecializedFactory(listTypesDevices[cmbxSelectDevices.SelectedIndex].getIndex());
            if (definiteFactory != null)
            {
                InteractionInterfaceGeneral endDevice = definiteFactory.Add();
                if (endDevice != null)
                {
                    listEndDevices.Add(new DeviceData(endDevice, endDevice.ToString(), listTypesDevices[cmbxSelectDevices.SelectedIndex].getIndex(), listTypesDevices[cmbxSelectDevices.SelectedIndex].getName()));

                    lstbxDevices.Items.Add(listEndDevices.Last().getName());
                    lstbxDevices.SelectedIndex = lstbxDevices.Items.Count - 1;
                    outputDescriptionInTextBox(ref txtbxDeviceProperties, listEndDevices.Last().getDescription());
                }
            }            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (lstbxDevices.Items.Count > 0 && lstbxDevices.SelectedIndex >= 0)
            {
                InteractionInterfaceGeneral selectDevice = listEndDevices[lstbxDevices.SelectedIndex].getDevice();
                DeviceInterface definiteFactory = abstractFactory.definiteSpecializedFactory(listEndDevices[lstbxDevices.SelectedIndex].getIndex());
                definiteFactory.Edit(ref selectDevice);

                listEndDevices[lstbxDevices.SelectedIndex].setDescription(selectDevice.ToString());

                outputDescriptionInTextBox(ref txtbxDeviceProperties, listEndDevices[lstbxDevices.SelectedIndex].getDescription());                
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lstbxDevices.Items.Count > 0 && lstbxDevices.SelectedIndex >= 0)
            {
                listEndDevices.Remove(listEndDevices[lstbxDevices.SelectedIndex]);

                lstbxDevices.Items.RemoveAt(lstbxDevices.SelectedIndex);
                if (lstbxDevices.Items.Count > 0)
                {
                    lstbxDevices.SelectedIndex = lstbxDevices.Items.Count - 1;
                    outputDescriptionInTextBox(ref txtbxDeviceProperties, listEndDevices[lstbxDevices.SelectedIndex].getDescription());
                }
                else
                {
                    txtbxDeviceProperties.Clear();
                }                               
            }
        }

        private void lstbxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstbxDevices.SelectedIndex > -1)
            {
                outputDescriptionInTextBox(ref txtbxDeviceProperties, listEndDevices[lstbxDevices.SelectedIndex].getDescription());
            }
            
        }        
    }
}



    //public class Devices
    //{
    //    interface IDevices
    //    {

    //    }

    //    class ProcessorInfo
    //    {
    //        public string CPUMicroarchitectur;
    //        public int clockFrequency;
    //    }

    //    class InteractionInterfaceGeneral
    //    {
    //        public string bluetooth;
    //        public bool NFC;
    //    }

    //    abstract class InteractionInterfacePC : InteractionInterfaceGeneral
    //    {                  
    //        public int maximumUSBTransferRate;
    //        public ProcessorInfo processor;
    //    }

    //    abstract class InteractionInterfaceMobile : InteractionInterfaceGeneral
    //    {
    //        public bool frontLightning;
    //        public ProcessorInfo processor;
    //    }                
        
    //    class DesktopPC : InteractionInterfacePC
    //    {
    //        public bool monoblock;
    //    }

    //    class Laptop : InteractionInterfacePC
    //    {
    //        public int batteryAutonomy;
    //    }

    //    class Smartphone : InteractionInterfaceMobile
    //    {
    //        public string audioTypeSupportLinks;
    //        public string connectionConnector;
    //    }

    //    class ElectronicWatch : InteractionInterfaceMobile
    //    {
    //        public bool ECGSensor, bloodPressureMeasurement;
    //    }
    //}