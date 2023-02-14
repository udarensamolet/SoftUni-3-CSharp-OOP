namespace CustomException
{
    public class InvalidPersonNameException : Exception
    {
        public InvalidPersonNameException() 
        {
        }

        public InvalidPersonNameException(string name, string message) : 
            base(message)
        {
            Name = name;
        }

        public string Name { get; }
    }
}
