public interface IGem
{
    int StreangthModifier { get; set; }
    int AgilityModifier { get; set; }
    int VitalityModifier { get; set; }
    GemQuality Quality { get; set; }
}