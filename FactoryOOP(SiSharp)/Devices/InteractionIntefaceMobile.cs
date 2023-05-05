using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class InteractionIntefaceMobile : InteractionInterfaceGeneral
    {
        [JsonProperty]
        protected bool frontLightning;

        [JsonProperty]
        protected ProcessorInfo processor;

        public InteractionIntefaceMobile(bool frontLightning, ProcessorInfo processor, bool NFC, string bluetooth) : base(NFC, bluetooth)
        {
            this.frontLightning = frontLightning;
            this.processor = processor;
        }

        public InteractionIntefaceMobile()
        {
            processor = new ProcessorInfo();
        }

        public bool GetFrontLightning()
        {
            return frontLightning;
        }

        public void SetFrontLightning(bool frontLightning)
        {
            this.frontLightning = frontLightning;
        }

        public ProcessorInfo GetProcessor()
        {
            return processor;
        }

        public void SetProcessorInfo(ProcessorInfo processor)
        {
            this.processor = processor;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append(base.ToString());
            strBuilder.Append("Front lightnining: ");
            strBuilder.Append(TakeStrBoolYesNO(frontLightning));
            strBuilder.Append(";\n");
            strBuilder.Append(processor.ToString());

            return strBuilder.ToString();
        }
    }
}
