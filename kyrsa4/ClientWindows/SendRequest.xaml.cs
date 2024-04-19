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

namespace kyrsa4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class SendRequest : Window
    {
        public SendRequest()
        {
            InitializeComponent();
            ComboBox123();
        }

        private void Button_Send_Click(object sender, RoutedEventArgs e)
        {
            
            if (GoodsName.Text != "" && GoodsVolume.Text != "" && GoodsWeight.Text != "")
            { 
                good good1 = new good();

                var lastgoodid = DATABASE.entities.goods.OrderByDescending(i => i.goods_id).FirstOrDefault();
                int goodid = lastgoodid.goods_id + 1;

                int userid = UserData.UserID;

                var vol = float.Parse(GoodsVolume.Text);
                var weight = float.Parse(GoodsWeight.Text);
                var goodstype = "";
                if (Nasipnoy.IsChecked == true)
                    goodstype = "насыпной";
                else if (Nasipnoy.IsChecked == false)
                    goodstype = "тарно-штучный";
                var goodsname = GoodsName.Text;
           
            

                good1.goods_id = goodid;
                good1.goods_name = goodsname;
                good1.goods_type = goodstype;
                good1.goods_weight = weight;
                good1.volume = vol;
                good1.user_id = userid;

                DATABASE.entities.goods.Add(good1);
                route route1 = new route();
                var depot_id_fromcity = DATABASE.entities.depots.Where(x => x.depot_name == comboFromCity.Text).FirstOrDefault();
                var deport_id_tocity = DATABASE.entities.depots.Where(x => x.depot_name == comboToCity.Text).FirstOrDefault();

                var lastrouteid = DATABASE.entities.routes.OrderByDescending(x => x.rotue_id).FirstOrDefault();
                int lastroute = lastrouteid.rotue_id + 1;

                route1.fromdepot_id = depot_id_fromcity.depot_id;
                route1.todepot_id = deport_id_tocity.depot_id;
                route1.rotue_id = lastroute;
                DATABASE.entities.routes.Add(route1);
                request request = new request();
                request.goods_id = goodid;
                request.route_id = lastroute;
                request.user_id = UserData.UserID;
                request.requeststatus_id = 1;
                var lastrequest = DATABASE.entities.requests.OrderByDescending(x => x.request_id).FirstOrDefault();
                int lastrequestid = lastrequest.request_id + 1;
                request.request_id = lastrequestid;

                DATABASE.entities.requests.Add(request);
                try
                {
                    DATABASE.entities.SaveChanges();
                    MessageBox.Show("Заявка отправлена!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка отправки" + ex);
                }
            }
            else
            {
                MessageBox.Show("Ошибка заполнения заявки");
            }
        }
        private void ComboBox123()
        {
            var a = DATABASE.entities.depots.ToList();
            comboFromCity.ItemsSource = a;
            comboFromCity.DisplayMemberPath = "depot_name";

            comboToCity.ItemsSource = a;
            comboToCity.DisplayMemberPath = "depot_name";
        }

        private void GoodsWeight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
