using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var currentYear = DateTime.Now.Year;
    var message = string.Empty;
    var year = ConsoleExtension.GetInt("Ingrese un año: ");

    if (year == currentYear)
    {
        message = "es";
    }
    else if (year < currentYear)
    {
        message = "fue";
    }
    else
    {
        message = "va a ser";
    }

    if (year % 4 == 0 && (year % 100 != 0 || year % 400 == 0))
    {
        Console.WriteLine($"El año {year} {message} un año bisiesto.");
    }
    else
    {
        Console.WriteLine($"El año {year} no {message} un año bisiesto.");
    }
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Game Over.");