public class Hard : Mission
{
    private const int ENDURANCE_REQUIRED = 80;
    private const string MISSION_NAME = "Disposal of terrorists";
    private const int WEAR_LEVEL_DECREMENT = 70;

    public Hard(double scoreToComplete) 
        : base(MISSION_NAME, ENDURANCE_REQUIRED, scoreToComplete, WEAR_LEVEL_DECREMENT)
    {

    }
}