using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
do
{
    var credits = ConsoleExtension.GetInt("Ingrese el número de créditos matriculados: ");
    var creditValue = ConsoleExtension.GetDecimal("Ingrese el valor por cada crédito: ");
    var stratum = ConsoleExtension.GetInt("Ingrese el estrato socioeconómico: ");
    var registrationValue = CalculateRegistrationValue(credits, creditValue, stratum);
    var subsidy = CalculateSubsidy(stratum);

    Console.WriteLine($"El valor a pagar es: {registrationValue,20:C2}");
    Console.WriteLine($"El subsidio es.....: {subsidy,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));
Console.WriteLine("Fin del programa.");

decimal CalculateRegistrationValue(int credits, decimal valueUnit, int stratum)
{
    decimal valueUnit1 = valueUnit;
    decimal valueRegistration = 0;
    var discount = 0d;
    while (credits <= 0)
    {
        Console.WriteLine("El número de créditos matriculados no puede ser negativo.");
        credits = ConsoleExtension.GetInt("Ingrese el número de créditos matriculados: ");
    }

    if (credits > 20)
    {
        //valueRegistration =  20 * valueUnit1 + ((decimal)credits - 20) * valueUnit1 * 2;
        valueRegistration = 2 * valueUnit1 * ((decimal)credits - 10);
    }
    else
    {
        valueRegistration = (decimal)credits * valueUnit1;
    }
    if (stratum > 0)
    {
        if (stratum < 2)
        {
            discount = 0.8d;
        }
        else if (stratum < 3)
        {
            discount = 0.5d;
        }
        else if (stratum < 4)
        {
            discount = 0.3d;
        }
    }
    return valueRegistration = valueRegistration * (1 - (decimal)discount);
}

decimal CalculateSubsidy(int stratum)
{
    decimal subsidyCalculate = 0;
    if (stratum < 2)
    {
        subsidyCalculate = 200000;
    }
    else if (stratum < 3)
    {
        subsidyCalculate = 100000;
    }
    return subsidyCalculate;
}