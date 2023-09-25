namespace HelpDesk_Menagment_Twilo.Models.DataBase
{
    public class Account
    {
        public string AccountID { get; set; }


        public string Login { get; set; }
        public string Password { get; set; }

        public Account()
        {
            this.AccountID = Guid.NewGuid().ToString();
        }
    }
}
