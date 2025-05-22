using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
var tpOptions = new List<string> { "p", "n" };
var tcOptions = new List<string> { "f", "a" };
var maOptions = new List<string> { "n", "c", "e", "g" };
do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    var CC = ConsoleExtension.GetDecimal("Costo de compra ($)....................................................:");
    var TP = string.Empty;
    do
    {
        TP = ConsoleExtension.GetValidOptions("Tipo de producto [P]erecedero, [N]o perecedero.........................:", tpOptions);
    } while (!tpOptions.Any(x => x.Equals(TP, StringComparison.CurrentCultureIgnoreCase)));
    var TC = string.Empty;
    do
    {
        TC = ConsoleExtension.GetValidOptions("Tipo de conservación [F]rio, [A]mbiente................................:", tcOptions);
    } while (!tcOptions.Any(x => x.Equals(TC, StringComparison.CurrentCultureIgnoreCase)));
    var PC = ConsoleExtension.GetInt("Periodo de conservación (días).........................................:");
    var PA = ConsoleExtension.GetInt("Periodo de almacenamiento (días).......................................:");
    var VOL = ConsoleExtension.GetDecimal("Volumen (litros).......................................................:");
    var MA = string.Empty;
    do
    {
        MA = ConsoleExtension.GetValidOptions("Medio de almacenamiento [N]evera, [C]ongelador, [E]estanteria, [G]uacal:", maOptions);
    } while (!maOptions.Any(x => x.Equals(MA, StringComparison.CurrentCultureIgnoreCase)));

    Console.WriteLine("*** CALCULOS ***");
    var CA = GetCostoAlmacenamiento(CC, TP, TC, PC, VOL);
    var PDP = GetPorcentajeDepreciacionDelProducto(PA);
    var CE = GetCostoExhibicion(TP, TC, MA, CA);
    var VR_P = GetValorRealProducto(CC, CA, CE, PDP);
    var VR_V = GetValorRealVenta(TP, VR_P);
    Console.WriteLine($"Costo de almacenamiento ($)...........................................:{CA,20:C2}");
    Console.WriteLine($"Porcentaje de depreciación del producto (%).............................:{PDP,20:P2}");
    Console.WriteLine($"Costo de exhibición ($)...............................................:{CE,20:C2}");
    Console.WriteLine($"Valor real de compra ($)..............................................:{VR_P,20:C2}");
    Console.WriteLine($"Valor real de venta ($)...............................................:{VR_V,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

Console.WriteLine("Fin del programa.");
decimal GetValorRealProducto(decimal cC, decimal cA, decimal cE, decimal pDP)
{
    return (cC + cA + cE) * pDP;
}

decimal GetCostoExhibicion(string? tP, string? tC, string? mA, decimal cA)
{
    if (tP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (tC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (mA!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
            {
                return 2 * cA;
            }
            else if (mA!.Equals("c", StringComparison.CurrentCultureIgnoreCase))
            {
                return cA;
            }
            else { return 0m; }
        }
        else
        {
            return 0m;
        }
    }
    else
    {
        if (mA!.Equals("e", StringComparison.CurrentCultureIgnoreCase))
        {
            return cA * 0.05m;
        }
        else if (mA!.Equals("g", StringComparison.CurrentCultureIgnoreCase))
        {
            return cA * 0.07m;
        }
        else
        {
            return 0m;
        }
    }
}
decimal GetValorRealVenta(string? tP, decimal vR_P)
{
    if (tP!.Equals("n", StringComparison.CurrentCultureIgnoreCase))
    {
        return vR_P * (1 + 0.2m);
    }
    else
    {
        return vR_P * (1 + 0.4m);
    }
}

decimal GetPorcentajeDepreciacionDelProducto(int pA)
{
    if (pA < 30)
    {
        return 0.95m;
    }
    else
    {
        return 0.85m;
    }
}

decimal GetCostoAlmacenamiento(decimal cC, string? tP, string? tC, int pC, decimal vOL)
{
    if (tP!.Equals("p", StringComparison.CurrentCultureIgnoreCase))
    {
        if (tC!.Equals("f", StringComparison.CurrentCultureIgnoreCase))
        {
            if (pC < 10)
            {
                return cC * 0.05m;
            }
            else
            {
                return cC * 0.1m;
            }
        }
        else
        {
            if (pC < 20)
            {
                return cC * 0.03m;
            }
            else if (pC > 20)
            {
                return cC * 0.1m;
            }
            else
            {
                return cC * 0.05m;
            }
        }
    }
    else
    {
        if (vOL >= 50)
        {
            return cC * 0.1m;
        }
        else
        {
            return cC * 0.2m;
        }
    }
}