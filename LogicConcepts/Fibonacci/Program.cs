using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Introduce un número entero positivo: ");
    double a = 0;
    double b = 1;
    double sum = a + b;

    Console.Write($"{a:N0}\t{b:N0}\t");

    for (int i = 2; i < n; i++)
    {
        double c = a + b;
        Console.Write($"{c:N0}\t");
        a = b;
        b = c;
        sum += c;
    }
    Console.WriteLine($"\nLa suma es: {sum:N0}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));