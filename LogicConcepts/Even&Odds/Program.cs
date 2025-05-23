using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.Black;
    Console.Clear();
    Console.WriteLine("♦♦♦PARES E IMPARES EN UN ARREGLO♦♦♦");
    var n = ConsoleExtension.GetInt("¿Cuantas posiciones quieres en el arreglo?: ");

    //Data processing
    var numbers = new int[n];
    FillArray(numbers);
    ShowArray(numbers);
    double sumEven = GetSumEven(numbers);
    double powOdd = GetPowOdd(numbers);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"La sumatoria de los pares es .......:{sumEven,30:N0}");
    Console.WriteLine($"La multiplicación de los impares es.:{powOdd,30:N0}");
    //Console.Clear();

    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

double GetPowOdd(int[] numbers)
{
    double pow = 1;
    foreach (int number in numbers)
    {
        pow *= (number % 2 != 0) ? number : 1; // Multiply the odd number to the product
    }
    return pow;
}

double GetSumEven(int[] numbers)
{
    double sum = 0;
    foreach (int number in numbers)
    {
        sum += (number % 2 == 0) ? number : 0; // Add the even number to the sum
    }
    return sum;
}

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