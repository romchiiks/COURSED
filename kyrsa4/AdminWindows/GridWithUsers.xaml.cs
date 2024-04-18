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

namespace kyrsa4.AdminWindows
{
    /// <summary>
    /// Interaction logic for GridWithUsers.xaml
    /// </summary>
    public partial class GridWithUsers : Page
    {
        public GridWithUsers()
        {
            InitializeComponent();

            Loaded += LoadGrid;
        }
        private void LoadGrid(object sender, RoutedEventArgs e)
        {
            /*var query = DATABASE.entities.users.Where(user => user.role_id != 1).Join(DATABASE.entities.clients,user => user.user_id, client => client.user_id, (user, client) => new
                {
                user.user_id,
                user.login,
                user.lastname,
                user.firstname,
                user.patronym,
                client.telephone,
                client.email,
                client.firm_name
                }).ToList();*/

            //GridRequests.ItemsSource = query;

            List<client> clients = new List<client>();

            clients = DATABASE.entities.clients.ToList();

            GridRequests.ItemsSource = clients;
        }

        private void DeleteUser_Click(object sender, RoutedEventArgs e)
        {
            var click = sender as Button;
            client removing = click.DataContext as client;
            var result = MessageBox.Show("Вы уверены?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question); //показал уведомление о том что все хорошо
            if (result == MessageBoxResult.Yes)
            {
                DATABASE.entities.clients.Remove(removing);

                DATABASE.entities.SaveChanges();

                LoadGrid(sender, e);
            }
            else
            {
                return;
            }
        }

        private void EditUser_Click_1(object sender, RoutedEventArgs e)
        {
            var click = sender as Button;
            var userdata = click.DataContext as client;
            var userdata2 = DATABASE.entities.users.Where(i => i.user_id == userdata.user_id).FirstOrDefault();

            if (click != null)
            {
                UserClientData.UserID = userdata.user_id;
                UserClientData.UserLogin = userdata2.login;
                UserClientData.UserLastname = userdata2.lastname;
                UserClientData.UserName = userdata2.firstname;
                UserClientData.UserPatronym = userdata2.patronym;
                UserClientData.UserTel = userdata.telephone;
                UserClientData.UserEmail = userdata.email;
                UserClientData.UserFirmName = userdata.firm_name;
            }

            EditUserWindow editUserWindow = new EditUserWindow();
            editUserWindow.Show();
        }
    }
}
