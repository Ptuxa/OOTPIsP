﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class InteractionInterfacePC : InteractionInterfaceGeneral
    {
        [JsonProperty]
        protected int maximumUSBTransferRate;

        [JsonProperty]
        protected ProcessorInfo processor;

        public InteractionInterfacePC(int maximumUSBTransferRate, ProcessorInfo processor, bool NFC, string bluetooth) : base(NFC, bluetooth)
        {       
            this.maximumUSBTransferRate = maximumUSBTransferRate;
            this.processor = processor;
        }

        public InteractionInterfacePC()
        {
            processor = new ProcessorInfo();
        }

        public int GetMaximumUSBTransferRate()
        {
            return maximumUSBTransferRate;
        }

        public void SetMaximumUSBTransferRate(int maximumUSBTransferRate)
        {
            this.maximumUSBTransferRate = maximumUSBTransferRate;
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
            strBuilder.Append("Maximum USB transfer rate: ");
            strBuilder.Append(maximumUSBTransferRate.ToString());
            strBuilder.Append(";\n");
            strBuilder.Append(processor.ToString());

            return strBuilder.ToString();
        }
    }
}
