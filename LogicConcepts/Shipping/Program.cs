using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var weight = ConsoleExtension.GetDecimal("Ingrese el peso del paquete en kg: ");
    var value = ConsoleExtension.GetDecimal("Ingrese el valor del paquete.....: ");
    string isMonday;
    do
    {
        isMonday = ConsoleExtension.GetValidOptions("Es lunes [S]í, [N]o?: ", options)!;
    } while (!options.Any(x => x.Equals(isMonday, StringComparison.CurrentCultureIgnoreCase)));

    var payMethods = new List<string> { "e", "t" };
    string payMethod;
    do
    {
        payMethod = ConsoleExtension.GetValidOptions("Tipo de pago [E]fectivo [T]arjeta: ", payMethods)!;
    } while (!payMethods.Any(x => x.Equals(payMethod, StringComparison.CurrentCultureIgnoreCase)));

    var fare = CalculateFare(weight);
    var discount = 0m;
    decimal promotion = 0;
    promotion = CalculatePromotion(fare, isMonday, payMethod, value);
    if (promotion == 0)
    {
        discount = CalculateDiscount(fare, value);
    }
    Console.WriteLine($"El valor a pagar es: {fare,20:C2}");
    Console.WriteLine($"El descuento es....: {discount,20:C2}");
    Console.WriteLine($"La promoción es....: {promotion,20:C2}");
    Console.WriteLine($"El valor total es..: {(fare - discount - promotion),20:C2}");
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Fin del programa.");
decimal CalculatePromotion(decimal fare, string isMonday, string payMethod, decimal value)
{
    if (isMonday.ToLower() == "s" && payMethod.ToLower() == "t")
    {
        return fare * 0.5m;
    }
    else if (payMethod.ToLower() == "e" && value > 1000000m)
    {
        return fare * 0.4m;
    }
    else
    {
        return 0m;
    }
}

decimal CalculateDiscount(decimal fare, decimal value)
{
    if (value >= 300000m && value <= 600000m)
    {
        return fare * 0.1m;
    }
    else if (value > 600000m && value <= 1000000m)
    {
        return fare * 0.2m;
    }
    else if (value > 1000000m)
    {
        return fare * 0.3m;
    }
    else
    {
        return 0m;
    }
}

decimal CalculateFare(decimal weight)
{
    if (weight < 100)
    {
        return 20000m;
    }
    else if (weight <= 150)
    {
        return 25000m;
    }
    else if (weight <= 200)
    {
        return 30000m;
    }
    else
    {
        return 35000m + Math.Floor((decimal)(weight - 200) / 10) * 2000m;
        //return 200m * ((decimal)weight - 25m);
    }
}