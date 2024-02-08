
public static class StartUp
{
    public static void Main()
    {
        string originalTest = "Prova Pippi ciao";

        string encryptedText = AesEncryptDecrypt.Encrypt(originalTest);
        Console.WriteLine($"Encrypted: {encryptedText}");

        string decryptedText = AesEncryptDecrypt.Decrypt(encryptedText);
        Console.WriteLine($"Decrypted: {decryptedText}");
    }
}