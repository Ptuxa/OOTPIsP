using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class DesktopPC : InteractionInterfacePC
    {
        [JsonProperty]
        private bool monoblock;

        public DesktopPC(bool monoblock, int maximumUSBTransferRate, ProcessorInfo processor, bool NFC, string bluetooth) : base(maximumUSBTransferRate, processor, NFC, bluetooth)
        {
            this.monoblock = monoblock;
        }

        public DesktopPC()
        {

        }

        public bool GetMonoblock()
        {
            return monoblock;
        }

        public void SetMonoblock(bool monoblock)
        {
            this.monoblock = monoblock;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append(base.ToString());
            strBuilder.Append("Monoblock: ");
            strBuilder.Append(TakeStrBoolYesNO(monoblock));
            strBuilder.Append(";\n");


            return strBuilder.ToString();
        }

    }
}
