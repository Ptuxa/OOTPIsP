using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Plugins
{
    public class EncryptionStructure
    {
        private Type typeEncryption;
        private string extension;
        public EncryptionStructure(Type typeEncryption, string extension)
        {
            this.typeEncryption = typeEncryption;
            this.extension = extension;
        }


        public Type getTypeEncryption() { return typeEncryption; }

        public string getExtension() { return extension; }
    }
}
