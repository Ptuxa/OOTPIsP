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
    public class DesktopFactory : DeviceInterface
    {
        public InteractionInterfaceGeneral Add()
        {
            DesktopPropertiesForm formDesktopProperies = new DesktopPropertiesForm();
            if (formDesktopProperies.ShowDialog() == DialogResult.OK)
            {
                return formDesktopProperies.GetDevicePC();
            }
            else
            {
                return null;
            }
        }

        public void Edit(ref InteractionInterfaceGeneral inputDevice)
        {
            DesktopPropertiesForm formDesktopProperies = new DesktopPropertiesForm((DesktopPC) inputDevice);
            if (formDesktopProperies.ShowDialog() == DialogResult.OK)
            {
                inputDevice = formDesktopProperies.GetDevicePC();
            }                                  
        }
    }
}
