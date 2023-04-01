using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryOOP_SiSharp_
{
    internal static class Program
    {
        class ProcessorInfo
        {
            public string CPUMicroarchitectur;
            public int clockFrequency;
        }

        class InteractionInterfaceGeneral
        {
            public string bluetooth;
            public bool NFC;
        }

        abstract class InteractionInterfacePC : InteractionInterfaceGeneral
        {
            public int maximumUSBTransferRate;
            public ProcessorInfo processor;
        }

        abstract class InteractionInterfaceMobile : InteractionInterfaceGeneral
        {
            public bool frontLightning;
            public ProcessorInfo processor;
        }

        class DesktopPC : InteractionInterfacePC
        {
            public bool monoblock;
        }

        class Laptop : InteractionInterfacePC
        {
            public int batteryAutonomy;
        }

        class Smartphone : InteractionInterfaceMobile
        {
            public string audioTypeSupportLinks;
            public string connectionConnector;
        }

        class ElectronicWatch : InteractionInterfaceMobile
        {
            public bool ECGSensor, bloodPressureMeasurement;
        }
    }
}
