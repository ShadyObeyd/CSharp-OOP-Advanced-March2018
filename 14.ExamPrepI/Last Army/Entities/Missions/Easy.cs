public class Easy : Mission
{
    private const int ENDURANCE_REQUIRED = 20;
    private const string MISSION_NAME = "Suppression of civil rebellion";
    private const int WEAR_LEVEL_DECREMENT = 30;

    public Easy(double scoreToComplete) 
        : base(MISSION_NAME, ENDURANCE_REQUIRED, scoreToComplete, WEAR_LEVEL_DECREMENT)
    {

    }
}