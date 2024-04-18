using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kyrsa4.Misc
{
    public partial class Bufer
    {
        /*string loginText = TxbLogin.Text;
        string passwordText = PsbPass.Password;
        string reppasswordText = PsbRepeatPass.Password;
        string nameText = ClientNameTextBox.Text;
        string lastnameText = ClientLastnameTextBox.Text;
        string patronymText = ClientPatronymTextBox.Text;
        
        client1.client_id = lastclientid + 1;
                client1.email = e_mail;
                client1.telephone = tel;
                client1.user_id = lastuserid.user_id;
                client1.firm_name = firmname;
         */
        public static int UserId { get; set; }
        public static int RoleId { get; set; }
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string FirstName { get; set; }
        public static string LastName { get; set; }
        public static string Patronym { get; set; }
        public static int ClientId { get; set; }
        public static string Email { get; set; }
        public static string Telephone { get; set; }
        public static string FirmName { get; set; }
    }
}
