namespace FootballTeamGenerator
{
    public class StartUp
    {
        static void Main()
        {
            List<Team> teams = new List<Team>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "END") 
                {
                    break;
                }

                string[] tokens = input
                    .Split(';', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();


                if (tokens[0] == "Team")
                {
                    string teamName = tokens[1];
                    Team team = new Team(teamName);
                    teams.Add(team);
                }
                else if (tokens[0] == "Add")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];
                    int playerEndurance = int.Parse(tokens[3]);
                    int playerSprint = int.Parse(tokens[4]);
                    int playerDribble = int.Parse(tokens[5]);
                    int playerPassing = int.Parse(tokens[6]);
                    int playerShooting = int.Parse(tokens[7]);

                    var targetTeam = teams.FirstOrDefault(t => t.Name == teamName);
                    if(targetTeam != null)
                    {
                        targetTeam.AddPlayer(playerName, playerEndurance, playerSprint, playerDribble, playerPassing, playerShooting);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (tokens[0] == "Remove")
                {
                    string teamName = tokens[1];
                    string playerName = tokens[2];

                    var targetTeam = teams.FirstOrDefault(t => t.Name == teamName);
                    if (targetTeam != null)
                    {
                        targetTeam.RemovePlayer(playerName);
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
                else if (tokens[0] == "Rating")
                {
                    string teamName = tokens[1];
                    var targetTeam = teams.FirstOrDefault(t => t.Name == teamName);
                    if (targetTeam != null)
                    {
                        Console.WriteLine($"{targetTeam.GetRating():f1}");
                    }
                    else
                    {
                        Console.WriteLine($"Team {teamName} does not exist.");
                    }
                }
            }
        }
    }
}