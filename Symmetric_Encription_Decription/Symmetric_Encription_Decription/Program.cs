using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Symmetric_Encription_Decription
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());

            /*
            string plainText = "Hello, Worldjfshdsdkfjksdjfksdjfksjdghjfcnmbvcnbmcvnbmnjghkdkfdgkfdjkgjfkdjgkfdjgkfdkgfdkgjkdfjgkfdjkgjfdkgjkjdkgfdkbmvmnbmndfkgkfdgkfdjgkfdjkgndkjhdkfgldsfgklsdmfklsdmgklsfdkglfdhjnlfdgklfdglkfmdslgkfdslgfkdsgmnbvcmbnfldkglkfdgklfdglkfdgkfdjgkldjf!";    // original plaintext

            string passPhrase = "Pad5pr@se";// "Pas5pr@se";        // can be any string
            string saltValue = "s@1tValue";        // can be any string
            string hashAlgorithm = "SHA1";             // can be "MD5"
            int passwordIterations = 2;                  // can be any number
            string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
            int keySize = 256;                // can be 192 or 128

            Console.WriteLine(String.Format("Plaintext : {0}", plainText));

          
              /  string cipherText = Encription_Decription.Encrypt(plainText,
                                                            passPhrase,
                                                            saltValue,
                                                            hashAlgorithm,
                                                            passwordIterations,
                                                            initVector,
                                                            keySize);

                Console.WriteLine(String.Format("Encrypted :{0}", cipherText));

                plainText = Encription_Decription.Decrypt(cipherText,
                                                            "Pad5pr@se",//passPhrase,
                                                            saltValue,
                                                            hashAlgorithm,
                                                            passwordIterations,
                                                            initVector,
                                                            keySize);

                Console.WriteLine(String.Format("Decrypted : {0}",  plainText));
           
*/
        }
    }
}
