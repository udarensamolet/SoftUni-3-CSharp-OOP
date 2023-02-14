namespace FootballTeamGenerator
{
    public class Player
    {
        private string _name;
        private int _endurance;
        private int _sprint;
        private int _dribble;
        private int _passing;
        private int _shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name 
        {
            get => _name;
            private set
            {
                if(string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }
                _name = value;
            }
        }

        public int Endurance
        {
            get => _endurance;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Endurance should be between 0 and 100.");
                }
                _endurance = value;
            }
        }
        public int Sprint
        {
            get => _sprint;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Sprint should be between 0 and 100.");
                }
                _sprint = value;
            }
        }
        public int Dribble
        {
            get => _dribble;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Dribble should be between 0 and 100.");
                }
                _dribble = value;
            }
        }
        public int Passing
        {
            get => _passing;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Passing should be between 0 and 100.");
                }
                _passing = value;
            }
        }
        public int Shooting
        {
            get => _shooting;
            private set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentOutOfRangeException($"Shooting should be between 0 and 100.");
                }
                _shooting = value;
            }
        }

        public double OverallSkill
            => Math.Round((Endurance + Sprint + Dribble + Passing + Shooting) / 5.0);
    }
}
