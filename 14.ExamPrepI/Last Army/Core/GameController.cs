using System;
using System.Linq;

public class GameController
{
    private IArmy army;
    private IWareHouse wareHouse;
    private MissionController missionController;
    private ISoldierFactory soldierFactory;
    private IMissionFactory missionFactory;
    private IWriter writer;

    public GameController(IWriter writer)
    {
        this.army = new Army();
        this.wareHouse = new WareHouse();
        this.missionController = new MissionController(this.army, this.wareHouse);
        this.soldierFactory = new SoldierFactory();
        this.missionFactory = new MissionFactory();
        this.writer = writer;
    }

    public void GiveInputToGameController(string input)
    {
        string[] data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            if (data[1] == "Regenerate")
            {
                army.RegenerateTeam(data[2]);
            }
            else
            {
                string soldierType = data[1];
                string name = data[2];
                int age = int.Parse(data[3]);
                double experience = double.Parse(data[4]);
                double endurance = double.Parse(data[5]);

                ISoldier soldier = this.soldierFactory.CreateSoldier(soldierType, name, age, experience, endurance);

                if (this.wareHouse.TryEquipSoldier(soldier))
                {
                    this.army.AddSoldier(soldier);
                }
                else
                {
                    throw new ArgumentException(string.Format(OutputMessages.SoldierNotAdded, soldier.GetType().Name, soldier.Name));
                }
            }

        }
        else if (data[0].Equals("WareHouse"))
        {
            string name = data[1];
            int count = int.Parse(data[2]);

            this.wareHouse.AddAmmunition(name, count);
        }
        else if (data[0].Equals("Mission"))
        {
            string missionType = data[1];
            double neededPoints = double.Parse(data[2]);

            IMission mission = this.missionFactory.CreateMission(missionType, neededPoints);

            this.writer.AppendLine(this.missionController.PerformMission(mission).Trim());
        }
    }

    public void RequestResult()
    {
        this.missionController.FailMissionsOnHold();

        writer.AppendLine(OutputMessages.Results);
        writer.AppendLine(string.Format(OutputMessages.SuccessfulMissionsCount, this.missionController.SuccessMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.FailedMissionsCount, this.missionController.FailedMissionCounter));
        writer.AppendLine(string.Format(OutputMessages.Soldiers));

        foreach (ISoldier soldier in this.army.Soldiers.OrderByDescending(s => s.OverallSkill))
        {
            writer.AppendLine(soldier.ToString());
        }
    }
}