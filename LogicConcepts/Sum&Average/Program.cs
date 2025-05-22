using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var n = ConsoleExtension.GetFloat("Cuantos números desea: ");
    int sum = 0;
    //for (int i = 1; i <= n; i++)
    //{
    //    Console.Write($"{i}\t");
    //    sum += i;
    //}

    int i = 1;
    while (i <= n)
    {
        Console.Write($"{i}\t");
        sum += i;
        i++;
    }

    var average = sum / n;
    Console.WriteLine();
    Console.WriteLine($"La suma es....: {sum,20:N2}");
    Console.WriteLine($"El promedio es: {average,20:N2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));