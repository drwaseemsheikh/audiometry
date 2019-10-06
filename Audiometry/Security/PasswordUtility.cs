using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Win32;

namespace Audiometry.Security
{
    public class PasswordUtility
    {
        private const string registryLocation = @"SOFTWARE\Audiometry\Settings";
        private const string userNameKey = "Username";
        private const string passwordKey = "Password";
        private const string entropyKey = "Entropy";

        public static void Encrypt(string str, out byte[] ciphertext, out byte[] entropy)
        {
            byte[] plaintext = Encoding.ASCII.GetBytes(str);
            entropy = new byte[20];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(entropy);
            }

            ciphertext = ProtectedData.Protect(plaintext, entropy, DataProtectionScope.CurrentUser);
        }

        public static string Decrypt(byte[] ciphertext, byte[] entropy)
        {
            byte[] plaintext = ProtectedData.Unprotect(ciphertext, entropy, DataProtectionScope.CurrentUser);
            string plaintextstr = Encoding.ASCII.GetString(plaintext);

            return plaintextstr;
        }

        public static bool Verify(string username, string password)
        {
            string storedUsername;
            byte[] storedCiphertext;
            byte[] storedEntropy;

            if (!RetrievePasswordFromRegistry(out storedUsername, out storedCiphertext, out storedEntropy))
            {
                return false;
            }
            
            string decryptPswd = Decrypt(storedCiphertext, storedEntropy);

            return (password.Equals(decryptPswd) && username.Equals(storedUsername));
        }

        public static void StorePasswordInRegistry(string username, byte[] ciphertext, byte[] entropy)
        {
            RegistryKey key = Registry.CurrentUser.CreateSubKey(registryLocation);
            key.SetValue(userNameKey, username);
            key.SetValue(passwordKey, ciphertext);
            key.SetValue(entropyKey, entropy);
            key.Close();
        }

        public static bool RetrievePasswordFromRegistry(out string username, out byte[] ciphertext, out byte[] entropy)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey(registryLocation);

            if (key == null)
            {
                username = null;
                ciphertext = null;
                entropy = null;

                return false;
            }

            string[] keyValueNames = key.GetValueNames();

            if (!keyValueNames.Contains(userNameKey) || !keyValueNames.Contains(passwordKey) ||
                !keyValueNames.Contains(entropyKey))
            {
                username = null;
                ciphertext = null;
                entropy = null;

                return false;
            }
            else
            {
                username = key.GetValue(userNameKey).ToString();
                ciphertext = (byte[])(key.GetValue(passwordKey));
                entropy = (byte[])(key.GetValue(entropyKey));

                return true;
            }  
        }
    }
}
