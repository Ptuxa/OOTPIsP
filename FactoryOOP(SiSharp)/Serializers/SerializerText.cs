using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FactoryOOP_SiSharp_.Serializers
{
    public class SerializerText : SerializeInterface
    {
        //object inheritDevice = Convert.ChangeType(device, device.GetType());
        //Type TypeDevice = typeof(InteractionInterfaceGeneral);            
        const string DELIMITER_NAME_AND_VALUE = ": ";
        const string TYPE_OBJECT = "typeObject";
        const string INDEX_CLASS = "indexClass";

        private string sumAllFieldsInString(object device, BindingFlags bindingFlags)
        {
            StringBuilder sb = new StringBuilder();
            FieldInfo[] fields = device.GetType().GetFields(bindingFlags);
            
            for (int i = 0; i < fields.Length; i++)
            {                
                if (fields[i].FieldType == typeof(ProcessorInfo))
                {
                    sb.Append(sumAllFieldsInString(fields[i].GetValue(device), bindingFlags));
                }
                else
                {
                    sb.Append(fields[i].Name);
                    sb.Append(DELIMITER_NAME_AND_VALUE);
                    sb.Append(fields[i].GetValue(device));
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }

        private string createStringToSerialize(List<DataFileStructure> listDataFileStructure)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < listDataFileStructure.Count; i++)
            {
                InteractionInterfaceGeneral device = listDataFileStructure[i].getDevice();

                sb.Append(TYPE_OBJECT);
                sb.Append(DELIMITER_NAME_AND_VALUE);
                sb.Append(device.GetType());
                sb.Append("\n");

                sb.Append(INDEX_CLASS);
                sb.Append(DELIMITER_NAME_AND_VALUE);
                sb.Append((int) listDataFileStructure[i].getIndex());
                sb.Append("\n");               
                                
                BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.FlattenHierarchy| BindingFlags.NonPublic | BindingFlags.Public;

                sb.Append(sumAllFieldsInString(device, bindingFlags));                                 
            }

            return sb.ToString();
        }

        public void serialize(List<DataFileStructure> listDataFileStructure, Stream fileStream)
        {
            StreamWriter streamWriter = new StreamWriter(fileStream);
            
            string serializeText = createStringToSerialize(listDataFileStructure);

            try
            {
                streamWriter.Write(serializeText);
                streamWriter.Flush();
            }
            catch
            {
                DialogResult result = MessageBox.Show("Can't serialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
                     
        }

        private InteractionInterfaceGeneral getType(string name, string strValue)
        {
            InteractionInterfaceGeneral device = null;

            if (name.Equals(TYPE_OBJECT))
            {
                try
                {
                    Type typeObject = Type.GetType(strValue);
                    device = (InteractionInterfaceGeneral)Activator.CreateInstance(typeObject);
                }
                catch
                {

                    device = null;
                    DialogResult result = MessageBox.Show("Incorrect type of class", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }

            }
            else
            {
                device = null;
                DialogResult result = MessageBox.Show("Incorrect format. Field type of object should be first", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            return device;
        }

        private bool getClassIndex(ref DeviceTypeEnum indexClass, string name, string strValue)
        {
            bool isCorrect = true;

            if (name.Equals(INDEX_CLASS))
            {                
                if (!Int32.TryParse(strValue, out int index))
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show("Incorrect classIndex", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    indexClass = (DeviceTypeEnum)index;
                }
            }
            else
            {
                isCorrect = false;
                DialogResult result = MessageBox.Show("Incorrect format. Field classIndex of object should be second", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            return isCorrect;
        }

        private void getInfoNamesFields(Dictionary<string, DataFileldsInfo> listFields, object device, BindingFlags bindingFlags)
        {                        
            FieldInfo[] fields = device.GetType().GetFields(bindingFlags);

            for (int i = 0; i < fields.Length; i++)
            {
                if (fields[i].FieldType == typeof(ProcessorInfo))
                {
                    getInfoNamesFields(listFields, new ProcessorInfo(), bindingFlags);
                }
                else
                {
                    listFields.Add(fields[i].Name, new DataFileldsInfo(false, device.GetType().ToString(), fields[i].FieldType.ToString()));
                }
            }
        }

        private void invokeMethod(object obj, string methodName, List<object> args)
        {
            obj.GetType().GetMethod(methodName).Invoke(obj, args.ToArray());
        }

        private bool setDeviceData(DataFileldsInfo dataFileldsInfo, object obj, string name, string value)
        {
            bool isCorrect = true;
            string methodName = "Set" + Char.ToUpper(name[0]) + name.Substring(1, name.Length - 1);

            string typeField = dataFileldsInfo.typeField.Split('.').Last();

            if (typeField.Equals("Int32"))
            {
                if (Int32.TryParse(value, out int intValue))
                {
                    invokeMethod(obj, methodName, new List<object>() { intValue });
                }
                else
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show($"Can't convert {name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }

            }
            else if (typeField.Equals("Int64"))
            {
                if (Int64.TryParse(value, out long intValue))
                {
                    invokeMethod(obj, methodName, new List<object>() { intValue });
                }
                else
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show($"Can't convert {name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }
            else if(typeField.Equals("Boolean"))
            {
                bool boolValue;
                if (value.Equals("True"))
                {
                    boolValue = true;
                    invokeMethod(obj, methodName, new List<object>() { boolValue });
                }
                else if (value.Equals("False"))
                {
                    boolValue = false;
                    invokeMethod(obj, methodName, new List<object>() { boolValue });
                }
                else
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show($"Can't convert {name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }    
            else if (typeField.Equals("String"))
            {
                invokeMethod(obj, methodName, new List<object>() { value });
            }
            else
            {
                isCorrect = false;
                DialogResult result = MessageBox.Show($"Not defined type {typeField}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            return isCorrect;            
        }
        
        private bool setAllFields(object device, List<DataTokens> listDataDeserialize, ref int i)
        {
            BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.FlattenHierarchy | BindingFlags.NonPublic | BindingFlags.Public;
            Dictionary<string, DataFileldsInfo> listFields = new Dictionary<string, DataFileldsInfo>();
            getInfoNamesFields(listFields, device, bindingFlags);

            ProcessorInfo processorInfo = new ProcessorInfo("", 0);

            bool isCorrect = true;
            bool isEnd = false;          
            while (i < listDataDeserialize.Count && isCorrect && !isEnd)
            {
                string name = listDataDeserialize[i].name;
                if (name.Equals(TYPE_OBJECT))
                {
                    isEnd = true;
                }
                else if (listFields.ContainsKey(name))
                {
                    listFields.TryGetValue(name, out DataFileldsInfo dataFileldsInfo);
                    if (dataFileldsInfo.isUsed.Equals(false))
                    {
                        if (dataFileldsInfo.typeClass.Equals(typeof(ProcessorInfo).ToString()))
                        {
                            isCorrect = setDeviceData(dataFileldsInfo, processorInfo, name, listDataDeserialize[i].strValue);
                            dataFileldsInfo.isUsed = isCorrect;
                            i++;
                        }
                        else
                        {
                            isCorrect = setDeviceData(dataFileldsInfo, device, name, listDataDeserialize[i].strValue);
                            dataFileldsInfo.isUsed = isCorrect;
                            i++;
                        }                        
                    }                    
                    else
                    {
                        isCorrect = false;
                        DialogResult result = MessageBox.Show($"Field {name} is used in several places", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }                    
                }
                else
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show($"Field not defined {name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }
            }

            if (isCorrect)
            {
                //device.GetType().GetMethod("Set" + typeof(ProcessorInfo).ToString().Split('.').Last()).Invoke(device, new[] { processorInfo });
                invokeMethod(device, "Set" + typeof(ProcessorInfo).ToString().Split('.').Last(), new List<object>() { processorInfo });
            }

            return isCorrect;
        }

        private List<DataFileStructure> createDataFileStructureListFromText(List<DataTokens> listDataDeserialize)
        {
            List<DataFileStructure> listDataFileStructure = new List<DataFileStructure>();

            bool isCorrect = true;
            int i = 0;
            while (i < listDataDeserialize.Count && isCorrect)
            {
                InteractionInterfaceGeneral device = getType(listDataDeserialize[i].name, listDataDeserialize[i].strValue);
                if (device != null)
                {                                      
                    i++;                    
                    if (i < listDataDeserialize.Count)
                    {
                        DeviceTypeEnum indexClass = 0;
                        if (getClassIndex(ref indexClass, listDataDeserialize[i].name, listDataDeserialize[i].strValue))
                        {
                            i++;
                            setAllFields(device, listDataDeserialize, ref i);
                            listDataFileStructure.Add(new DataFileStructure(indexClass, device));
                        }
                        else
                        {
                            isCorrect = false;
                        }
                    }
                    else
                    {
                        isCorrect = false;
                        DialogResult result = MessageBox.Show("Not enough fields. Can't find classIndex field", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                    }
                }
                else
                {
                    isCorrect = false;
                }
            }

            if (!isCorrect)
            {
                return null;
            }
            else
            {
                return listDataFileStructure;
            }           
        }

        private List<DataTokens> takeListDataDeserialize(string deserializeText)
        {
            List<DataTokens> listDataDeserialize = new List<DataTokens>();
            
            string[] arrStrDeserialize = deserializeText.Split('\n');
            int lengthArrStrDeserialize = arrStrDeserialize.Length;
            int lengthDelimiterNameAndValue = DELIMITER_NAME_AND_VALUE.Length;

            for (int i = 0; i < lengthArrStrDeserialize; i++)
            {
                if (!arrStrDeserialize[i].Equals(""))
                {
                    int indexDelimiter = arrStrDeserialize[i].IndexOf(DELIMITER_NAME_AND_VALUE);
                    string name = arrStrDeserialize[i].Substring(0, indexDelimiter);
                    string strValue = arrStrDeserialize[i].Substring(indexDelimiter + lengthDelimiterNameAndValue, arrStrDeserialize[i].Length - (indexDelimiter + lengthDelimiterNameAndValue));

                    listDataDeserialize.Add(new DataTokens(name, strValue));
                }                
            }

            return listDataDeserialize;
        }

        public List<DataFileStructure> deserialize(Stream fileStream)
        {
            List<DataFileStructure> listDataFileStructure = null;

            fileStream.Position = 0;    
            using (StreamReader streamReader = new StreamReader(fileStream))
            {               
                string deserializeText = "";

                bool isCorrect = true;
                try
                {
                    deserializeText = streamReader.ReadToEnd();
                }
                catch
                {
                    isCorrect = false;
                    DialogResult result = MessageBox.Show("Can't serialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                }


                //finally
                //{
                //    streamReader.Close();
                //}

                if (isCorrect)
                {
                    List<DataTokens> listDataDeserialize = takeListDataDeserialize(deserializeText);
                    listDataFileStructure = createDataFileStructureListFromText(listDataDeserialize);
                }
            }

            return listDataFileStructure;
        }
    }
}
