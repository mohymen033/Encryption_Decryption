using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;


namespace Symmetric_Encription_Decription
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("dsds");


        }

        string palintext;
        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox1.Text = openFileDialog1.FileName;

            FileStream fileStream1 = System.IO.File.OpenRead(textBox1.Text);

            byte[] cipherTextBytes = new byte[fileStream1.Length];
            fileStream1.Read(cipherTextBytes, 0, cipherTextBytes.Length);
            palintext = Encoding.ASCII.GetString(cipherTextBytes);          
        }


        string passPhrase = "Pad5pr@se";// "Pas5pr@se";        // can be any string
        string saltValue = "s@1tValue";        // can be any string
        string hashAlgorithm = "SHA1";             // can be "MD5"
        int passwordIterations = 2;                  // can be any number
        string initVector = "@1B2c3D4e5F6g7H8"; // must be 16 bytes
        int keySize = 256;

        string cipherText;
        private void button2_Click(object sender, EventArgs e)
        {

            openFileDialog1.ShowDialog();
            textBox2.Text = openFileDialog1.FileName;

            cipherText = Encription_Decription.Encrypt(palintext,
                                                             passPhrase,
                                                             saltValue,
                                                             hashAlgorithm,
                                                             passwordIterations,
                                                             initVector,
                                                             keySize,textBox2.Text);    
        }

        string decriptedtext;
        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            textBox3.Text = openFileDialog1.FileName;

            decriptedtext = Encription_Decription.Decrypt(cipherText, passPhrase,
                                                             saltValue,
                                                             hashAlgorithm,
                                                             passwordIterations,
                                                             initVector,
                                                             keySize, textBox2.Text
                                                            );

            FileStream fileStream1 = System.IO.File.OpenWrite(textBox3.Text);
            byte[] cipherTextBytes = Encoding.ASCII.GetBytes(decriptedtext);
            fileStream1.Write(cipherTextBytes, 0, cipherTextBytes.Length);

            fileStream1.Close();
        }




        
    }
}
