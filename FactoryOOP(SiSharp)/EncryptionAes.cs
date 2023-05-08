using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace FactoryOOP_SiSharp_
{
    public class EncryptionAes
    {
        private string extension;
        private byte[] key;
        private RNGCryptoServiceProvider rngcsp;
        byte[] iv;

        public EncryptionAes()
        {
            extension = ".aes";
            key = new byte[] { 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16 };
            iv = new byte[16] { 37, 190, 28, 92, 134, 70, 201, 254, 140, 70, 69, 154, 248, 243, 81, 212 };
            //rngcsp = new RNGCryptoServiceProvider();
            //rngcsp.GetBytes(iv); 
        }

        public string getExtension()
        {
            return extension;
        }

        public static void ownCopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[32768];
            int read;
            while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, read);
            }
        }

        public void encrypt(Stream fileStream)
        {
            byte[] buffer = new byte[1024];
            long readPos = 0;
            long writePos = 0;
            long readLength = fileStream.Length;

            using (var aes = new RijndaelManaged() {
                Key = key,
                IV = iv,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CFB,
            })
            {
                using (var cryptoStream = new CryptoStream(fileStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    while (readPos < readLength)
                    {
                        fileStream.Position = readPos;
                        int bytesRead = fileStream.Read(buffer, 0, buffer.Length);
                        readPos = fileStream.Position;

                        fileStream.Position = writePos;
                        cryptoStream.Write(buffer, 0, bytesRead);
                        writePos = fileStream.Position;
                    }

                    // In older versions of .NET, CryptoStream doesn't have a ctor
                    // with 'leaveOpen', so we have to do this instead.
                    cryptoStream.FlushFinalBlock();

                    // Write the IV to the end of the file
                    fileStream.Write(aes.IV, 0, aes.IV.Length);

                }
            }           
        }

        public void decrypt(Stream fileStream, Stream streamDeserialize)
        {
            byte[] buffer = new byte[1024];
            byte[] iv = new byte[16];
            long readPos = 0;
            long writePos = 0;
            long readLength = fileStream.Length - iv.Length;

            // IV is the last 16 bytes
            if (fileStream.Length < iv.Length)
                throw new IOException("File is too short");
            fileStream.Position = readLength;
            fileStream.Read(iv, 0, iv.Length);
            fileStream.SetLength(readLength);

            using (var aes = new RijndaelManaged()
            {
                Key = key,
                IV = iv,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CFB,
            })
            using (var cryptoStream = new CryptoStream(fileStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
            {
                while (readPos < readLength)
                {
                    fileStream.Position = readPos;
                    int bytesRead = cryptoStream.Read(buffer, 0, buffer.Length);
                    readPos = fileStream.Position;

                    streamDeserialize.Position = writePos;
                    streamDeserialize.Write(buffer, 0, bytesRead);
                    writePos = streamDeserialize.Position;

                    //fileStream.Position = writePos;
                    //fileStream.Write(buffer, 0, bytesRead);
                    //writePos = fileStream.Position;
                }

                streamDeserialize.SetLength(writePos);

                fileStream.SetLength(readPos + iv.Length);
                fileStream.Position = readPos;
                fileStream.Write(aes.IV, 0, aes.IV.Length);
            }
        }
    }
}




//    fileStream.Seek(0, SeekOrigin.Begin);
//byte[] iv;
//using (MemoryStream memoryStream = new MemoryStream())
//{
//    fileStream.CopyTo(memoryStream);

//    using (Aes aes = Aes.Create())
//    {
//        aes.Key = key;

//        iv = aes.IV;

//        memoryStream.Write(iv, 0, iv.Length);                    

//        using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
//        {
//            using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
//            {
//                encryptWriter.Write(fileStream);
//                encryptWriter.Flush();
//            }

//            ownCopyStream(fileStream, cryptoStream);
//            cryptoStream.Flush();



//            //fileStream.CopyTo(cryptoStream);

//            //using (StreamWriter encryptWriter = new StreamWriter(cryptoStream))
//            //{
//            //    fileStream.CopyTo(encryptWriter.BaseStream);
//            //    encryptWriter.Flush();
//            //}

//            //fileStream.Seek(0, SeekOrigin.Begin);
//            //fileStream.SetLength(memoryStream.Length);
//            //memoryStream.Seek(0, SeekOrigin.Begin);
//            //memoryStream.CopyTo(fileStream);

//            //fileStream.Seek(memoryStream.Length, SeekOrigin.Begin);
//            //cryptoStream.Flush();

//        }
//    }

//fileStream.SetLength(memoryStream.Length + iv.Length);
//memoryStream.Seek(0, SeekOrigin.Begin);
//memoryStream.CopyTo(fileStream);
//}