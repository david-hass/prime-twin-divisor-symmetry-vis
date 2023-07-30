public abstract class NumberImpl : Number
{
    private int value;
    private NumberType type;

    public NumberImpl(int value, NumberType type)
    {
        this.value = value;
        this.type = type;
    }

    public int GetValue()
    {
        return value;
    }

    public NumberType GetNumberType()
    {
        return type;
    }
}

public class NormalNumberImpl : NumberImpl
{
    public NormalNumberImpl(int value) : base(value, NumberType.Normal) { }
}

public class PrimeNumberImpl : NumberImpl
{
    public PrimeNumberImpl(int value) : base(value, NumberType.Prime) { }
}

public class TwinPrimeNumberImpl : NumberImpl
{
    public TwinPrimeNumberImpl(int value) : base(value, NumberType.TwinPrime) { }
}

public class SandwichedByPrimesNumberImpl : SandwichedByPrimesNumber, Number
{
    private int value;
    public SandwichedByPrimesNumberImpl(int value)
    {
        this.value = value;
    }

    public override int GetValue()
    {
        return value;
    }
}