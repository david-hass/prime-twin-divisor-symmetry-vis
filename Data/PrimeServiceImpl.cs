using System;

public class PrimeServiceImpl : PrimeService
{
    public Number[] GetNumbers(int start, int end)
    {
        Number[] numbers = new Number[end - start + 1];

        for (int i = start; i <= end; i++)
        {
            numbers[i - start] = DetermineKindOfNumber(i);
        }

        return numbers;
    }



    public NumberWithDivisors[] FindSymmetricDivisorsForPrimeSandwichedNumber(SandwichedByPrimesNumber num)
    {
        int value = num.GetValue();

        NumberWithDivisors sandwichedNumDiv = new NumberWithDivisorsImpl(num, new List<Number>(value / 2));
        List<NumberWithDivisors> leftOfNumber = new List<NumberWithDivisors>(value / 2);
        List<NumberWithDivisors> rightOfNumber = new List<NumberWithDivisors>(value / 2);

        for (int i = 1; ; i++)
        {
            int left = value - i;
            if (left == 0)
            {
                break;
            }
            int right = value + i;

            int leftDivisor = ((left % i) == 0) ? i : -1;
            int rightDivisor = ((right % i) == 0) ? i : -2;


            if (leftDivisor != rightDivisor)
            {
                break;
            }

            Number leftSmallestDivNumber = DetermineKindOfNumber(leftDivisor);

            sandwichedNumDiv.AddDivisors(leftSmallestDivNumber);
            leftOfNumber.Add(new NumberWithDivisorsImpl(new NormalNumberImpl(left), Enumerable.Range(1, leftDivisor).Select(p => (left % p) == 0 ? DetermineKindOfNumber(p) : new NormalNumberImpl(0)).ToList()));
            rightOfNumber.Add(new NumberWithDivisorsImpl(new NormalNumberImpl(right), Enumerable.Range(1, leftDivisor).Select(p => (right % p) == 0 ? DetermineKindOfNumber(p) : new NormalNumberImpl(0)).ToList()));
        }

        leftOfNumber.Reverse();

        var result = leftOfNumber.Concat(new NumberWithDivisors[] { sandwichedNumDiv }).Concat(rightOfNumber).ToArray();

        //Console.WriteLine(string.Join("\n", result.Select(p => string.Join(",", p.GetDivisors().Select(p => p.GetValue())))));

        return result;

    }

    private bool IsPrime(int number)
    {
        if (number <= 1)
            return false;

        if (number == 2)
            return true;

        if (number % 2 == 0)
            return false;

        int sqrt = (int)Math.Sqrt(number);

        for (int i = 3; i <= sqrt; i += 2)
        {
            if (number % i == 0)
                return false;
        }

        return true;
    }

    private bool IsTwinPrime(int number)
    {
        return IsPrime(number) && (IsPrime(number + 2) || IsPrime(number - 2));
    }

    private bool IsSandwichedByPrimes(int number)
    {
        return !IsPrime(number) && (IsPrime(number + 1) && IsPrime(number - 1));
    }

    private Number DetermineKindOfNumber(int i)
    {
        if (IsSandwichedByPrimes(i))
        {
            return new SandwichedByPrimesNumberImpl(i);
        }
        else if (IsTwinPrime(i))
        {
            return new TwinPrimeNumberImpl(i);
        }
        else if (IsPrime(i))
        {
            return new PrimeNumberImpl(i);
        }
        return new NormalNumberImpl(i);
    }


}