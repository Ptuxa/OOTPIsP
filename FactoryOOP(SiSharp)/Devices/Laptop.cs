using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class Laptop : InteractionInterfacePC
    {
        [JsonProperty]
        public int batteryAutonomy;

        public Laptop(int batteryAutonomy, int maximumUSBTransferRate, ProcessorInfo processor, bool NFC, string bluetooth) : base(maximumUSBTransferRate, processor, NFC, bluetooth)
        {
            this.batteryAutonomy = batteryAutonomy;
        }

        public Laptop()
        {

        }

        public int GetBatteryAutonomy()
        {
            return batteryAutonomy;
        }

        public void SetBatteryAutonomy(int batteryAutonomy)
        {
            this.batteryAutonomy = batteryAutonomy;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append(base.ToString());
            strBuilder.Append("Battery autonomy: ");
            strBuilder.Append(batteryAutonomy);
            strBuilder.Append(";\n");


            return strBuilder.ToString();
        }
    }
}
