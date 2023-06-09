﻿using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FactoryOOP_SiSharp_.Serializers
{
    public class SerializerBinary : SerializeInterface
    {
        public void serialize(List<DataFileStructure> listDataFileStructure, Stream fileStream)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            try
            {
                binaryFormatter.Serialize(fileStream, listDataFileStructure);
            }
            catch
            {
                DialogResult result = MessageBox.Show("Can't serialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);                
            }                                     
        }        

        public List<DataFileStructure> deserialize(Stream fileStream)
        {
            List<DataFileStructure> listDataFileStructure = null;

            fileStream.Position = 0;
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            
            try
            {
                listDataFileStructure = (List<DataFileStructure>)binaryFormatter.Deserialize(fileStream);
            }
            catch
            {
                DialogResult result = MessageBox.Show("Can't deserialize data succcessfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                listDataFileStructure = null;
            }

            return listDataFileStructure;
        }
    }
}
