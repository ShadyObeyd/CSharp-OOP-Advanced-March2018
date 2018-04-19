public abstract class Mission : IMission
{
    protected Mission(string name, double enduranceRequired, double scoreToComplete, double wearLevelDecrement)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public string Name { get; protected set; }

    public double EnduranceRequired { get; protected set; }

    public double ScoreToComplete { get; protected set; }

    public double WearLevelDecrement { get; protected set; }
}