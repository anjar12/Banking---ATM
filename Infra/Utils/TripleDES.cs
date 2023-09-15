using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Utils
{
    public class TripleDES
    {
        public class EncryptTripleDES
        {
            public string EncryptString(string Message, string Passphrase)
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Langkah 1. hash passphrase kita menggunakan MD5
                // Kita menggunakan generator hash MD5  hasilnya adalah array byte 128 bit
                // yang panjang berlaku untuk encoder TripleDES kita gunakan di bawah ini
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. kita Membuat TripleDESCryptoServiceProvider object baru
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. set encodernya
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert string yang di input ke byte[]
                byte[] DataToEncrypt = UTF8.GetBytes(Message);

                // Step 5. mencoba untuk menecrypte string
                try
                {
                    ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                    Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
                }
                finally
                {
                    // Hapus service TripleDes dan Hashprovider dari setiap informasi sensitif
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Langkah 6. Kembali ke string terenkripsi sebagai string base64 encode
                string result = Convert.ToBase64String(Results);
                return result;
            }

            public string DecryptString(string Message, string Passphrase)
            {
                byte[] Results;
                System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();

                // Langkah 1. hash passphrase kita menggunakan MD5
                // Kita menggunakan generator hash MD5  hasilnya adalah array byte 128 bit
                // yang panjang berlaku untuk encoder TripleDES kita gunakan di bawah ini
                MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
                byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(Passphrase));

                // Step 2. kita Membuat TripleDESCryptoServiceProvider object baru
                TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();

                // Step 3. set encodernya
                TDESAlgorithm.Key = TDESKey;
                TDESAlgorithm.Mode = CipherMode.ECB;
                TDESAlgorithm.Padding = PaddingMode.PKCS7;

                // Step 4. Convert string yang di input ke byte[]
                string message = Message;
                byte[] DataToDecrypt = Convert.FromBase64String(message);

                // Step 5. mencoba untuk menecrypte string
                try
                {
                    ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                    Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
                }
                finally
                {
                    // Hapus service TripleDes dan Hashprovider dari setiap informasi sensitif
                    TDESAlgorithm.Clear();
                    HashProvider.Clear();
                }

                // Langkah 6. Kembali string didekripsi dalam format UTF8
                return UTF8.GetString(Results);
            }
        }
    }
}
