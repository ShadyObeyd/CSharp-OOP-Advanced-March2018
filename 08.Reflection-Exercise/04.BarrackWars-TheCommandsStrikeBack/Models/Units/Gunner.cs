namespace _03BarracksFactory.Models.Units
{
    public class Gunner : Unit
    {
        private const int HEALTH = 20;
        private const int ATTACK_DMG = 20;

        public Gunner() : base(HEALTH, ATTACK_DMG)
        {

        }
    }
}