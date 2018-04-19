public interface IWareHouse
{
    void EquipArmy(IArmy army);

    void AddAmmunition(string name, int quantity);

    bool TryEquipSoldier(ISoldier soldier);
}