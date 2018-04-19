using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double MAX_ENDURANCE = 100;
    private const int REGENERATION_INCREASE = 10;
    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }
    }

    protected virtual int RegenerationIncrease => REGENERATION_INCREASE + this.Age;

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; protected set; }

    public string Name { get; protected set; }

    public int Age { get; protected set; }

    public double Experience { get; protected set; }

    public double Endurance
    {
        get
        {
            return this.endurance;
        }
        protected set
        {
            this.endurance = Math.Min(value, MAX_ENDURANCE);
        }
    }

    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (this.Age + this.Experience) * this.OverallSkillMultiplier;

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.All(w => w != null);

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.All(w => w.WearLevel > 0);
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public void Regenerate()
    {
        this.Endurance += this.RegenerationIncrease;
    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}