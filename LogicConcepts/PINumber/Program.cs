using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("♦♦♦CÁLCULO DEL NÚMERO pi♦♦♦");
    var n = ConsoleExtension.GetInt("¿Cuantos términos de precisión desea?: ");

    //Data processing
    var pi = CalculatePi(n);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"El número pi con {n:N0} números de precisión  es: {pi,10}");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double CalculatePi(int n)
{
    double sum = 1;
    double den = 1;
    for (var i = 1; i <= n; i++)
    {
        if (i % 2 == 0) // Alternating series
        {
            sum += 1 / (den + 2 * i); // Subtract the next term
        }
        else
        {
            sum -= 1 / (den + 2 * i);
        }
    }
    return sum * 4;
}