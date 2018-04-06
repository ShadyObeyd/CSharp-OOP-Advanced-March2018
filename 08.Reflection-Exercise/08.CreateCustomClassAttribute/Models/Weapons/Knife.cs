public class Knife : Weapon
{
    public Knife(WeaponRarity rarity, string name) : base(3, 4, rarity, name)
    {
        this.Gems = new IGem[2];
    }
}