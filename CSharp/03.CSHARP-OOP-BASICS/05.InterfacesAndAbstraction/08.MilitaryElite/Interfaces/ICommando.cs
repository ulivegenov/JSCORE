using System;
using System.Collections.Generic;
using System.Text;


public interface ICommando
{
    HashSet<IMission> Missions { get; set; }

    HashSet<IMission> CompleteMission(string missionName, HashSet<IMission> missions);
}

