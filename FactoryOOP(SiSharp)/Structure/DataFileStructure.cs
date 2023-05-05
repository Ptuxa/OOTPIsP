using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Structure
{
    [Serializable]
    public class DataFileStructure
    {
        [JsonProperty]
        private DeviceTypeEnum index;
        [JsonProperty]
        private InteractionInterfaceGeneral device;

        public DataFileStructure(DeviceTypeEnum index, InteractionInterfaceGeneral device)
        {
            this.index = index;
            this.device = device;
        }

        public DeviceTypeEnum getIndex() { return index; }
        public void setIndex(DeviceTypeEnum index) { this.index = index; }

        public InteractionInterfaceGeneral getDevice() { return device;}
        public void setDevice(InteractionInterfaceGeneral device) {  this.device = device; }
    }
}
