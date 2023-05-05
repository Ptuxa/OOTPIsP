using FactoryOOP_SiSharp_.Structure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Serializers
{
    public interface SerializeInterface
    {
        void serialize(List<DataFileStructure> listEndDevices, FileStream fileStream);

        List<DataFileStructure> deserialize(FileStream fileStream);
    }
}
