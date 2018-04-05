public abstract class Weapon : IWeapon
{
    protected Weapon(int baseMinDmg, int baseMaxDmg, WeaponRarity rarity, string name)
    {
        this.Rarity = rarity;
        this.BaseMinDmg = baseMinDmg * (int)this.Rarity;
        this.BaseMaxDmg = baseMaxDmg * (int)this.Rarity;
        this.Name = name;
    }

    public string Name { get; set; }

    public int BaseMinDmg { get; set; }

    public int BaseMaxDmg { get; set; }

    public IGem[] Gems { get; set; }

    public int Stregth { get; set; }

    public int Agility { get; set; }

    public int Vitality { get; set; }

    public WeaponRarity Rarity { get; set; }

    public void Modify(IGem gem)
    {
        this.Stregth += gem.StreangthModifier;
        this.Agility += gem.AgilityModifier;
        this.Vitality += gem.VitalityModifier;

        this.BaseMinDmg += (gem.StreangthModifier * 2) + gem.AgilityModifier;
        this.BaseMaxDmg += (gem.StreangthModifier * 3) + (gem.AgilityModifier * 4);
    }

    public void DegradeWeapon(IGem gem)
    {
        this.BaseMinDmg -= (gem.StreangthModifier * 2) + gem.AgilityModifier;
        this.BaseMaxDmg -= (gem.StreangthModifier * 3) + (gem.AgilityModifier * 4);

        this.Stregth -= gem.StreangthModifier;
        this.Agility -= gem.AgilityModifier;
        this.Vitality -= gem.VitalityModifier;
    }

    public override string ToString()
    {
        return $"{this.Name}: {this.BaseMinDmg}-{this.BaseMaxDmg} Damage, +{this.Stregth} Strength, +{this.Agility} Agility, +{this.Vitality} Vitality";
    }
}