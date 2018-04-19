public class Medium : Mission
{
    private const int ENDURANCE_REQUIRED = 50;
    private const string MISSION_NAME = "Capturing dangerous criminals";
    private const int WEAR_LEVEL_DECREMENT = 50;

    public Medium(double scoreToComplete)
        : base(MISSION_NAME, ENDURANCE_REQUIRED, scoreToComplete, WEAR_LEVEL_DECREMENT)
    {

    }
}