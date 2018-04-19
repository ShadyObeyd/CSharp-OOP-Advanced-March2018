using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OVERALL_SKILL_MULTIPLIER = 2.5;
    private IReadOnlyList<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(Helmet),
        nameof(Knife)
    };

    public Corporal(string name, int age, double experience, double endurance) 
        : base(name, age, experience, endurance)
    {

    }

    protected override double OverallSkillMultiplier => OVERALL_SKILL_MULTIPLIER;

    protected override IReadOnlyList<string> WeaponsAllowed => this.weaponsAllowed;
}