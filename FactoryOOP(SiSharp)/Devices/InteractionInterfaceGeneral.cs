using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    public class InteractionInterfaceGeneral
    {
        private bool NFC;
        private string bluetooth;

        public InteractionInterfaceGeneral(bool NFC, string bluetooth)
        {
            this.NFC = NFC;
            this.bluetooth = bluetooth;
        }

        public bool GetNFC()
        {
            return NFC;
        }

        public void SetNFC(bool NFC)
        {
            this.NFC = NFC;
        }

        public string GetBluetooth()
        {
            return bluetooth;
        }

        public void SetBluetooth(string bluetooth)
        {
            this.bluetooth = bluetooth;
        }

        public string TakeStrBoolYesNO(bool value)
        {
            string result;

            if (value)
            {
                result = "yes";
            }
            else
            {
                result = "no";
            }

            return result;
        }


        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append("NFC: ");
            strBuilder.Append(TakeStrBoolYesNO(NFC));
            strBuilder.Append(";\n");
            strBuilder.Append("Bluetooth: ");
            strBuilder.Append(bluetooth);
            strBuilder.Append(";\n");

            return strBuilder.ToString();
        }
    }
}
