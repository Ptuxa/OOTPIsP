using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EncryptingDes
{
    public class EncryptionDes : FactoryOOP_SiSharp_.Plugins.EncryptionInterface
    {
        private string extension;
        private byte[] key;
        private RNGCryptoServiceProvider rngcsp;
        byte[] iv;

        public EncryptionDes()
        {
            extension = ".des";
            key = new byte[] { 68, 252, 207, 79, 216, 44, 53, 3 };
            iv = new byte[] { 86, 96, 171, 54, 229, 69, 63, 124 };

            //key = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            //iv = new byte[16] { 37, 190, 28, 92, 134, 70, 201, 254, 140, 70, 69, 154, 248, 243, 81, 212 };
        }

        public string getExtension()
        {
            return extension;
        }

        public void encrypt(Stream fileStream)
        {
            fileStream.Position = 0;
            long readPos = 0;
            long readLength = fileStream.Length;
            byte[] bufferRead = new byte[1024];
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (ICryptoTransform encryptor = provider.CreateEncryptor(key, iv))
                {
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        using (CryptoStream cryptoStream = new CryptoStream(tempStream, encryptor, CryptoStreamMode.Write))
                        {
                            while (readPos < readLength)
                            {
                                int readBytes = fileStream.Read(bufferRead, 0, bufferRead.Length);
                                readPos = fileStream.Position;

                                cryptoStream.Write(bufferRead, 0, readBytes);
                            }

                            cryptoStream.FlushFinalBlock();

                            tempStream.Position = 0;
                            fileStream.Position = 0;
                            fileStream.SetLength(tempStream.Length);
                            tempStream.CopyTo(fileStream);
                        }
                    }

                }
            }

            //byte[] messageBytes = ASCIIEncoding.ASCII.GetBytes(message);
            //byte[] passwordBytes = ASCIIEncoding.ASCII.GetBytes(password);

            //// Set encryption settings -- Use password for both key and init. vector
            //DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            //ICryptoTransform transform = provider.CreateEncryptor(passwordBytes, passwordBytes);
            //CryptoStreamMode mode = CryptoStreamMode.Write;

            //// Set up streams and encrypt
            //MemoryStream memStream = new MemoryStream();
            //CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            //cryptoStream.Write(messageBytes, 0, messageBytes.Length);
            //cryptoStream.FlushFinalBlock();

            //// Read the encrypted message from the memory stream
            //byte[] encryptedMessageBytes = new byte[memStream.Length];
            //memStream.Position = 0;
            //memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            //// Encode the encrypted message as base64 string
            //string encryptedMessage = Convert.ToBase64String(encryptedMessageBytes);

            //return encryptedMessage;
        }

        public void decrypt(Stream fileStream, Stream streamDeserialize)
        {
            fileStream.Position = 0;
            long readPos = 0;
            long readLength = fileStream.Length;
            byte[] bufferRead = new byte[1024];
            using (DESCryptoServiceProvider provider = new DESCryptoServiceProvider())
            {
                using (ICryptoTransform decryptor = provider.CreateDecryptor(key, iv))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(fileStream, decryptor, CryptoStreamMode.Read))
                    {
                        while (readPos < readLength)
                        {
                            int bytesRead = cryptoStream.Read(bufferRead, 0, bufferRead.Length);
                            readPos = fileStream.Position;

                            streamDeserialize.Write(bufferRead, 0, bytesRead);
                            streamDeserialize.Flush();
                        }
                    }
                }
            }
        }
    }
}
