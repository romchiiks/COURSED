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
            int userid = UserData.UserID;
            var requests = DATABASE.entities.requests.Where(r => r.user_id == userid).Join(DATABASE.entities.goods,
                          req => req.goods_id,
                          goods => goods.goods_id,
                          (req, goods) => new { Request = req, Goods = goods }).Join(DATABASE.entities.request_status,combined => combined.Request.requeststatus_id,
                          status => status.requeststatus_id,
                          (combined, status) => new RequestDetails { IdRequest = combined.Request.request_id, GoodsName = combined.Goods.goods_name, RequestStatus = status.request_status1}).ToList();
            //request id
            
            //goods name
            //request status
            ListView1.ItemsSource = requests;
        }
        public class RequestDetails
        {
            public int IdRequest { get; set; }
            public string GoodsName { get; set; }
            public string RequestStatus { get; set; }
        }
    }
}
