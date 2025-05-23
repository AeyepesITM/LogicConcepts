using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("♦♦♦ OPERACIONES EN UN ARREGLO ♦♦♦");
    var n = ConsoleExtension.GetInt("¿Cuantas posiciones quieres en el arreglo?: ");

    //Data processing
    var numbers = new int[n];
    FillArray(numbers);
    ShowArray(numbers);
    ////double sumArray = GetSum(numbers);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    ////Console.WriteLine($"La sumatoria de los pares es .......:{sumArray,30:N2}");
    ////Console.WriteLine($"El promedio es .....................:{sumArray / n,30:N2}");
    Console.WriteLine($"La sumatoria de los pares es .......:{numbers.Sum(),30:N2}");
    Console.WriteLine($"El promedio es .....................:{numbers.Average(),30:N2}");
    //Console.Clear();

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

////double GetSum(int[] numbers)
////{
////    double sum = 0;
////    foreach (int number in numbers)
////    {
////        sum += number; // Add the even number to the sum
////    }
////    return sum;
////}

void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    Console.WriteLine();
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(1, 100); // Fill the array with random numbers between 1 and 1000
    }
}