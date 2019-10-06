using System.Data.SQLite;
using Audiometry.Security;

namespace Audiometry.Database
{
    public static class DatabaseInfo
    {
        public const string DbConnectionString = @"Data Source=database.db;Version=3;";
        public static SQLiteConnection SqliteCon;

        public static void OpenDbConnection(bool isEncrypted)
        {
            string password = string.Empty;

            if (isEncrypted)
            {
                string username;
                byte[] ciphertext;
                byte[] entropy;

                if (PasswordUtility.RetrievePasswordFromRegistry(out username, out ciphertext, out entropy))
                {
                    password = PasswordUtility.Decrypt(ciphertext, entropy);
                }                
            }
            
            SqliteCon = new SQLiteConnection(DbConnectionString);

            if (isEncrypted)
            {
                SqliteCon.SetPassword(password);                
            }

            SqliteCon.Open();
        }

        public static void CloseDbConnection()
        {
            if (SqliteCon != null)
            {
                SqliteCon.Close();
                SqliteCon = null;   
            }
        }

        public static void SetPassword(string password)
        {
            OpenDbConnection(false);
            SqliteCon.ChangePassword(password);
            CloseDbConnection();
        }

        public static void ChangePassword(string password)
        {
            OpenDbConnection(true);
            SqliteCon.ChangePassword(password);
            CloseDbConnection();
        }

        public static void RemovePassword()
        {
            ChangePassword(string.Empty);
        }
    }
}
