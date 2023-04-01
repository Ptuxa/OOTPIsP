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
    public class LaptopFactory : DeviceInterface
    {
        public InteractionInterfaceGeneral Add()
        {
            LaptopPropertiesForm formLaptopProperies = new LaptopPropertiesForm();
            if (formLaptopProperies.ShowDialog() == DialogResult.OK)
            {
                return formLaptopProperies.GetDeviceLaptop();
            }
            else
            {
                return null;
            }
        }

        public void Edit(ref InteractionInterfaceGeneral inputDevice)
        {
            LaptopPropertiesForm formLaptopProperies = new LaptopPropertiesForm((Laptop)inputDevice);
            if (formLaptopProperies.ShowDialog() == DialogResult.OK)
            {
                inputDevice = formLaptopProperies.GetDeviceLaptop();
            }
        }
    }
}
