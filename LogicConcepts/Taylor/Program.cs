using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Introduce un número entero positivo..........: ");
    var x = ConsoleExtension.GetDouble("Introduce un número real.....................: ");
    var taylor = GetTaylor(n, x);
    Console.WriteLine($"El resultado de la serie de Taylor f({x}) es: {taylor:N5}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetTaylor(int n, double x)
{
    double sum = 0;
    for (int i = 0; i < n; i++)
    {
        double term = Math.Pow(x, i) / MyMath.Factorial(i);
        sum += term;
    }
    return sum;
}