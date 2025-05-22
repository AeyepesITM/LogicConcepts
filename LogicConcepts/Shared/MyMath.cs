namespace Shared;

public class MyMath
{
    public static double Factorial(int n)
    {
        if (n < 0)
        {
            throw new ArgumentException("El número debe ser mayor o igual a cero.");
        }
        if (n == 0 || n == 1)
        {
            return 1;
        }
        return n * Factorial(n - 1);
    }
}