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
using FactoryOOP_SiSharp_.Serializers;
using System.IO;
using System.Reflection;
using FactoryOOP_SiSharp_.Plugins;
using System.IO.Pipes;
using System.Security.Cryptography;


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
        SerializeFactory serializeFactory = new SerializeFactory();
        EncryptionFactory encryptionFactory = new EncryptionFactory();
        string filter;



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

        public string takeStringFilter()
        {
            string filter = "";

            Dictionary<string, SerializeStructure> dictionarySerializators = serializeFactory.getDictionarySerializators();
            Dictionary<string, EncryptionStructure> dictionaryPlugin = encryptionFactory.getDictionaryPlugin();

            Dictionary<string, SerializeStructure>.ValueCollection dictionarySerializatorsValues = dictionarySerializators.Values;
            Dictionary<string, EncryptionStructure>.ValueCollection dictionaryPluginValues = dictionaryPlugin.Values;

            foreach (SerializeStructure dictionarySerializatorsValuesItem in dictionarySerializatorsValues)
            {
                string baseFormat = "*." + dictionarySerializatorsValuesItem.getExtension(); ;

                string format = baseFormat;
                foreach (EncryptionStructure dictionaryPluginValuesItem in dictionaryPluginValues)
                {
                    format = format + ";" + baseFormat + "." + dictionaryPluginValuesItem.getExtension();
                }

                filter = filter + $"{dictionarySerializatorsValuesItem.getName()}|{format}|";
            }

            if (!filter.Equals(""))
            {
                filter = filter.Substring(0, filter.Length - 1);
            }

            return filter;
        }

        public MainForm()
        {
            InitializeComponent();
            loadTypesDevicesInComboBox(ref cmbxSelectDevices, listTypesDevices);

            openFileDialog.InitialDirectory = Environment.CurrentDirectory;
            saveFileDialog.InitialDirectory = Environment.CurrentDirectory;

            encryptionFactory.takePlugins();
            filter = takeStringFilter();
            openFileDialog.Filter = filter;
            saveFileDialog.Filter = filter;
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

        private string[] getExtensions(string path)
        {
            string[] arrStrPartsPath = path.Split('.');

            string extensionSerializer = "";
            string extensionEncrypting = "";

            int lengthArrStrPartsPath = arrStrPartsPath.Length;
            if (lengthArrStrPartsPath == 2)
            {
                if (serializeFactory.checkContainsExtension(arrStrPartsPath[lengthArrStrPartsPath - 1]))
                {
                    extensionSerializer = arrStrPartsPath[1];
                }
            }
            else if (arrStrPartsPath.Length == 3)
            {
                if (encryptionFactory.checkContainsExtension(arrStrPartsPath[lengthArrStrPartsPath - 1]))
                {
                    extensionEncrypting = arrStrPartsPath[lengthArrStrPartsPath - 1];

                    if (serializeFactory.checkContainsExtension(arrStrPartsPath[lengthArrStrPartsPath - 2]))
                    {
                        extensionSerializer = arrStrPartsPath[lengthArrStrPartsPath - 2];
                    }
                }
            }
            else if (arrStrPartsPath.Length == 4)
            {
                if (encryptionFactory.checkContainsExtension(arrStrPartsPath[lengthArrStrPartsPath - 2]))
                {
                    extensionEncrypting = arrStrPartsPath[lengthArrStrPartsPath - 2];

                    if (serializeFactory.checkContainsExtension(arrStrPartsPath[lengthArrStrPartsPath - 3]))
                    {
                        extensionSerializer = arrStrPartsPath[lengthArrStrPartsPath - 3];
                    }
                }
            }

            return new string[] { extensionSerializer, extensionEncrypting };
        }

        private void outputAllDevicesNamesInListBox(ref ListBox lstbxDevices, List<DeviceData> listEndDevices)
        {
            lstbxDevices.Items.Clear();

            for (int i = 0; i < listEndDevices.Count; i++)
            {
                lstbxDevices.Items.Add(listEndDevices[i].getName());
            }            
        }

        private string findNameTypeDeviceByIndex(List<DeviceTypeIndexing> listTypesDevices, DeviceTypeEnum index)
        {
            string name = "";
            bool isFind = false;
            int i = 0;            
            while (i < listTypesDevices.Count && !isFind)
            {
                if (listTypesDevices[i].getIndex() == index)
                {
                    isFind = true;
                    name = listTypesDevices[i].getName();
                }
                else
                {
                    i++;
                }
            }

            return name;
        }

        public List<DeviceData> takeListEndDevices(List<DataFileStructure> listDataFileStructure, List<DeviceTypeIndexing> listTypesDevices)
        {
            List<DeviceData> listEndDevices = new List<DeviceData>();

            for (int i = 0; i < listDataFileStructure.Count; i++)
            {
                DeviceTypeEnum indexEnum = listDataFileStructure[i].getIndex();
                listEndDevices.Add(new DeviceData(listDataFileStructure[i].getDevice(), listDataFileStructure[i].getDevice().ToString(), indexEnum, findNameTypeDeviceByIndex(listTypesDevices, indexEnum)));
                //listEndDevices[i].setDevice();
                //listEndDevices[i].setIndex(listDataFileStructure[i].getIndex());
            }

            return listEndDevices;
        }

        private MemoryStream callToDecrypt(FileStream fileStream, EncryptionInterface plugin)
        {            
            MemoryStream memoryStream = new MemoryStream();
            
            try
            {
                //EncryptionSha1 encryptionSha1 = new EncryptionSha1();
                //encryptionSha1.decrypt(fileStream, memoryStream);             
                plugin.decrypt(fileStream, memoryStream);
            }
            catch
            {
                memoryStream = null;
                DialogResult result = MessageBox.Show("Can't decrypt data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }                
            
            return memoryStream;
        }

        private List<DataFileStructure> callToDeserialize(Stream stream, string extension)
        {
            Type typeSerializator = serializeFactory.takeTypeSerializator(extension);
            SerializeInterface serializator = (SerializeInterface)Activator.CreateInstance(typeSerializator);

            List<DataFileStructure> tempList = serializator.deserialize(stream);

            return tempList;
        }

        private void outputDataToInterfaceAfterDeserialization(List<DataFileStructure> tempList)
        {
            if (tempList != null)
            {
                listEndDevices = takeListEndDevices(tempList, listTypesDevices);
                outputAllDevicesNamesInListBox(ref lstbxDevices, listEndDevices);
                txtbxDeviceProperties.Clear();

                if (listEndDevices.Count != 0)
                {
                    lstbxDevices.SelectedIndex = 0;
                    outputDescriptionInTextBox(ref txtbxDeviceProperties, listEndDevices[lstbxDevices.SelectedIndex].getDescription());
                }
            }
        }

        private void mnOpen_Click(object sender, EventArgs e)
        {        
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog.FileName;

                string[] extensions = getExtensions(path);

                if (extensions[0] != "")
                {                    
                    List<DataFileStructure> tempList = null;
                    using (FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
                    {
                        EncryptionStructure encryptionStructure = encryptionFactory.tryGetEncryptionStructure(extensions[1]);
                        if (encryptionStructure != null)
                        {
                            EncryptionInterface plugin = (EncryptionInterface)Activator.CreateInstance(encryptionStructure.getTypeEncryption());
                            using (MemoryStream memoryStream = callToDecrypt(fileStream, plugin))
                            {
                                if (memoryStream != null)
                                {
                                    tempList = callToDeserialize(memoryStream, extensions[0]);
                                }
                            }
                        }
                        else
                        {
                            tempList = callToDeserialize(fileStream, extensions[0]);
                        }
                    }
                    outputDataToInterfaceAfterDeserialization(tempList);
                }                    
            }
        }

        public List<DataFileStructure> takeListForFileStrucuture(List<DeviceData> listEndDevices)
        {
            List<DataFileStructure> listDataFileStructure = new List<DataFileStructure>();

            for (int i = 0; i < listEndDevices.Count; i++)
            {
                listDataFileStructure.Add(new DataFileStructure(listEndDevices[i].getIndex(), listEndDevices[i].getDevice()));
            }

            return listDataFileStructure;
        }

        private void callToEncrypt(FileStream fileStream, EncryptionInterface plugin)
        {
            try
            {
                plugin.encrypt(fileStream);
                //EncryptionSha1 encryptionSha1 = new EncryptionSha1();
                //encryptionSha1.encrypt(fileStream);
            }
            catch
            {
                fileStream = null;
                DialogResult result = MessageBox.Show("Can't encrypt data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
        }

        private void callToSerialize(Stream stream, string extension)
        {
            Type typeSerializator = serializeFactory.takeTypeSerializator(extension);
            SerializeInterface serializator = (SerializeInterface)Activator.CreateInstance(typeSerializator);

            serializator.serialize(takeListForFileStrucuture(listEndDevices), stream);
        }

        private string createNewPath(string path, string[] extensions)
        {
            string newPath = path.Split('.').FirstOrDefault();
            if (extensions[0] != "")
            {
                newPath = newPath + "." + extensions[0];
            }

            if (extensions[1] != "")
            {
                newPath = newPath + "." + extensions[1];
            }

            return newPath;
        }

        private void mnSave_Click(object sender, EventArgs e)
        {
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {                
                string path = saveFileDialog.FileName;
                string[] extensions = getExtensions(path);
                string newPath = createNewPath(path, extensions);

                if (extensions[0] != "")
                {                    
                    using (FileStream fileStream = new FileStream(newPath, FileMode.Create, FileAccess.ReadWrite))
                    {
                        callToSerialize(fileStream, extensions[0]);

                        EncryptionStructure encryptionStructure = encryptionFactory.tryGetEncryptionStructure(extensions[1]);
                        if (encryptionStructure != null)
                        {
                            EncryptionInterface plugin = (EncryptionInterface)Activator.CreateInstance(encryptionStructure.getTypeEncryption());
                            callToEncrypt(fileStream, plugin);
                        }
                    }
                }                                      
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