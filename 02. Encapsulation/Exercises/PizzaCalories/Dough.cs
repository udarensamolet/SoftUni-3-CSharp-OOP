namespace PizzaCalories
{
    public class Dough
    {
        private string _flour;
        private string _bakingTechnique;
        private double _grams;


        public Dough(string flour, string bakingTechnique, double grams)
        {
            Flour = flour;
            BakingTechnique = bakingTechnique;
            Grams = grams;
        }

        public string Flour
        {
            get => _flour;
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException($"Invalid type of dough1.");
                }
                _flour = value;
            }
        }

        public string BakingTechnique
        {
            get => _bakingTechnique;
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException($"Invalid type of dough2.");
                }
                _bakingTechnique = value;
            }
        }

        public double Grams
        {
            get => _grams;
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentOutOfRangeException($"Dough weight should be in the range [1..200].");
                }
                _grams = value;
            }
        }

        public double GetCalories()
        {
            double calories = 2;
            double modifierFlour = 0;
            double modifierBakingTechnique = 0;

            if (Flour == "White")
            {
                modifierFlour = 1.5;
            }
            else if (Flour == "Wholegrain")
            {
                modifierFlour = 1;
            }

            if (BakingTechnique == "Crispy")
            {
                modifierBakingTechnique = 0.9;
            }
            else if (BakingTechnique == "Chewy")
            {
                modifierBakingTechnique = 1.1;
            }
            else if (BakingTechnique == "Homemade")
            {
                modifierBakingTechnique = 1;
            }

             return calories = (calories * Grams * modifierFlour * modifierBakingTechnique); 
        }
    }
}