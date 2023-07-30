public interface Number
{
    public int GetValue();
    public NumberType GetNumberType();
}

public abstract class SandwichedByPrimesNumber : Number
{
    public abstract int GetValue();

    public NumberType GetNumberType()
    {
        return NumberType.SandwichedByPrimes;
    }

}