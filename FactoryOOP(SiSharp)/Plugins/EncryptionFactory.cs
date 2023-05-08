using FactoryOOP_SiSharp_.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;

namespace FactoryOOP_SiSharp_.Plugins
{
    public class EncryptionFactory
    {
        private Dictionary<string, EncryptionStructure> dictionaryPlugins;

        public EncryptionFactory()
        {
            dictionaryPlugins = new Dictionary<string, EncryptionStructure>();        
        }


        public void takePlugins()
        {
            dictionaryPlugins.Clear();

            string dirFullProject = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\.."));

            string[] arrStrDirsDebug = Directory.GetDirectories(dirFullProject, "debug", SearchOption.AllDirectories);

            for (int i = 0; i < arrStrDirsDebug.Length; i++)
            {
                string[] arrStrFilesDll = Directory.GetFiles(arrStrDirsDebug[i], "*.dll", SearchOption.AllDirectories);

                for (int j = 0; j < arrStrFilesDll.Length; j++)
                {
                    Type[] arrTypes = null;
                    try
                    {
                        Assembly assembly = Assembly.LoadFrom(arrStrFilesDll[j]);
                        arrTypes = assembly.GetExportedTypes();

                        for (int k = 0; k < arrTypes.Length; k++)
                        {
                            if (typeof(EncryptionInterface).IsAssignableFrom(arrTypes[k]))
                            {
                                EncryptionInterface plugin = (EncryptionInterface)Activator.CreateInstance(arrTypes[k]);
                                string extension = plugin.getExtension().Substring(1, plugin.getExtension().Length - 1);

                                if (!dictionaryPlugins.ContainsKey(extension))
                                {
                                    dictionaryPlugins.Add(extension, new EncryptionStructure(arrTypes[k], extension));
                                }
                            }
                        }
                    }
                    catch
                    {

                    }                  
                }
            }
        }

        public EncryptionStructure tryGetEncryptionStructure(string extension)
        {
            EncryptionStructure encryptionStructure = null;

            if (dictionaryPlugins.ContainsKey(extension))
            {
                if (!dictionaryPlugins.TryGetValue(extension, out encryptionStructure))
                {
                    encryptionStructure = null;
                }
            }
            
            return encryptionStructure;
        }

        public Dictionary<string, EncryptionStructure> getDictionaryPlugin()
        {
            return dictionaryPlugins;
        }

        public bool checkContainsExtension(string extension)
        {
            return dictionaryPlugins.ContainsKey(extension);
        }
    }
}
