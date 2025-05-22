using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
var desktopCost = 650000;
do
{
    var quantity = ConsoleExtension.GetFloat("Ingrese cantidades compradas: ");
    var descount = 0.0d;
    do
    {
        if (quantity < 0)
        {
            Console.WriteLine("La cantidad no puede ser negativa.");
            quantity = ConsoleExtension.GetFloat("Ingrese cantidades compradas: ");
        }
    } while (quantity < 0);
    if (quantity < 5)
    {
        descount = 0.10d;
    }
    else if (quantity < 10)
    {
        descount = 0.20d;
    }
    else
    {
        descount = 0.40d;
    }
    var totalCost = (decimal)quantity * (decimal)desktopCost * (1 - (decimal)descount);
    Console.WriteLine($"Número de escritorios: {quantity}");
    Console.WriteLine($"Descuento aplicado...: {descount:P2}");
    Console.WriteLine($"Costo total..........: {totalCost:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));