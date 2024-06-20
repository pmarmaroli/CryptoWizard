using System;
using System.IO;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;

public static class EncryptionUtility
{
    private static string EncryptionKey;

    public static void LoadEncryptionKey(string keyFilePath)
    {
        if (!File.Exists(keyFilePath))
        {
            throw new FileNotFoundException($"The key file {keyFilePath} does not exist.");
        }

        EncryptionKey = File.ReadAllText(keyFilePath).Trim();

        if (EncryptionKey.Length == 0)
        {
            throw new Exception("The key file is empty.");
        }
    }

    public static void EncryptFile(string inputFile, string outputFile)
    {
        byte[] keyBytes = Convert.FromBase64String(EncryptionKey);
        byte[] ivBytes = new byte[16]; // AES uses a 16-byte IV

        using (var aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fsOutput, encryptor, CryptoStreamMode.Write))
            {
                fsInput.CopyTo(cryptoStream);
            }
        }
    }

    public static void DecryptFile(string inputFile, string outputFile)
    {
        byte[] keyBytes = Convert.FromBase64String(EncryptionKey);
        byte[] ivBytes = new byte[16]; // AES uses a 16-byte IV

        using (var aes = Aes.Create())
        {
            aes.Key = keyBytes;
            aes.IV = ivBytes;

            using (var decryptor = aes.CreateDecryptor(aes.Key, aes.IV))
            using (var fsInput = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (var fsOutput = new FileStream(outputFile, FileMode.Create, FileAccess.Write))
            using (var cryptoStream = new CryptoStream(fsInput, decryptor, CryptoStreamMode.Read))
            {
                cryptoStream.CopyTo(fsOutput);
            }
        }
    }
}

public static class KeyGenerator
{
    public static string GenerateEncryptionKey(int keySizeInBits)
    {
        using (var rng = new RNGCryptoServiceProvider())
        {
            var key = new byte[keySizeInBits / 8];
            rng.GetBytes(key);
            return Convert.ToBase64String(key);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: DecryptionUtilityApp <encrypt|decrypt|generatekey> <path to key file or key size> <path to input file (optional)>");
            return;
        }

        string operation = args[0];
        string keyFilePath = args[1];
        string inputFile = args.Length > 2 ? args[2] : null;
        string outputFile;

        try
        {
            if (operation.ToLower() == "generatekey")
            {
                if (!int.TryParse(keyFilePath, out int keySize) || (keySize != 128 && keySize != 192 && keySize != 256))
                {
                    Console.WriteLine("Invalid key size specified. Use 128, 192, or 256.");
                    return;
                }

                string encryptionKey = KeyGenerator.GenerateEncryptionKey(keySize);
                Console.WriteLine($"Generated Encryption Key: {encryptionKey}");

                string outputFolder = AppDomain.CurrentDomain.BaseDirectory;
                keyFilePath = Path.Combine(outputFolder, "encryptionKey.txt");

                if (!Directory.Exists(outputFolder))
                {
                    Directory.CreateDirectory(outputFolder);
                }

                File.WriteAllText(keyFilePath, encryptionKey);
                Console.WriteLine($"Encryption key written to: {keyFilePath}");
            }
            else
            {
                EncryptionUtility.LoadEncryptionKey(keyFilePath);

                if (operation.ToLower() == "encrypt")
                {
                    outputFile = inputFile + ".enc";
                    EncryptionUtility.EncryptFile(inputFile, outputFile);
                    Console.WriteLine("File encrypted successfully. Output file: " + outputFile);
                }
                else if (operation.ToLower() == "decrypt")
                {
                    outputFile = inputFile.Substring(0, inputFile.Length - 4); // Remove the ".enc" extension
                    EncryptionUtility.DecryptFile(inputFile, outputFile);
                    Console.WriteLine("File decrypted successfully. Output file: " + outputFile);
                }
                else
                {
                    Console.WriteLine("Invalid operation specified. Use 'encrypt', 'decrypt', or 'generatekey'.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("An error occurred: " + ex.Message);
        }
    }
}
