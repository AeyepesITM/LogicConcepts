using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };
var routeOptions = new List<string> { "1", "2", "3", "4" };

do
{
    Console.WriteLine("*** DATOS DE ENTRADA ***");
    var route = string.Empty;
    do
    {
        route = ConsoleExtension.GetValidOptions("Ruta [1][2][3][4]...............................:", routeOptions);
    } while (!routeOptions.Any(x => x.Equals(route, StringComparison.CurrentCultureIgnoreCase)));

    var trips = ConsoleExtension.GetInt("Número de viajes................................:");
    var passangers = ConsoleExtension.GetInt("Número de pasajeros total.......................:");
    var package10 = ConsoleExtension.GetInt("Número de encomiendas de menos de 10Kg..........:");
    var package10_20 = ConsoleExtension.GetInt("Número de encomiendas entre 10Kg y menos de 20Kg:");
    var package20 = ConsoleExtension.GetInt("Número de encomiendas de más de 20Kg............:");
    var TP = string.Empty;
    //Calculations
    var incomePassangers = GetIncomePassangers(route, passangers, trips);
    var incomePackages = GetIncomePackages(route, package10, package10_20, package20);
    var totalIncome = incomePassangers + incomePackages;
    var (valueHelper, valueAssurance) = GetPayment(totalIncome);
    var fuelValue = GetFuelValue(route, trips, passangers, package10, package10_20, package20);
    var deduction = valueHelper + valueAssurance + fuelValue;
    var totalToPay = totalIncome - deduction;

    Console.WriteLine("*** CALCULOS ***");
    Console.WriteLine($"Ingreso por pasajeros.........................:{incomePassangers,20:C2}");
    Console.WriteLine($"Ingreso por encomiendas.............-.........:{incomePackages,20:C2}");
    Console.WriteLine($"Ingreso total.................................:{totalIncome,20:C2}");
    Console.WriteLine($"Pago asistente de ruta........................:{valueHelper,20:C2}");
    Console.WriteLine($"Pago seguro de ruta...........................:{valueAssurance,20:C2}");
    Console.WriteLine($"Pago gasolina ruta............................:{fuelValue,20:C2}");
    Console.WriteLine($"Pago total asistente y seguro de ruta.........:{deduction,20:C2}");
    Console.WriteLine($"Total a liquidar..............................:{totalToPay,20:C2}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

decimal GetFuelValue(string? route, int trips, int passangers, int package10, int package10_20, int package20)
{
    decimal costFuel = 8860m;
    decimal quantityGasolineKm = 39m;
    decimal costTotalGasoline = 0m;
    decimal gallons = 0m;
    float kms = 0;
    switch (route)
    {
        case "1":
            kms = 150;
            break;

        case "2":
            kms = 167;
            break;

        case "3":
            kms = 184;
            break;

        default:
            kms = 203;
            break;
    }
    gallons = (decimal)kms * trips / quantityGasolineKm;
    decimal weightSurchage = GetTotalWeight(passangers, package10, package10_20, package20); //+ (package10 * 10) + (package10_20 * 15) + (package20 * 20);
    decimal discountFuel = 0.25m;
    costTotalGasoline = costFuel * gallons * (1 - discountFuel + weightSurchage);
    return costTotalGasoline;
}

Console.WriteLine("Fin del programa.");
decimal GetTotalWeight(int passangers, int package10, int package10_20, int package20)
{
    switch (passangers * 60m + package10 * 10m + package10_20 * 15m + package20 * 20m)
    {
        case <= 5000:
            return 0m;

        case <= 10000:
            return 0.10m;

        default:
            return 0.25m;
    }
}

(decimal costAssistant, decimal costInsurante) GetPayment(decimal totalIncome)
{
    decimal income = totalIncome;
    decimal costHelper = 0m;
    decimal costInsurance = 0m;
    switch (income)
    {
        case < 1000000:
            costHelper = income * 0.05m;
            costInsurance = income * 0.03m;
            break;

        case <= 2000000:
            costHelper = income * 0.08m;
            costInsurance = income * 0.04m;
            break;

        case <= 4000000:
            costHelper = income * 0.10m;
            costInsurance = income * 0.06m;
            break;

        case > 4000000:
            costHelper = income * 0.13m;
            costInsurance = income * 0.09m;
            break;
    }
    return (costHelper, costInsurance);
}

decimal GetIncomePackages(string? route, int package10, int package10_20, int package20)
{
    decimal value = 0;
    decimal valuePackage = 0;
    switch (route)
    {
        case "1":
        case "2":
            switch (package10)
            {
                case <= 50:
                    valuePackage = 100m;
                    break;

                case <= 100:
                    valuePackage = 120m;
                    break;

                case <= 130:
                    valuePackage = 150m;
                    break;

                case > 130:
                    valuePackage = 160m;
                    break;
            }
            value += valuePackage * package10;

            switch (package10_20 + package20)
            {
                case <= 50:
                    valuePackage = 120m;
                    break;

                case <= 100:
                    valuePackage = 140m;
                    break;

                case <= 130:
                    valuePackage = 160m;
                    break;

                case > 130:
                    valuePackage = 180m;
                    break;
            }
            value += valuePackage * (package10_20 + package20);
            break;

        default:
            switch (package10)
            {
                case <= 50:
                    valuePackage = 130m;
                    break;

                case <= 100:
                    valuePackage = 160m;
                    break;

                case <= 130:
                    valuePackage = 175m;
                    break;

                case > 130:
                    valuePackage = 200m;
                    break;
            }
            value += valuePackage * package10;
            switch (package10_20)
            {
                case <= 50:
                    valuePackage = 140m;
                    break;

                case <= 100:
                    valuePackage = 180m;
                    break;

                case <= 130:
                    valuePackage = 200m;
                    break;

                case > 130:
                    valuePackage = 250m;
                    break;
            }
            value += valuePackage * package10_20;
            switch (package20)
            {
                case <= 50:
                    valuePackage = 170m;
                    break;

                case <= 100:
                    valuePackage = 210m;
                    break;

                case <= 130:
                    valuePackage = 250m;
                    break;

                case > 130:
                    valuePackage = 300m;
                    break;
            }
            value += valuePackage * package20;
            break;
    }
    return value;
}

decimal GetIncomePassangers(string? route, int passangers, int trips)
{
    decimal value = 0;
    decimal comision = 0;
    decimal aditionalIncomePassangers = 0;
    switch (route)
    {
        case "1":
            value = 500000m * trips;
            switch (passangers)
            {
                case < 50:
                    comision = 0.00m;
                    break;

                case <= 100:
                    comision = 0.05m;
                    break;

                case <= 150:
                    comision = 0.06m;
                    break;

                case <= 200:
                    comision = 0.07m;
                    break;

                case > 200:
                    comision = 0.07m;
                    aditionalIncomePassangers = (passangers - 200) * 50;
                    break;
            }
            break;

        case "2":
            value = 600000m * trips;
            switch (passangers)
            {
                case < 50:
                    comision = 0.00m;
                    break;

                case <= 100:
                    comision = 0.07m;
                    break;

                case <= 150:
                    comision = 0.08m;
                    break;

                case <= 200:
                    comision = 0.09m;
                    break;

                case > 200:
                    comision = 0.09m;
                    aditionalIncomePassangers = (passangers - 200) * 60;
                    break;
            }
            break;

        case "3":
            value = 800000m * trips;
            switch (passangers)
            {
                case < 50:
                    comision = 0.00m;
                    break;

                case <= 100:
                    comision = 0.10m;
                    break;

                case <= 150:
                    comision = 0.13m;
                    break;

                case <= 200:
                    comision = 0.15m;
                    break;

                case > 200:
                    comision = 0.15m;
                    aditionalIncomePassangers = (passangers - 200) * 100;
                    break;
            }
            break;

        default:
            value = 1000000m * trips;
            switch (passangers)
            {
                case < 50:
                    comision = 0.00m;
                    break;

                case <= 100:
                    comision = 0.125m;
                    break;

                case <= 150:
                    comision = 0.15m;
                    break;

                case <= 200:
                    comision = 0.17m;
                    break;

                case > 200:
                    comision = 0.17m;
                    aditionalIncomePassangers = (passangers - 200) * 150;
                    break;
            }
            break;
    }
    return value * (1m + comision) + aditionalIncomePassangers;
}