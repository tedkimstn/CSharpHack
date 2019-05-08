/*
 * Source: https://www.sanfoundry.com/csharp-program-encrypt-decrypt-rijndael-key/
 * Definition Source (mdoc): https://docs.microsoft.com/en-us/dotnet/
 * Author: sanfoundry
 * Summary: Encrypt and decrypt using Rijndael key.
 * Modifications: Modified namespace.
 * Student: Ted Kim
 * Capture Date: May 07, 2019
 */

using System;
using System.IO;
using System.Security.Cryptography;

namespace EncryptDecryptMProj
{
    class Rijndael
    {
        public static void Main()
        {
            try
            {

                string original = "Data For Encryption!!!!!";

                // "The using statement obtains one or more resources, executes a statement, 
                //  and then disposes of the resource" (mdoc).
                // "Accesses the managed version of the Rijndael algorithm" (mdoc).
                using (RijndaelManaged myRijndael = new RijndaelManaged())
                {
                    // "Generates a random Key to be used for the algorithm" (mdoc).
                    myRijndael.GenerateKey();
                    // "Generates a random initialization vector (IV) to be used for the algorithm" (mdoc).
                    myRijndael.GenerateIV();

                    // Encrypts data using a random key and a random vector generated.
                    byte[] encrypted = EncryptStringToBytes(original,
                                       myRijndael.Key, myRijndael.IV);

                    // Decrypts data using the same key and 
                    // the same vector used for encryption.
                    string aftdecryp = DecryptStringFromBytes(encrypted,
                                       myRijndael.Key, myRijndael.IV);

                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("After Decryption: {0}", aftdecryp);
                }

            }
            // Catches and displays an exception.
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }

        static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            // Null tests.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");

            byte[] encrypted;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                // "Gets or sets the secret key 
                //  used for the symmetric algorithm" (mdoc).
                rijAlg.Key = Key;
                // "Gets or sets the initialization vector (IV) 
                //  to use for the symmetric algorithm" (mdoc).
                rijAlg.IV = IV;

                // "Creates a symmetric Rijndael encryptor object 
                //  with the specified Key and initialization vector (IV)" (mdoc).
                ICryptoTransform encryptor = rijAlg.CreateEncryptor(rijAlg.Key,
                                             rijAlg.IV);
                // "MemoryStream": "Creates a stream whose backing store is memory" (mdoc).
                // Writes a string in a StreamWriter, encrypted in a CrpytoStream 
                // and saved in MemoryStream. 
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    // "CryptoStream": "Defines a stream that links data streams
                    //  to cryptographic transformations" (mdoc).
                    // "CryptoStream(Stream, ICryptoTransform, CryptoStreamMode)" (mdoc).
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,
                            encryptor, CryptoStreamMode.Write))
                    {
                        // "StreamWriter": "Implements a TextWriter for writing characters 
                        //  to a stream in a particular encoding" (mdoc).
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            // Writes to the StreamWriter stream.
                            swEncrypt.Write(plainText);
                        }
                        // "Writes the stream contents to a byte array" (mdoc).
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }
            return encrypted;
        }

        static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Null tests.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("Key");
            string plaintext = null;

            using (RijndaelManaged rijAlg = new RijndaelManaged())
            {
                // Sets a key and a vector to be used for decryption.
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                // "Creates a symmetric Rijndael decryptor object with the specified Key 
                //  and initialization vector (IV)" (mdoc).
                ICryptoTransform decryptor = rijAlg.CreateDecryptor(rijAlg.Key,
                                             rijAlg.IV);
                // Opens a MemoryStream that encrypted data can be read from a memory.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    // Opens a CryptoStream with a stream to read from, 
                    // decryptor object and read CryptoStreamMode.
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt,
                           decryptor, CryptoStreamMode.Read))
                    {
                        // Opens a StreamReader to read decrpyted string from CryptoStream.
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            // "Reads all characters from the current position to the end of the stream" (mdoc).
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }

    }
}

/* This code produces the following results:

Original:   Data For Encryption!!!!!
After Decryption: Data For Encryption!!!!!

Press any key to continue...

 */
