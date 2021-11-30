using System.Numerics;

namespace Working.With.Numbers;
public static class WorkingWithNumbers
{
    public static void Run()
    {
        var largest = ulong.MaxValue;

        Console.WriteLine($"largest {largest,40:N0}");

        var atomsInTheUniverse = BigInteger.Parse("123456789012345678901234567890");

        Console.WriteLine($"atomsInTheUniverse {atomsInTheUniverse,40:N0}");
    }

}
