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

namespace kyrsa4.AdminWindows
{
    /// <summary>
    /// Interaction logic for EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow()
        {
            InitializeComponent();

            SurCol.Text = UserClientData.UserLastname;
            NamCol.Text = UserClientData.UserName;
            PatCol.Text = UserClientData.UserPatronym;
            TelCol.Text = UserClientData.UserTel;
            FirCol.Text = UserClientData.UserFirmName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            int userid = UserClientData.UserID;
            var user = DATABASE.entities.users.Where(i => i.user_id == userid).FirstOrDefault();
            if (user != null)
            {
                user.lastname = SurCol.Text;
                user.firstname = NamCol.Text;
                user.patronym = PatCol.Text;
                DATABASE.entities.SaveChanges();
            }
            else
                MessageBox.Show("Ошибка кода!");

            var client = DATABASE.entities.clients.Where(i => i.user_id == userid).FirstOrDefault();
            if (client != null)
            {
                client.telephone = TelCol.Text;
                client.firm_name = FirCol.Text;
                DATABASE.entities.SaveChanges();
            }
            else
                MessageBox.Show("Ошибка кода!");
        }

    }
}
