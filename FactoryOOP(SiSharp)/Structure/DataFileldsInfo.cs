using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Structure
{
    public class DataFileldsInfo
    {
        public bool isUsed;
        public string typeClass;
        public string typeField;

        public DataFileldsInfo(bool isUsed, string typeClass, string typeField)
        {
            this.typeField = typeField;
            this.isUsed = isUsed;
            this.typeClass = typeClass;
        }
    }
}
