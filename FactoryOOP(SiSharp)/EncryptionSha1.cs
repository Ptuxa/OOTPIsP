using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FactoryOOP_SiSharp_
{
    public class EncryptionSha1
    {
        private string extension;

        private string password;
        private string solString;
        private int passwordIteration;
        private string hashString;
        private int keySize;
        
        public EncryptionSha1()
        {
            extension = ".sha1";

            password = "I like";
            solString = "doberman";
            passwordIteration = 2;
            hashString = "a8doSuDitOz1hZe#";
            keySize = 256;
        }

        public string getExtension()
        {
            return extension;
        }

        public void encrypt(Stream fileStream)
        {
            byte[] hashBytes = Encoding.ASCII.GetBytes(hashString);
            byte[] solBytes = Encoding.ASCII.GetBytes(solString);

            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(password, solBytes, "SHA1", passwordIteration);
            byte[] keyBytes = passwordDeriveBytes.GetBytes(keySize / 8);

            fileStream.Position = 0;
            long readPos = 0;
            long readLength = fileStream.Length;
            byte[] bufferRead = new byte[1024];
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;

                using (ICryptoTransform encryptor = rijndaelManaged.CreateEncryptor(keyBytes, hashBytes))
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
        }
     
        public void decrypt(Stream fileStream, Stream streamDeserialize)
        {
            byte[] hashBytes = Encoding.ASCII.GetBytes(hashString);
            byte[] solBytes = Encoding.ASCII.GetBytes(solString);

            PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(password, solBytes, "SHA1", passwordIteration);
            byte[] keyBytes = passwordDeriveBytes.GetBytes(keySize / 8);

            fileStream.Position = 0;
            streamDeserialize.Position = 0;
            long readPos = 0;
            long readLength = fileStream.Length;
            byte[] bufferRead = new byte[1024];
            using (RijndaelManaged rijndaelManaged = new RijndaelManaged())
            {
                rijndaelManaged.Mode = CipherMode.CBC;

                using (ICryptoTransform decryptor = rijndaelManaged.CreateDecryptor(keyBytes, hashBytes))
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
