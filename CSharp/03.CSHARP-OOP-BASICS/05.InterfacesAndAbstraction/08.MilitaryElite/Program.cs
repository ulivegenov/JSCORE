using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        HashSet<Soldier> soldiers = new HashSet<Soldier>();
        HashSet<string> soldiersName = new HashSet<string>();
        string input;

        while ((input = Console.ReadLine()) !="End")
        {
            string[] data = input.Split(' ');

            switch (data[0])
            {
                case "Private":
                    Private privateSoldier = new Private(data[2], data[3], data[1], double.Parse(data[4]));
                    soldiersName.Add($"{privateSoldier.FirstName} {privateSoldier.LastName}");
                    if (soldiersName.Count > soldiers.Count)
                    {
                        soldiers.Add(privateSoldier);
                    }
                    break;
                case "Spy":
                    Spy spy = new Spy(data[2], data[3], data[1] ,int.Parse(data[4]));
                    soldiersName.Add($"{spy.FirstName} {spy.LastName}");
                    if (soldiersName.Count > soldiers.Count)
                    {
                        soldiers.Add(spy);
                    }
                    break;
                case "LieutenantGeneral":
                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(data[2], data[3], data[1], double.Parse(data[4]));
                    List<string> ids = data.Skip(5).ToList();
                    foreach (var id in ids)
                    {
                        foreach (IPrivate soldier in soldiers.Where(s => s.Id == id))
                        {
                            lieutenantGeneral.Privates.Add(soldier);
                        }
                    }
                    soldiersName.Add($"{lieutenantGeneral.FirstName} {lieutenantGeneral.LastName}");
                    if (soldiersName.Count > soldiers.Count)
                    {
                        soldiers.Add(lieutenantGeneral);
                    }
                    break;
                case "Engineer":
                    if ((data[5] == "Airforces") || (data[5] == "Marines"))
                    {
                        Engineer engineer = new Engineer(data[2], data[3], data[1], double.Parse(data[4]), data[5]);
                        List<string> repairsAndHours = data.Skip(6).ToList();
                        for (int i = 0; i < repairsAndHours.Count - 1; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Repair repair = new Repair(repairsAndHours[i], int.Parse(repairsAndHours[i + 1]));
                                engineer.Repairs.Add(repair);
                            }
                        }
                        soldiersName.Add($"{engineer.FirstName} {engineer.LastName}");
                        if (soldiersName.Count > soldiers.Count)
                        {
                            soldiers.Add(engineer);
                        };
                    }
                    break;
                case "Commando":
                    if ((data[5] == "Airforces") || (data[5] == "Marines"))
                    {
                        Commando commando = new Commando(data[2], data[3], data[1], double.Parse(data[4]), data[5]);
                        List<string> missions = data.Skip(6).ToList();
                        for (int i = 0; i < missions.Count - 1; i++)
                        {
                            if (i % 2 == 0)
                            {
                                Mission mission = new Mission(missions[i], missions[i + 1]);
                                if ((mission.State == "inProgress") || (mission.State == "Finished"))
                                {
                                    commando.Missions.Add(mission);
                                }
                            }
                        }
                        soldiersName.Add($"{commando.FirstName} {commando.LastName}");
                        if (soldiersName.Count > soldiers.Count)
                        {
                            soldiers.Add(commando);
                        }
                    }
                    break;
            }
        }

        foreach (var soldier in soldiers)
        {
            Console.WriteLine(soldier);
        }
    }
}

