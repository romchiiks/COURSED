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
using System.Collections.ObjectModel;
using kyrsa4.Misc;
using System.Data.Entity;

namespace kyrsa4.AdminWindows
{
    /// <summary>
    /// Interaction logic for AdminRequests.xaml
    /// </summary>
    public partial class AdminRequests : Window
    {
        Page page1 = new GridWithRequests();
        Page page2 = new GridWithUsers();
        public AdminRequests()
        {
            InitializeComponent();
        }
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(page2);
        }

        private void RequestRB_Checked(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(page1);
        }
    }
}
