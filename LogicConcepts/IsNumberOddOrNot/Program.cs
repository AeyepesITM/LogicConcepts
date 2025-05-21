var numberString = string.Empty;

do
{
    Console.Write("Ingrese número entero o 'Salir' para salir: ");
    numberString = Console.ReadLine();
    if (numberString.ToLower() == "salir")
    {
        continue;
    }
    var numberInt = 0;
    if (int.TryParse(numberString, out numberInt))
    {
        if (numberInt % 2 == 0)
        {
            Console.Write($"El número {numberInt}, es par");
        }
        else
        {
            Console.Write($"El número {numberInt}, es impar");
        }
    }
    else
    {
        Console.Write($"El número {numberString}, no es un número entero válido");
    }
} while (numberString.ToLower() != "salir");
Console.WriteLine("Fin del programa");