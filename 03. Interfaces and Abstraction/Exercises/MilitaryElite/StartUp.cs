using MilitaryElite.Enums;
using MilitaryElite.Models;

namespace MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            List<Private> privatees = new List<Private>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] tokens = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (tokens[0] == "Private")
                {
                    int privateId = int.Parse(tokens[1]);
                    string privateFirstName = tokens[2];
                    string privateLastName = tokens[3];
                    decimal privateSalary = decimal.Parse(tokens[4]);
                    Private privatee = new Private(privateId, privateFirstName, privateLastName, privateSalary);
                    privatees.Add(privatee);
                    Console.WriteLine(privatee.ToString());
                }
                else if (tokens[0] == "LieutenantGeneral")
                {
                    int lieutenantGeneralId = int.Parse(tokens[1]);
                    string lieutenantGeneralFirstName = tokens[2];
                    string lieutenantGeneralLastName = tokens[3];
                    decimal lieutenantGeneralSalary = decimal.Parse(tokens[4]);
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(lieutenantGeneralId, lieutenantGeneralFirstName,
                        lieutenantGeneralLastName, lieutenantGeneralSalary);

                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int privateId = int.Parse(tokens[i]);
                        var targetSoldier = privatees.FirstOrDefault(p => p.Id == privateId);
                        if (targetSoldier != null)
                        {
                            lieutenantGeneral.AddSoldiers(targetSoldier);
                        }
                    }
                    Console.WriteLine(lieutenantGeneral.ToString());
                }
                else if (tokens[0] == "Engineer")
                {
                    int engineerId = int.Parse(tokens[1]);
                    string engineerFirstName = tokens[2];
                    string engineerLastName = tokens[3];
                    decimal engineerSalary = decimal.Parse(tokens[4]);
                    bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);
                    if (isValidCorps)
                    {
                        Engineer engineer = new Engineer(engineerId, engineerFirstName, engineerLastName, engineerSalary, corps);
                        for (int i = 6; i < tokens.Length - 1; i += 2)
                        {
                            string repairPartName = tokens[i];
                            int repairHoursWorked = int.Parse(tokens[i + 1]);
                            Repair repair = new Repair(repairPartName, repairHoursWorked);
                            engineer.AddRepair(repair);
                        }
                        Console.WriteLine(engineer.ToString());
                    }
                    
                }
                else if (tokens[0] == "Commando")
                {
                    int commandoId = int.Parse(tokens[1]);
                    string commandoFirstName = tokens[2];
                    string commandoLastName = tokens[3];
                    decimal commandoSalary = decimal.Parse(tokens[4]);
                    bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);
                    if (isValidCorps)
                    {
                        Commando commando = new Commando(commandoId, commandoFirstName, commandoLastName, commandoSalary, corps);
                        if(tokens.Length > 6)
                        {
                            for (int i = 6; i < tokens.Length - 1; i += 2)
                            {
                                string missionCodeName = tokens[i];
                                bool isValidMission = Enum.TryParse(tokens[i + 1], out MissionState missionState);
                                if (isValidMission)
                                {
                                    Mission mission = new Mission(missionCodeName, missionState);
                                    commando.AddMission(mission);
                                }
                            }
                        }
                        Console.WriteLine(commando.ToString());
                    }
                }
                else if (tokens[0] == "Spy")
                {
                    int spyId = int.Parse(tokens[1]);
                    string spyFirstName = tokens[2];
                    string spyLastName = tokens[3]; 
                    int spyCodeNumber = int.Parse(tokens[4]);
                    Spy spy = new Spy(spyCodeNumber, spyId, spyFirstName, spyLastName);
                    Console.WriteLine(spy.ToString());
                }
            }
        }
    }
}