using BiblioBalobanovOros.ClassFolder;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace BiblioBalobanovOros.WindowFolder
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        SqlConnection sqlConnection =
               new SqlConnection(App.ConnectionBD());
        SqlCommand sqlCommand;
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void RegistrationBtn_Click(object sender, RoutedEventArgs e)
        {
            string pass = PasswordPsb.Password;
            string zagl = "QWERTYUIOPASDFGHJKLZXCVBNM";
            string mal = "qwertyuiopasdfghjklzxcvbnm";
            string cif = "1234567890";
            string znak = "!@#$%^&*()_+";
            if (string.IsNullOrWhiteSpace(LoginTB.Text))
            {
                MBClass.ErrorMB("Вы не ввели логин");
                LoginTB.Focus();
            }
            else if (string.IsNullOrWhiteSpace(PasswordPsb.Password))
            {
                MBClass.ErrorMB("Вы не ввели пароль");
                PasswordPsb.Focus();
            }
            else if (string.IsNullOrWhiteSpace(ReapetPasswordPsb.Password))
            {
                MBClass.ErrorMB("Вы не ввели повторно пароль");
                ReapetPasswordPsb.Focus();
            }
            else if (zagl.IndexOfAny(pass.ToCharArray())==-1)
            {
                MBClass.ErrorMB("Пароль должен содержать заглавную букву");
                PasswordPsb.Focus();
            }
            else if (mal.IndexOfAny(pass.ToCharArray())==-1)
            {
                MBClass.ErrorMB("Пароль должен содержать строчную букву");
                PasswordPsb.Focus();
            }
            else if (cif.IndexOfAny(pass.ToCharArray())==-1)
            {
                MBClass.ErrorMB("Пароль должен содержать цифру");
                PasswordPsb.Focus();
            }
            else if (znak.IndexOfAny(pass.ToCharArray())==-1)
            {
                MBClass.ErrorMB("Пароль должен содержать " +
                    "один из символов" + znak);
                PasswordPsb.Focus();
            }
            else if (PasswordPsb.Password != ReapetPasswordPsb.Password)
            {
                MBClass.ErrorMB("Пароль не совпадают");
                ReapetPasswordPsb.Focus();
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    sqlCommand = new SqlCommand("INSERT INTO dbo.[User] " +
                        "(LoginUser, PasswordUser, IdRole) VALUES " +
                        $"('{LoginTB.Text}', '{PasswordPsb.Password}', 3)", 
                        sqlConnection);
                    sqlCommand.ExecuteNonQuery();
                    MBClass.InfoMB("Вы успешно зарегистрировались");
                }
                catch (Exception ex)
                {
                    MBClass.ErrorMB(ex);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }

        private void RegistrationTB_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void CloseIm_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            MBClass.ExitMB();
        }
    }
}
