public interface IWeapon
{
    string Name { get; set; }
    int BaseMinDmg { get; set; }
    int BaseMaxDmg { get; set; }
    IGem[] Gems { get; set; }
    int Stregth { get; set; }
    int Agility { get; set; }
    int Vitality { get; set; }
    WeaponRarity Rarity { get; set;}

    void Modify(IGem gem);
    void DegradeWeapon(IGem gem);
}