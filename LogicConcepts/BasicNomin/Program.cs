using Shared;

var salaryMinimun = 1000000;
var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var name = ConsoleExtension.GetString("Ingrese su nombre.......................: ");
    var hourValue = ConsoleExtension.GetDecimal("Ingrese el valor de la hora trabajada...: ");
    var workHours = ConsoleExtension.GetFloat("Ingrese la cantidad de horas trabajadas.: ");
    var salary = (decimal)workHours * hourValue;

    Console.WriteLine($"Nombre..................................: {name}");
    if (salary > salaryMinimun)
    {
        Console.WriteLine($"Salario.................................: {salary:C2}");
    }
    else
    {
        Console.WriteLine($"Salario.................................: {salaryMinimun:C2}");
    }
    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));