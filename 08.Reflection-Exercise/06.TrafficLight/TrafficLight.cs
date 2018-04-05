public class TrafficLight
{
    private Color color;

    public TrafficLight(Color color)
    {
        this.color = color;
    }

    public void SetColor()
    {
        if (this.color == Color.Green)
        {
            this.color = Color.Yellow;
        }
        else if (this.color == Color.Yellow)
        {
            this.color = Color.Red;
        }
        else if (this.color == Color.Red)
        {
            this.color = Color.Green;
        }
    }

    public override string ToString()
    {
        return $"{this.color}";
    }
}