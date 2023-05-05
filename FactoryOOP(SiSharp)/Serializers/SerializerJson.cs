using FactoryOOP_SiSharp_.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Text.Json.Serialization.Metadata;
using Newtonsoft.Json;
using System.Runtime.InteropServices.ComTypes;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using System.Runtime.ConstrainedExecution;

namespace FactoryOOP_SiSharp_.Serializers
{
    public class SerializerJson : SerializeInterface
    {        
        public void serialize(List<DataFileStructure> listDataFileStructure, FileStream fileStream)
        {
            var serializer = new JsonSerializer();
            var streamWriter = new StreamWriter(fileStream);
            var jsonTextWriter = new JsonTextWriter(streamWriter);
            try
            {
                serializer.Serialize(jsonTextWriter, listDataFileStructure);
                jsonTextWriter.Flush();
            }
            catch
            {
                DialogResult result = MessageBox.Show("Can't serialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }
            finally
            {
                jsonTextWriter.Close();
                streamWriter.Close();
                fileStream.Close();
            }
        }

        public List<DataFileStructure> deserialize(FileStream fileStream)
        {
            List<DataFileStructure> listDataFileStructure = null;

            var serializer = new JsonSerializer();
            var streamReader = new StreamReader(fileStream);
            var jsonTextReader = new JsonTextReader(streamReader);
            
            try
            {
                listDataFileStructure = serializer.Deserialize<List<DataFileStructure>>(jsonTextReader);
            }
            catch
            {
                DialogResult result = MessageBox.Show("Can't deserialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                listDataFileStructure = null;
            }
            finally
            {
                jsonTextReader.Close();
                streamReader.Close();
                fileStream.Close();
            }

            return listDataFileStructure;
        }
    }
}
