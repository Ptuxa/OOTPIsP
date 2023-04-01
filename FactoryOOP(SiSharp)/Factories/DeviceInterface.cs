using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Factories
{
    public interface DeviceInterface
    {
        InteractionInterfaceGeneral Add();

        void Edit(ref InteractionInterfaceGeneral device);
    }
}
