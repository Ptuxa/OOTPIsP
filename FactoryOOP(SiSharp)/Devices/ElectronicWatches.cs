using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Devices
{
    public class ElectronicWatches : InteractionIntefaceMobile
    {
        private bool ECGSensor;
        private bool bloodPressureMeasurement;

        public ElectronicWatches(bool ECGSensor, bool bloodPressureMeasurement, bool frontLightning, ProcessorInfo processor, bool NFC, string bluetooth) : base(frontLightning, processor, NFC, bluetooth)
        {
            this.ECGSensor = ECGSensor;
            this.bloodPressureMeasurement = bloodPressureMeasurement;
        }

        public bool GetECGSensor()
        {
            return ECGSensor;
        }

        public void SetECGSensor(bool ECGSensor)
        {
            this.ECGSensor = ECGSensor;
        }

        public bool GetBloodPressureMeasurement()
        {
            return bloodPressureMeasurement;
        }

        public void SetBloodPressureMeasurement(bool bloodPressureMeasurement)
        {
            this.bloodPressureMeasurement = bloodPressureMeasurement;
        }

        public override string ToString()
        {
            StringBuilder strBuilder = new StringBuilder();

            strBuilder.Append(base.ToString());
            strBuilder.Append("ECG Sensor: ");
            strBuilder.Append(TakeStrBoolYesNO(ECGSensor));
            strBuilder.Append(";\n");
            strBuilder.Append("Blood pressure measurement: ");
            strBuilder.Append(TakeStrBoolYesNO(bloodPressureMeasurement));
            strBuilder.Append(";\n");

            return strBuilder.ToString();
        }
    }
}
