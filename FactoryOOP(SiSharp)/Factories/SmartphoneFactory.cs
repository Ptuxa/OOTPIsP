using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FactoryOOP_SiSharp_.Factories
{
    internal class SmartphoneFactory : DeviceInterface
    {
        public InteractionInterfaceGeneral Add()
        {
            SmartphonePropertiesForm formSmartphoneProperies = new SmartphonePropertiesForm();
            if (formSmartphoneProperies.ShowDialog() == DialogResult.OK)
            {
                return formSmartphoneProperies.GetDeviceSmartphone();
            }
            else
            {
                return null;
            }
        }

        public void Edit(ref InteractionInterfaceGeneral inputDevice)
        {
            SmartphonePropertiesForm formSmartphoneProperies = new SmartphonePropertiesForm((Smartphone)inputDevice);
            if (formSmartphoneProperies.ShowDialog() == DialogResult.OK)
            {
                inputDevice = formSmartphoneProperies.GetDeviceSmartphone();
            }
        }
    }
}
