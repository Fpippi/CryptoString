
using CryptoString;
using System.Text;

public static class StartUp
{
    public static void Main()
    {
        string originalTest = "Prova Pippi ciao";

        AesEncryptDecrypt.Key = Encoding.UTF8.GetBytes("ChiavePippo".PadRight(32, '\0')).Take(32).ToArray();
        AesEncryptDecrypt.IV = Encoding.UTF8.GetBytes("VettoreIniziale".PadRight(16, '\0')).Take(16).ToArray();

        string encryptedText = AesEncryptDecrypt.Encrypt(originalTest);
        Console.WriteLine($"Encrypted: {encryptedText}");

        string decryptedText = AesEncryptDecrypt.Decrypt(encryptedText);
        Console.WriteLine($"Decrypted: {decryptedText}");

        TestClass.TestTime(500000, 256);


        string json = "[{\r\n  \"id\": 1,\r\n  \"first_name\": \"Jeanette\",\r\n  \"last_name\": \"Penddreth\",\r\n  \"email\": \"jpenddreth0@census.gov\",\r\n  \"gender\": \"Female\",\r\n  \"ip_address\": \"26.58.193.2\"\r\n}, {\r\n  \"id\": 2,\r\n  \"first_name\": \"Giavani\",\r\n  \"last_name\": \"Frediani\",\r\n  \"email\": \"gfrediani1@senate.gov\",\r\n  \"gender\": \"Male\",\r\n  \"ip_address\": \"229.179.4.212\"\r\n}, {\r\n  \"id\": 3,\r\n  \"first_name\": \"Noell\",\r\n  \"last_name\": \"Bea\",\r\n  \"email\": \"nbea2@imageshack.us\",\r\n  \"gender\": \"Female\",\r\n  \"ip_address\": \"180.66.162.255\"\r\n}, {\r\n  \"id\": 4,\r\n  \"first_name\": \"Willard\",\r\n  \"last_name\": \"Valek\",\r\n  \"email\": \"wvalek3@vk.com\",\r\n  \"gender\": \"Male\",\r\n  \"ip_address\": \"67.76.188.26\"\r\n}]";
        string encryptedjson = AesEncryptDecrypt.Encrypt(json);

        Console.WriteLine(encryptedjson);

        string decryptedjson = AesEncryptDecrypt.Decrypt(encryptedjson);
        Console.WriteLine(decryptedjson);

        string CryptoString = "PrsO3EUSr93ZeWhXHAnZx+qZm1Ysj183f1UgyTsV5Xw=";
        Console.WriteLine($"Decrypt {AesEncryptDecrypt.Decrypt(CryptoString)}");
    }
}