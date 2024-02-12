using RandomString4Net;
using System.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoString
{
    internal static class TestClass
    {
        public static void TestTime(int countList, int LenghtString)
        {
            List<string> listOriginale = new List<string>();
            List<string> listCrypt= new List<string>();
            List<string> listDecrypt = new List<string>();

            Stopwatch sw = new Stopwatch();

            Console.WriteLine($"Creazione lista originale ");

            sw.Start();
            for (int i = 0; i < countList; i++)
            {
                listOriginale.Add(RandomString.GetString(Types.ALPHANUMERIC_MIXEDCASE_WITH_SYMBOLS, LenghtString));
            }
            sw.Stop();

            Console.WriteLine($"Fine lista originale {sw.Elapsed}");

            sw.Start();
            Console.WriteLine($"Inizio Crypto ");

            foreach (var item in listOriginale)
            {
                listCrypt.Add(AesEncryptDecrypt.Encrypt(item));
            }

            sw.Stop();
            Console.WriteLine($"Fine Crypto {sw.Elapsed}");


            Console.WriteLine($"Inizio Decrypto ");

            foreach (var item in listCrypt) 
            {
                listDecrypt.Add(AesEncryptDecrypt.Decrypt(item));
            }

            Console.WriteLine($"fine Decrypto {sw.Elapsed}");

            foreach (var item in listOriginale)
            {
                if (!listDecrypt.Contains(item))
                {
                    throw new Exception("ATTENZIONE ERRORE NON TROVATO");
                }
            }

        }
    }
}
