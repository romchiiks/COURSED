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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void But_SaveClientData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ChangeFirmLogo_Click(object sender, RoutedEventArgs e)
        {

        }

        private void But_ReturnToHub_Click(object sender, RoutedEventArgs e)
        {
            ClientHub clientHub = new ClientHub();
            clientHub.Show();
            this.Close();
        }
    }
}
