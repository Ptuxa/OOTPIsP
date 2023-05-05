using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Serializers
{
    public class SerializeFactory
    {
        private Dictionary<string, SerializeStructure> dictionarySerializators;

        public SerializeFactory()
        {
            SerializerBinary serializerBinary = new SerializerBinary();
            SerializerJson serializerJson = new SerializerJson();
            SerializerText serializerText = new SerializerText();

            dictionarySerializators = new Dictionary<string, SerializeStructure>()
            {
                {"json", new SerializeStructure (serializerJson.GetType(), "Json File", "json")},
                {"bin", new SerializeStructure(serializerBinary.GetType(), "Binary File", "bin")},
                {"txt", new SerializeStructure (serializerText.GetType(), "Text File", "txt")},
            };
        }

        public string takeStringFilterFromDictionary()
        {
            string filter = "";

            Dictionary<string, SerializeStructure>.ValueCollection dictionarySerializatorsValues = dictionarySerializators.Values;
            foreach (SerializeStructure dictionarySerializatorsValuesItem in dictionarySerializatorsValues)
            {
                string extension = dictionarySerializatorsValuesItem.getExtension();
                filter = filter + $"{dictionarySerializatorsValuesItem.getName()} (*.{extension})|*.{extension}|";
            }

            if (!filter.Equals(""))
            {
                filter = filter.Substring(0, filter.Length - 1);
            }

            return filter;
        }

        public Type takeTypeSerializator(string extension)
        {
            Type typeSerializator = null;

            if (dictionarySerializators.TryGetValue(extension, out SerializeStructure structure))
            {
                typeSerializator = structure.getTypeSerializator();
            }
            
            return typeSerializator;
        }
    }   
}
