using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.DarkBlue;
    Console.Clear();
    Console.WriteLine("♦♦♦CÁLCULO DEL NÚMERO e♦♦♦");
    var n = ConsoleExtension.GetInt("¿Cuantos términos de precisión desea?: ");

    //Data processing
    var e = CalculateE(n);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"El número e con {n} números de precisión  es: {e,10}");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculateE(int n)
{
    double sum = 0;
    for (var i = 0; i < n; i++)
    {
        sum += 1 / MyMath.Factorial(i);
    }
    return sum;
}