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
    /// Interaction logic for ClientRequests.xaml
    /// </summary>
    public partial class ClientRequests : Window
    {
        public ClientRequests()
        {
            InitializeComponent();

            Loaded += LoadGrid;
        }
        private void LoadGrid(object sender, RoutedEventArgs e)
        {
            List<request> requests = new List<request>();

            requests = DATABASE.entities.requests.Where(i => i.request_id != 1 && i.user_id == UserData.UserID).ToList();

            ListView1.ItemsSource = requests;
        }
    }
}
