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
using System.Drawing;
using System.IO;
using Microsoft.Win32;

namespace kyrsa4.ClientWindows.Registration
{
    /// <summary>
    /// Interaction logic for ClientRegistrationFirmInfo.xaml
    /// </summary>
    public partial class ClientRegistrationFirmInfo : Window
    {
        public ClientRegistrationFirmInfo()
        {
            InitializeComponent();
        }

        private void Continue_Click(object sender, RoutedEventArgs e)
        {


            DataToDB();
            DATABASE.entities.SaveChanges();
            Confirm();
        }
        private byte[] UploadImage()
        {
            byte[] imageData = null;

            // Открываем диалоговое окно выбора файла
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Читаем данные изображения в массив байтов
                    using (FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                    {
                        imageData = new byte[fs.Length];
                        fs.Read(imageData, 0, (int)fs.Length);
                    }

                    MessageBox.Show("Image loaded successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred: {ex.Message}");
                }
            }

            return imageData;
        }
        private void DataToDB()
        {
            string tel = Telephone.Text; //данные из текстбоксов
            string e_mail = Email.Text;
            string firmname = FirmName.Text;
            string firmaddress = FirmAddress.Text;

            var lastuserid = DATABASE.entities.users.OrderByDescending(u => u.user_id).FirstOrDefault();//вытягиваем последний user_id, так как это будет текущий user_id (после регистрации у нас нет следующих user_id(работает, пока база данных только на одном компе))
            var last = DATABASE.entities.clients.OrderByDescending(i => i.client_id).FirstOrDefault();//вытягиваем последний client_id по тому же принципу

            int lastclientid = last.client_id; //последний айди клиента

            client client1 = new client(); //экземпляр объекта клиент, который потом будет передан в базу данных
            client1.client_id = lastclientid + 1;
            client1.email = e_mail;
            client1.telephone = tel;
            client1.user_id = lastuserid.user_id;
            client1.firm_address = firmaddress;
            client1.firm_logo = UploadImage();

            DATABASE.entities.clients.Add(client1); //передача клиента в базу данных
        }
        private void Confirm()
        {
            RegConfirmation regConfirmation = new RegConfirmation();
            regConfirmation.Show();
            this.Close();
        }
    }
}
