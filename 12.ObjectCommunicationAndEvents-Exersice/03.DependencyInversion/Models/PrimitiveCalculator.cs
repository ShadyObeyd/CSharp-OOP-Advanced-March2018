public class PrimitiveCalculator
{
    private ICalculatable strategy;

    public PrimitiveCalculator()
    {
        this.strategy = new AdditionStrategy();
    }

    public void ChangeStrategy(ICalculatable strategy)
    {
        this.strategy = strategy;
    }

    public int PerformCalculation(int firstOperand, int secondOperand)
    {
        return this.strategy.Calculate(firstOperand, secondOperand);
    }
}