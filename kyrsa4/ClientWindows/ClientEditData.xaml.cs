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

namespace kyrsa4.ClientWindows
{
    /// <summary>
    /// Interaction logic for ClientEditData.xaml
    /// </summary>
    public partial class ClientEditData : Window
    {
        public ClientEditData()
        {
            InitializeComponent();

            var userdata = DATABASE.entities.users.Where(u => u.user_id == UserData.UserID).FirstOrDefault();
            var clientdata = DATABASE.entities.clients.Where(c => c.user_id == UserData.UserID).FirstOrDefault();
            SurCol.Text = userdata.lastname;
            NamCol.Text = userdata.firstname;
            PatCol.Text = userdata.patronym;
            TelCol.Text = clientdata.telephone;
            FirCol.Text = clientdata.firm_name;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int userid = UserClientData.UserID;
            ClientHub clientHub = new ClientHub();
            if (SurCol.Text != "" && NamCol.Text != "" && PatCol.Text != "" && SurCol.Text.Length > 1 && NamCol.Text.Length > 1 && PatCol.Text.Length > 1 && TelCol.Text != "" && FirCol.Text != "")
            {
                var user = DATABASE.entities.users.Where(i => i.user_id == userid).FirstOrDefault();
                if (user != null)
                {
                    user.lastname = SurCol.Text;
                    user.firstname = NamCol.Text;
                    user.patronym = PatCol.Text;
                    DATABASE.entities.SaveChanges();
                    clientHub.Show();
                    this.Close();
                }
                else
                    MessageBox.Show("Ошибка кода!");
            }
            var client = DATABASE.entities.clients.Where(i => i.user_id == userid).FirstOrDefault();
            if (client != null)
            {
                client.telephone = TelCol.Text;
                client.firm_name = FirCol.Text;
                DATABASE.entities.SaveChanges();
                clientHub.Show();
                this.Close();
            }
            else
                MessageBox.Show("Ошибка кода!");
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            ClientHub clientHub = new ClientHub();
            clientHub.Show();
            this.Close();
        }
    }
}
