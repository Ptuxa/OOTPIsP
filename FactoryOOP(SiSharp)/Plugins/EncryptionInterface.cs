using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryOOP_SiSharp_.Plugins
{
    public interface EncryptionInterface
    {
        string getExtension();
        void encrypt(Stream fileStream);
        void decrypt(Stream fileStream, Stream streamDeserialize);
    }
}
