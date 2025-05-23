using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("♦♦♦CALENDARIO♦♦♦");
    var year = ConsoleExtension.GetInt("Ingrese año: ");

    //Data processing

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Clear();

    ShowCalendar(year);

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

void ShowCalendar(int year)
{
    Console.WriteLine($"**** Año : {year} ****");
    List<string> days = ["Dom", "Lun", "Mar", "Mie", "Jue", "Vie", "Sab"];
    List<string> months = ["Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic"];

    int i = 1;
    foreach (var month in months)
    {
        Console.WriteLine($"\nMes: {month}\n");//check
        Console.WriteLine($"{days[0]}\t{days[1]}\t{days[2]}\t{days[3]}\t{days[4]}\t{days[5]}\t{days[6]}\n");
        var dayPerMonth = GetDaysPerMonth(year, i);
        var zeller = Zeller(year, i);
        var daysCounter = 0;

        for (int j = 0; j < zeller; j++)
        {
            Console.Write("\t");
            daysCounter++;
        }

        for (int day = 1; day <= dayPerMonth; day++)
        {
            Console.Write($"{day,2}\t");
            daysCounter++;
            if (daysCounter == 7)
            {
                daysCounter = 0;
                Console.WriteLine();
            }
        }
        i++;
        Console.WriteLine();
        Console.WriteLine();
    }
    Console.WriteLine();
}

int GetDaysPerMonth(int year, int month)
{
    if (month == 2 && DateUtilities.IsLeapYear(year))
    {
        return 29;
    }
    List<int> daysPerMonth = [0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
    return daysPerMonth.ElementAt(month);
}

int Zeller(int year, int month)
{
    int a = (14 - month) / 12;
    int y = year - a;
    int m = month + 12 * a - 2;
    int day = 1, d;
    d = (day + y + y / 4 - y / 100 + y / 400 + (31 * m) / 12) % 7;
    return (d);
}