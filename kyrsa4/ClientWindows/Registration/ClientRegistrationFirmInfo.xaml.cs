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
using MimeKit;

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
            if (Email_Confirm.Text == CodeEmail.ConfCode)
            {
                string tel = Telephone.Text; //данные из текстбоксов
                string e_mail = Email.Text;
                string firmname = FirmName.Text;

                int lastclientid;

                var lastuserid = DATABASE.entities.users.OrderByDescending(u => u.user_id).FirstOrDefault();//вытягиваем последний user_id, так как это будет текущий user_id (после регистрации у нас нет следующих user_id(работает, пока база данных только на одном компе))
                var last = DATABASE.entities.clients.OrderByDescending(i => i.client_id).FirstOrDefault();//вытягиваем последний client_id по тому же принципу
                if (last == null)
                    lastclientid = 0;
                else
                    lastclientid = last.client_id; //последний айди клиента

                client client1 = new client(); //экземпляр объекта клиент, который потом будет передан в базу данных
                client1.client_id = lastclientid + 1;
                client1.email = e_mail;
                client1.telephone = tel;
                client1.user_id = lastuserid.user_id;
                client1.firm_name = firmname;

                user user1 = new user();
                user1.user_id = Bufer.UserId;
                user1.role_id = Bufer.RoleId;
                user1.login = Bufer.Login;
                user1.password = Bufer.Password;
                user1.firstname = Bufer.FirstName;
                user1.lastname = Bufer.LastName;
                user1.patronym = Bufer.Patronym;

                DATABASE.entities.users.Add(user1);
                DATABASE.entities.clients.Add(client1);

                DATABASE.entities.SaveChanges();

                ClientHub clientHub = new ClientHub();
                clientHub.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Неверный код подтверждения!");
            }
        }

        private void SendEmail_Click(object sender, RoutedEventArgs e)
        {
            Random r = new Random();
            string code = "";
            for (int i = 0; i < 5; i++)
            {
                int a = r.Next(0, 9);
                code += a;
            }

            CodeEmail.ConfCode = code;

            SendVerificationCodeByEmail(Email.Text, code);

        }
        private void SendVerificationCodeByEmail(string email, string code)
        {
            string subject = "ПОДТВЕРЖДЕНИЕ РЕГИСТРАЦИИ";
            string body = $"Ваш код подтверждения: {code}\nС уважением, команда нищих студентов без зарплаты\nПОМОГИТЕ МЫ В РАБСТВЕ НАС МОРЯТ ГОЛОДОМ";
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Александр Кристинович", "helper.subd@mail.ru"));
            message.To.Add(new MailboxAddress("Получатель", email));
            message.Subject = subject;
            message.Body = new TextPart("plain") { Text = body };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("helper.subd@mail.ru", "2AwpDQ1Jcy48XuYkqp3i");
                try
                {
                    client.Send(message);
                    MessageBox.Show($"Соощение отправлено на адрес: {email}", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }
    }
}
