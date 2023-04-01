using FactoryOOP_SiSharp_.Devices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Structure
{
    public class DeviceData : DeviceTypeIndexing
    {

        private InteractionInterfaceGeneral device;
        private string description;

        public DeviceData(InteractionInterfaceGeneral device, string description, DeviceTypeEnum index, string name) : base(index, name)
        {
            this.device = device;
            this.description = description;
        }

        public InteractionInterfaceGeneral getDevice()
        {
            return device;
        }

        public void setDevice(InteractionInterfaceGeneral device)
        {
            this.device = device;
        }

        public string getDescription()
        {
            return description;
        }

        public void setDescription(string description)
        {
            this.description = description;
        }
    }
}
