using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.Clear();
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.WriteLine("♦♦♦ ORDERNACIÓN ESPECIAL DE UN ARREGLO♦♦♦");
    var n = ConsoleExtension.GetInt("¿Cuantas posiciones quieres en el arreglo?: ");

    //Data processing
    var numbers = new int[n];
    FillArray(numbers);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;

    Console.WriteLine("Arreglo original: ");
    ShowArray(numbers);
    Console.WriteLine();
    var numbersEven = GetNumbersEven(numbers);
    var numbersOdd = GetNumbersOdd(numbers);
    //Console.WriteLine("Arreglo original pares: ");
    //ShowArray(numbersEven);
    Console.WriteLine();
    //Console.WriteLine("Arreglo original impares: ");
    //ShowArray(numbersOdd);
    Console.WriteLine();
    OrderArray(numbersEven, true);
    OrderArray(numbersOdd);

    Console.WriteLine("Arreglo ordenado: ");

    ShowArray(numbersEven);
    ShowArray(numbersOdd);
    Console.WriteLine();
    //Console.Clear();
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

int[] GetNumbersOdd(int[] numbers)
{
    var countOdd = 0;
    foreach (var number in numbers)
    {
        countOdd += !isEven(number) ? 1 : 0;
    }

    var numbersOdds = new int[countOdd];
    var index = 0;
    foreach (var number in numbers)
    {
        if (!isEven(number))
        {
            numbersOdds[index] = number;
            index++;
        }
    }

    return numbersOdds;
}

int[] GetNumbersEven(int[] numbers)
{
    var countEven = 0;
    foreach (var number in numbers)
    {
        countEven += isEven(number) ? 1 : 0;
    }

    var numbersEven = new int[countEven];
    var index = 0;
    foreach (var number in numbers)
    {
        if (isEven(number))
        {
            numbersEven[index] = number;
            index++;
        }
    }

    return numbersEven;
}

bool isEven(int number)
{
    return number % 2 == 0;
}

void OrderArray(int[] numbers, bool isDescending = false)
{
    for (int i = 0; i < numbers.Length - 1; i++)
    {
        for (int j = i + 1; j < numbers.Length; j++)
        {
            if (isDescending)
            {
                if (numbers[i] < numbers[j])
                {
                    ChangeNumberIndex(ref numbers[i], ref numbers[j]);
                }
            }
            else
            {
                if (numbers[i] > numbers[j])
                {
                    ChangeNumberIndex(ref numbers[i], ref numbers[j]);
                }
            }
        }
    }
}

void ChangeNumberIndex(ref int number1, ref int number2)
{
    // Swap the elements
    int aux = number1;
    number1 = number2;
    number2 = aux;
}

void ShowArray(int[] numbers)
{
    foreach (var number in numbers)
    {
        Console.Write($"{number,10:N0}");
    }
    //Console.WriteLine();
}

void FillArray(int[] numbers)
{
    var random = new Random();
    for (int i = 0; i < numbers.Length; i++)
    {
        numbers[i] = random.Next(1, 100); // Fill the array with random numbers between 1 and 1000
    }
}