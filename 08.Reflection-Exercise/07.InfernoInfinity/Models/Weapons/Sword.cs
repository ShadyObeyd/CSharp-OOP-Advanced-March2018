public class Sword : Weapon
{
    public Sword(WeaponRarity rarity, string name) : base(4, 6, rarity, name)
    {
        this.Gems = new IGem[3];
    }
}