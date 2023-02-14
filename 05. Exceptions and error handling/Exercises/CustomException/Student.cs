namespace CustomException
{
    public class Student
    {
        private string _name;

        public Student(string name, string email)
        {
            Name = name;
            Email = email;
        }
        
        public string Name 
        {
            get => _name;
            private set
            {
                for (int i = 0; i < value.Length; i++)
                {
                    if (!char.IsLetter(value[i]))
                    {
                        throw new InvalidPersonNameException(value, "Special characters and/or numbers not allowed!");
                    }
                }
                _name = value;
            }
        }
        public string Email { get; private set; }   
    }
}
