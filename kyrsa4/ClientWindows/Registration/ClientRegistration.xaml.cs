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
using System.Windows.Shapes;
using kyrsa4.Misc;
using kyrsa4.ClientWindows;

namespace kyrsa4.ClientWindows
{
    /// <summary>
    /// Interaction logic for ClientRegistration.xaml
    /// </summary>
    public partial class ClientRegistration : Window
    {
        public ClientRegistration()
        {
            InitializeComponent();
        }


        private void ChangeFirmLogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void But_SaveClientData_Click(object sender, RoutedEventArgs e)
        {
            string loginText = TxbLogin.Text;
            string passwordText = PsbPass.Password;
            string reppasswordText = PsbRepeatPass.Password;
            string nameText = ClientNameTextBox.Text;
            string lastnameText = ClientLastnameTextBox.Text;
            string patronymText = ClientPatronymTextBox.Text;
            if (loginText != "" && passwordText != "" && passwordText == reppasswordText && nameText != "" && lastnameText != "" && patronymText != "")
            {
                var lastuserid = DATABASE.entities.users.OrderByDescending(u => u.user_id).FirstOrDefault();
                int last_id = lastuserid.user_id;
                UserData.UserID = last_id + 1;
                Bufer.UserId = last_id + 1;
                Bufer.Login = loginText;
                Bufer.RoleId = 2;
                Bufer.Password = passwordText;
                Bufer.FirstName = nameText;
                Bufer.LastName = lastnameText;
                Bufer.Patronym = patronymText;

                ClientWindows.Registration.ClientRegistrationFirmInfo clientRegistrationFirmInfo = new Registration.ClientRegistrationFirmInfo();
                clientRegistrationFirmInfo.Show();
                this.Close();
            }
            else if (passwordText != reppasswordText)
                MessageBox.Show("Пароли не совпадают");
            else
                MessageBox.Show("Ошибка заполнения");
        }
    }
}
