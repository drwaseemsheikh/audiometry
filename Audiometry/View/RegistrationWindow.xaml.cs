using System;
using System.Windows;
using Audiometry.Database;
using Audiometry.Security;

namespace Audiometry.View
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        private MainWindow mainWindow;
        private LoginWindow loginWindow;

        public RegistrationWindow()
        {
            try
            {
                InitializeComponent();
                mainWindow = null;
                loginWindow = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Application.Current.Shutdown();
            }
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loginWindow = new LoginWindow();
                loginWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Reset();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        public void Reset()
        {
            try
            {
                usernameTxt.Text = string.Empty;
                passwordBox.Password = string.Empty;
                passwordBoxConfirm.Password = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
                Application.Current.Shutdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (usernameTxt.Text.Length == 0)
                {
                    errormessage.Text = "Enter a username.";
                    usernameTxt.Focus();
                }
                else
                {
                    string username = usernameTxt.Text;
                    string password = passwordBox.Password;

                    if (passwordBox.Password.Length == 0)
                    {
                        errormessage.Text = "Enter password.";
                        passwordBox.Focus();
                    }
                    else if (passwordBoxConfirm.Password.Length == 0)
                    {
                        errormessage.Text = "Enter the Confirm password.";
                        passwordBoxConfirm.Focus();
                    }
                    else if (passwordBox.Password != passwordBoxConfirm.Password)
                    {
                        errormessage.Text = "Confirm password must be same as password.";
                        passwordBoxConfirm.Focus();
                    }
                    else
                    {
                        errormessage.Text = string.Empty;

                        //check if username already exists. Go back to login.
                        string savedUsername;
                        byte[] ciphertext;
                        byte[] entropy;

                        if (PasswordUtility.RetrievePasswordFromRegistry(out savedUsername, out ciphertext, out entropy))
                        {
                            errormessage.Text = "The software is already registered to a user. " +
                                                "Please login with the username and password used to register the software.";
                            Reset();
                        }
                        else
                        {
                            PasswordUtility.Encrypt(passwordBox.Password, out ciphertext, out entropy);
                            PasswordUtility.StorePasswordInRegistry(username, ciphertext, entropy);
                            DatabaseInfo.SetPassword(passwordBox.Password);
                            errormessage.Text = "You have registered successfully.";
                            Reset();
                            mainWindow = new MainWindow();
                            mainWindow.Show();
                            Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void RegistrationWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (loginWindow == null && mainWindow == null)
                {
                    Application.Current.Shutdown();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
    }
}
