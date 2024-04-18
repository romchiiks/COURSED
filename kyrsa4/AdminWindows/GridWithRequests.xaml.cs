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
    /// Interaction logic for GridWithRequests.xaml
    /// </summary>
    public partial class GridWithRequests : Page
    {
        public GridWithRequests()
        {
            InitializeComponent();

            Loaded += LoadGrid;
        }
        private void ChangeStatus(object sender, RoutedEventArgs e)
        {
            var click = sender as Button;
            var request1 = click.DataContext as request;
            if (click != null)
            {
                if (click.Name == "AcceptButton")
                {
                    request1.requeststatus_id = 2;
                    DATABASE.entities.SaveChanges();
                    MessageBox.Show("Завяка одобрена");
                    LoadGrid(sender, e);
                }
                else if (click.Name == "RejectButton")
                {
                    request1.requeststatus_id = 3;
                    DATABASE.entities.SaveChanges();
                    MessageBox.Show("Заявка отклонена");
                    LoadGrid(sender, e);
                }
            }
        }
        private void LoadGrid(object sender, RoutedEventArgs e)
        {
            List<request> requests = new List<request>();

            requests = DATABASE.entities.requests.Where(i => i.request_id != 1).ToList();

            GridRequests.ItemsSource = requests;
        }

        private void FinderTxb_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}

