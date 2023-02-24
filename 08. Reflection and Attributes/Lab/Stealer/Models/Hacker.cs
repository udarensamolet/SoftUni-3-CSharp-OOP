namespace Stealer.Models
{
    public class Hacker
    {
        public string _username = "securityGod82";
        private string _password = "mySuperSecretPassw0rd";

        public string Password
        {
            get => _password;
            set => _password = value;
        }

        private int Id { get; set; }

        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {
        }
    }

}
