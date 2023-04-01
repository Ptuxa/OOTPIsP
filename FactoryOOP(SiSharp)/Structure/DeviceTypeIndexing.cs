using FactoryOOP_SiSharp_.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FactoryOOP_SiSharp_.Structure
{
    public class DeviceTypeIndexing
    {
        private DeviceTypeEnum index;
        private string name;

        public DeviceTypeIndexing(DeviceTypeEnum index, string name)
        {
            this.index = index;
            this.name = name;
        }

        public DeviceTypeEnum getIndex()
        {
            return index;
        }

        public void setIndex(DeviceTypeEnum index)
        {
            this.index = index;
        }

        public string getName()
        {
            return name;
        }

        public void setName(string name)
        {
            this.name = name;
        }
    }
}
