using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Symmetric_Encription_Decription
{
    public class Encription_Decription
    {
        //for encription method
        public static string Encrypt(string plainText,
                                 string passPhrase,
                                 string saltValue,
                                 string hashAlgorithm,
                                 int passwordIterations,
                                 string initVector,
                                 int keySize,string encodedfile)
        {
            
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);

            byte[] plainTextBytes = Encoding.ASCII.GetBytes(plainText);


            PasswordDeriveBytes password = new PasswordDeriveBytes
                (passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);

            byte[] keyBytes = password.GetBytes(keySize / 8);

            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;

            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(
                                                             keyBytes,
                                                             initVectorBytes);
         //   MemoryStream memoryStream = new MemoryStream();


            FileStream fileStream = new FileStream(encodedfile, FileMode.OpenOrCreate, FileAccess.Write);
            CryptoStream cryptoStream = new CryptoStream(fileStream,
                                                         encryptor,
                                                         CryptoStreamMode.Write);

            // Start encrypting.
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);

            // Finish encrypting.
            cryptoStream.FlushFinalBlock();

            fileStream.Close();
            FileStream fileStream1 = System.IO.File.OpenRead(encodedfile);

            byte[] cipherTextBytes = new byte[fileStream1.Length];
            fileStream1.Read(cipherTextBytes, 0, cipherTextBytes.Length); 

            // Convert our encrypted data from a memory stream into a byte array.
           // byte[] cipherTextBytes =fileStream.Read( 
            //memoryStream.ToArray();

            // Close both streams.
           // memoryStream.Close();
            fileStream1.Close();
            cryptoStream.Close();

            // Convert encrypted data into a base64-encoded string.
            string cipherText = Convert.ToBase64String(cipherTextBytes);

            // Return encrypted string.
            return cipherText;
        }
      
        //Decription method
        public static string Decrypt(string   cipherText,
                                 string   passPhrase,
                                 string   saltValue,
                                 string   hashAlgorithm,
                                 int      passwordIterations,
                                 string   initVector,
                                 int      keySize,string encodedfile)
    {
        
        byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
        byte[] saltValueBytes  = Encoding.ASCII.GetBytes(saltValue);
        
        
        byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
        
        PasswordDeriveBytes password = new PasswordDeriveBytes(
                                                        passPhrase, 
                                                        saltValueBytes, 
                                                        hashAlgorithm, 
                                                        passwordIterations);
        
        byte[] keyBytes = password.GetBytes(keySize / 8);
        RijndaelManaged    symmetricKey = new RijndaelManaged();
        symmetricKey.Mode = CipherMode.CBC;
        ICryptoTransform decryptor = symmetricKey.CreateDecryptor(
                                                         keyBytes, 
                                                         initVectorBytes);
        //MemoryStream  memoryStream = new MemoryStream(cipherTextBytes);

        FileStream fileStream = new FileStream(encodedfile, FileMode.Open, FileAccess.Read);

        CryptoStream  cryptoStream = new CryptoStream(fileStream, 
                                                      decryptor,
                                                      CryptoStreamMode.Read);

        byte[] plainTextBytes = new byte[cipherTextBytes.Length];
        
        // Start decrypting.
        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 
                                                   0, 
                                                   plainTextBytes.Length);
                
        // Close both streams.
        fileStream.Close();
        cryptoStream.Close();
        
        // Convert decrypted data into a string. 
        
        string plainText = Encoding.ASCII.GetString(plainTextBytes, 
                                                   0, 
                                                   decryptedByteCount);
        
        // Return decrypted string.   
        return plainText;
            }
        }
}
