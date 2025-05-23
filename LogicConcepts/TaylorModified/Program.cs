using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetInt("Introduce un número entero positivo..........: ");
    var x = ConsoleExtension.GetDouble("Introduce un número real.....................: ");
    var taylor = GetTaylorModified(n, x);
    Console.WriteLine($"El resultado de la serie de Taylor f({x}) es: {taylor:N5}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetTaylorModified(int n, double x)
{
    double sum = 0;
    int signo = 1; // Alternar el signo en cada iteración
    for (int i = 0; i < n; i++)
    {
        sum += Math.Pow(x, i) / MyMath.Factorial(i) * signo;
        signo *= -1;
    }
    return sum;
}