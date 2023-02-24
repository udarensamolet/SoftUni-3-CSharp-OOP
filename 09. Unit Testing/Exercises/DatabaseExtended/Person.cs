namespace ExtendedDatabase
{
    public class Person
    {
        private long _id;
        private string _userName;

        public Person(long id, string userName)
        {
            Id = id;
            UserName = userName;
        }

        public string UserName
        {
            get { return _userName; }
            private set { _userName = value; }
        }

        public long Id
        {
            get { return _id; }
            private set { _id = value; }
        }
    }
}
