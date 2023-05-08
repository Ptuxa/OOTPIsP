using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Plugins;
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

        public Type takeTypeSerializator(string extension)
        {
            Type typeSerializator = null;

            if (dictionarySerializators.TryGetValue(extension, out SerializeStructure structure))
            {
                typeSerializator = structure.getTypeSerializator();
            }
            
            return typeSerializator;
        }

        public Dictionary<string, SerializeStructure> getDictionarySerializators()
        {
            return dictionarySerializators;
        }

        public bool checkContainsExtension(string extension)
        {
            return dictionarySerializators.ContainsKey(extension);
        }
    }   
}
