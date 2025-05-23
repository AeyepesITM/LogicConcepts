using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("¿Cuantos números primos desea hallar?: ");
    var primes = GetPrimes(n);

    foreach (var prime in primes)
    {
        Console.Write($"{prime,10:N0}");
    }
    Console.WriteLine("\n");
    Console.WriteLine($"La sumatoria es: {primes.Sum(),10:N0}");
    Console.WriteLine($"El promedio es : {primes.Average(),10:N0}");
    Console.WriteLine();
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

List<int> GetPrimes(int n)
{
    var primes = new List<int>();

    var i = 1;
    do
    {
        if (MyMath.IsPrime(i) == true)
        { // Check if the number is prime
            primes.Add(i); // Add the prime number to the list
        }
        i++;
    } while (primes.Count < n);
    return primes;
}