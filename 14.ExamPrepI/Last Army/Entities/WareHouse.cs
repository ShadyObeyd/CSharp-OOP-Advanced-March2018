using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionQuanities;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionQuanities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (ISoldier soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public void AddAmmunition(string name, int quantity)
    {
        if (this.ammunitionQuanities.ContainsKey(name))
        {
            this.ammunitionQuanities[name] += quantity;
        }
        else
        {
            this.ammunitionQuanities.Add(name, quantity);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        List<string> destroyedWeapons = soldier.Weapons.Where(w => w.Value == null).Select(w => w.Key).ToList();

        bool isSoldierEquiped = true;

        foreach (string weapon in destroyedWeapons)
        {
            if (this.ammunitionQuanities.ContainsKey(weapon) && this.ammunitionQuanities[weapon] > 0)
            {
                IAmmunition ammunition = this.ammunitionFactory.CreateAmmunition(weapon);

                soldier.Weapons[weapon] = ammunition;

                ammunitionQuanities[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }
}