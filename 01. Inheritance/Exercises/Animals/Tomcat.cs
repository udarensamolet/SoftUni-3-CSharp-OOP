namespace Animals
{
    public class Tomcat : Cat
    {
        private const string Gender = "male";
        public Tomcat(string name, int age, string gender)
            : base(name, age, Gender)
        {
        }

        public override string ProduceSound()
        {
            return $"MEOW";
        }
    }
}
