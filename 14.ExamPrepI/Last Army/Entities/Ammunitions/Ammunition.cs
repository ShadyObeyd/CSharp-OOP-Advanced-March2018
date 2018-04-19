public abstract class Ammunition : IAmmunition
{
    private const int WEAR_LEVEL_MULTIPLIER = 100;

    protected Ammunition(double weight)
    {
        this.Weight = weight;
        this.WearLevel = this.Weight * WEAR_LEVEL_MULTIPLIER;
    }

    public string Name => this.GetType().Name;

    public double Weight { get; protected set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}