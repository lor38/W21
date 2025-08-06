namespace W21
{
    public class User
    {
        private List<int> scores = new List<int>();
        private string nane;

        public string Login { get; set; }
        public string Password { get; set; }

        public User(string login, string password)
        {
            this.Login = login;
            this.Password = password;
        }

        public User(string nane)
        {
            this.nane = nane;
        }

        public int Result
        {
            get
            {
                return this.scores.Sum();
            }
        }

        public void AddScore(int number)
        {
            this.scores.Add(number);
        }
    }
}
