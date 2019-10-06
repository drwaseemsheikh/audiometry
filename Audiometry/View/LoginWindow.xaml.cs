using System;
using System.Windows;
using Audiometry.Security;

namespace Audiometry.View
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private MainWindow mainWindow;
        private RegistrationWindow registerWindow;

        public LoginWindow()
        {
            try
            {
                InitializeComponent();
                mainWindow = null;
                registerWindow = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
                Application.Current.Shutdown();
            }
        }

        public void Reset()
        {
            try
            {
                usernameTxt.Text = string.Empty;
                passwordBox.Password = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            LoginErrTxtBlk.Text = "";

            try
            {
                string storedUsername;
                byte[] storedCiphertext;
                byte[] storedEntropy;

                if (!PasswordUtility.RetrievePasswordFromRegistry(out storedUsername, out storedCiphertext, out storedEntropy))
                {
                    LoginErrTxtBlk.Text = "No username and password stored in the registry. Register first.";
                    Reset();
                }
                else
                {
                    if (PasswordUtility.Verify(usernameTxt.Text, passwordBox.Password))
                    {
                        LoginErrTxtBlk.Text = "Login successful";
                        mainWindow = new MainWindow();
                        mainWindow.Show();
                        Close();     
                    }
                    else
                    {
                        LoginErrTxtBlk.Text = "Incorrect username and/or password. Try again.";
                        Reset();
                    }
                }               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void RegisterLink_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                registerWindow = new RegistrationWindow();
                registerWindow.Show();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void LoginWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                if (registerWindow == null && mainWindow == null)
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
