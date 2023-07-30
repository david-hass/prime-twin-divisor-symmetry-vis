public class NumberWithDivisorsImpl : NumberWithDivisors
{
    private Number number;
    private List<Number> divisors;

    public NumberWithDivisorsImpl(Number num, List<Number>? divisors)
    {
        this.number = num;
        this.divisors = divisors ?? new List<Number>((int)Math.Sqrt(num.GetValue()));
    }


    public Number GetNumber()
    {
        return number;
    }

    public List<Number> GetDivisors()
    {
        return divisors;
    }

    public void AddDivisors(Number divisor)
    {
        divisors.Add(divisor);
    }
}