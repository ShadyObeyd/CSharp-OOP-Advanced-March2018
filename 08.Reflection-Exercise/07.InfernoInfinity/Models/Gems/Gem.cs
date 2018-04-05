public abstract class Gem : IGem
{
    protected Gem(GemQuality quality, int strengthModifier, int agilityModifier, int vitalityModifier)
    {
        this.Quality = quality;
        this.StreangthModifier = strengthModifier + (int)this.Quality;
        this.AgilityModifier = agilityModifier + (int)this.Quality;
        this.VitalityModifier = vitalityModifier + (int)this.Quality;
    }

    public int StreangthModifier { get; set; }

    public int AgilityModifier { get; set; }

    public int VitalityModifier { get; set; }

    public GemQuality Quality { get; set; }
}