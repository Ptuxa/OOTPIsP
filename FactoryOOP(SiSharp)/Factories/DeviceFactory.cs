using FactoryOOP_SiSharp_.Devices;
using FactoryOOP_SiSharp_.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Factories
{
    public class DeviceFactory
    {
        public DeviceInterface definiteSpecializedFactory(DeviceTypeEnum types)
        {
            DeviceInterface result = null;

            switch (types)
            {
                case DeviceTypeEnum.DESKTOP_PC:
                    result = new DesktopFactory();
                    break;
                case DeviceTypeEnum.LAPTOP:
                    result = new LaptopFactory();
                    break;
                case DeviceTypeEnum.SMARTPHONE:
                    result = new SmartphoneFactory();
                    break;
                case DeviceTypeEnum.ELECTRONIC_WATCHES:
                    result = new ElectronicWatchesFactory();
                    break;
            }

            return result;
        }
    }
}
