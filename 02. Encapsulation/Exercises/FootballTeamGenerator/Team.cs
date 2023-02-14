using System.Numerics;

namespace FootballTeamGenerator
{
    public class Team
    {
        private List<Player> _players;
        private double _rating;

        public Team(string name)
        {
            Name = name;
            _players = new List<Player>();
        }


        public string Name { get; private set; }

        public int PlayersCount => _players.Count;

        public double Rating
        {
            get
            {
                double sumRatings = 0;
                foreach (var player in _players)
                {
                    sumRatings += player.OverallSkill;
                }
                return _rating = sumRatings / _players.Count;

            }
        }

        public void AddPlayer(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            var newPlayer = new Player(name, endurance, sprint, dribble, passing, shooting);
            _players.Add(newPlayer);
        }

        public void RemovePlayer(string name)
        {
            var targetPlayer = _players.FirstOrDefault(p => p.Name == name);
            if (targetPlayer != null)
            {
                _players.Remove(targetPlayer);
            }
            else
            {
                Console.WriteLine($"Player {name} is not in {Name} team.");
            }
        }

        public string GetRating()
        {
            return Rating.ToString();
        }
    }
}
