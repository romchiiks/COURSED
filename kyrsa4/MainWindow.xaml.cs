using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using kyrsa4.Misc;
using kyrsa4.ClientWindows;
using kyrsa4.AdminWindows;

namespace kyrsa4
{
    /// <summary>
    /// Interaction logic for Auth.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButLogin_Click(object sender, RoutedEventArgs e)
        {
            var logCount = 0;
            var logintext = txbLogin.Text;
            var passwordpass = psbPassword.Password;
            if (logCount == 3)
            {
                //сюда вписать блокировку кнопок. или ввод капчи
            }
            else
            {
                var user = DATABASE.entities.users.Where(i => i.login == txbLogin.Text && i.password == psbPassword.Password).FirstOrDefault();
                if (logintext == "")
                {
                    MessageBox.Show("Вы не ввели логин пользователя");
                    logCount = +1;
                }
                else if (passwordpass == "")
                {
                    MessageBox.Show("Вы не ввели пароль пользователя");
                    logCount = +1;
                }
                else if (user == null)
                {
                    MessageBox.Show("Неправильный логин или пароль!");
                }
                else
                {
                    if (logintext != user.login)
                    {
                        MessageBox.Show("Вы ввели не верный логин пользователя");
                        logCount = +1;
                    }
                    else if (passwordpass != user.password)
                    {
                        MessageBox.Show("Вы ввели не верный логин пользователя");
                        logCount = +1;
                    }
                    else
                    {
                        if (user.role_id == 1)
                        {
                            AdminRequests adminRequests = new AdminRequests();
                            adminRequests.Show();
                            this.Close();

                        }
                        else if (user.role_id == 2)
                        {
                            ClientHub clientHub = new ClientHub();
                            clientHub.Show();
                            this.Close();
                        }
                        /* else if (user.role_id == 3)
                        {
                            //авторизация сотрудника
                        } */
                    }
                }
            }

        }


        private void ButReg_Click(object sender, RoutedEventArgs e)
        {
            ClientRegistration clientRegistration = new ClientRegistration();
            clientRegistration.Show();
            this.Close();
        }

        private void ForgorPassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
