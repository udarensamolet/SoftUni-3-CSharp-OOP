namespace RandomList
{
    public class RandomList : List<string>
    {
        Random random = new Random();
        public string RandomString()
        {
            int randomNumber = random.Next(0, base.Count - 1);
            string element = base[randomNumber];
            base.RemoveAt(randomNumber);
            return element;
        }
    }
}
