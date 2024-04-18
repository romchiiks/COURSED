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
using MimeKit;
using kyrsa4.Misc;

namespace kyrsa4
{
    /// <summary>
    /// Interaction logic for PassRecovery.xaml
    /// </summary>
    public partial class PassRecovery : Window
    {
        public PassRecovery()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var clientid = DATABASE.entities.clients.Where(c => c.email == EmailTxb.Text).FirstOrDefault();
            var users = DATABASE.entities.users.Where(i => i.user_id == clientid.user_id).FirstOrDefault();

            string pas = users.password;

            SendVerificationCodeByEmail(EmailTxb.Text, pas);

        }
        private void SendVerificationCodeByEmail(string email, string code)
        {
            string subject = "Восстановление пароля";
            string body = $"Ваш пароль: {code}\nС уважением, команда нищих студентов без зарплаты\nПОМОГИТЕ МЫ В РАБСТВЕ НАС МОРЯТ ГОЛОДОМ";
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
                    MessageBox.Show($"Пароль отправлен на адрес: {email}", "Успех!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex);
                }
                finally
                {
                    client.Disconnect(true);
                    this.Close();
                }
            }
        }
    }
}
