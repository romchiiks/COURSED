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
using kyrsa4.ClientWindows;

namespace kyrsa4.ClientWindows
{
    /// <summary>
    /// Interaction logic for ClientHub.xaml
    /// </summary>
    public partial class ClientHub : Window
    {
        public ClientHub()
        {
            InitializeComponent();
        }

        private void Button_MyRequests_Click(object sender, RoutedEventArgs e)
        {
            ClientRequests clientRequests = new ClientRequests();
            clientRequests.Show();
        }

        private void Button_SendRequest_Click(object sender, RoutedEventArgs e)
        {
            SendRequest send = new SendRequest();
            send.Show();
        }

        private void Button_EditProfile_Click(object sender, RoutedEventArgs e)
        {
            ClientEditData clientEditData = new ClientEditData();
            clientEditData.Show();
            this.Close();
        }

        private void Button_ExitProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void Button_TerminateSession_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
