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
    public class ElectronicWatchesFactory : DeviceInterface
    {
        public InteractionInterfaceGeneral Add()
        {
            WatchPropertiesForm formWatchProperies = new WatchPropertiesForm();
            if (formWatchProperies.ShowDialog() == DialogResult.OK)
            {
                return formWatchProperies.GetDeviceWatches();
            }
            else
            {
                return null;
            }
        }

        public void Edit(ref InteractionInterfaceGeneral inputDevice)
        {
            WatchPropertiesForm formWatchProperies = new WatchPropertiesForm((ElectronicWatches)inputDevice);
            if (formWatchProperies.ShowDialog() == DialogResult.OK)
            {
                inputDevice = formWatchProperies.GetDeviceWatches();
            }
        }
    }
}
