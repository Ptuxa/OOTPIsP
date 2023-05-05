using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Serializers
{
    public class SerializeStructure
    {
        private Type typeSerializator;
        private string nameDialogTitle;
        private string extension;

        public SerializeStructure (Type typeSerializator, string nameDialogTitle, string extension)
        {
            this.typeSerializator = typeSerializator;
            this.nameDialogTitle = nameDialogTitle;
            this.extension = extension;
        }

        public string getName() { return nameDialogTitle; }

        public Type getTypeSerializator() { return typeSerializator; }

        public string getExtension() { return extension; }
    }
}
