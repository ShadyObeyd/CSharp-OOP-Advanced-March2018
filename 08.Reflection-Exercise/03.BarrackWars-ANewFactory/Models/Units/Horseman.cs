namespace _03BarracksFactory.Models.Units
{
    public class Horseman : Unit
    {
        private const int HEALTH = 50;
        private const int ATTACK_DMG = 10;

        public Horseman() : base(HEALTH, ATTACK_DMG)
        {

        }
    }
}