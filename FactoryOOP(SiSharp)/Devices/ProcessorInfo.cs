using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    [Serializable]
    public class ProcessorInfo
    {
        [JsonProperty]
        private string CPUMicroarchitecture;

        [JsonProperty]
        private int clockFrequency;

        public ProcessorInfo(string CPUMicroarchitecture, int clockFrequency) 
        {
            this.CPUMicroarchitecture = CPUMicroarchitecture;
            this.clockFrequency = clockFrequency;
        }

        public ProcessorInfo()
        {

        }

        public string GetCPUMicroarchitecture()
        {
            return CPUMicroarchitecture;
        }

        public void SetCPUMicroarchitecture(string CPUMicroarchitecture)
        {
            this.CPUMicroarchitecture = CPUMicroarchitecture;
        }

        public int GetClockFrequency()
        {
            return clockFrequency;
        }

        public void SetClockFrequency(int clockFrequency)
        {
            this.clockFrequency = clockFrequency;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder(); 

            strBuilder.Append("CPU microarchitecture: ");
            strBuilder.Append(CPUMicroarchitecture);
            strBuilder.Append(";\n");
            strBuilder.Append("Clock frequency: ");
            strBuilder.Append(clockFrequency.ToString());
            strBuilder.Append(";\n");

            return strBuilder.ToString();
        }
    }
}
