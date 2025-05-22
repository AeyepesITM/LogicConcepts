using Shared;

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
} while (true);