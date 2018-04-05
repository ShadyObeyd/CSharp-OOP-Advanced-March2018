public class Axe : Weapon
{
    public Axe(WeaponRarity rarity, string name) : base(5, 10, rarity, name)
    {
        this.Gems = new IGem[4];
    }
}