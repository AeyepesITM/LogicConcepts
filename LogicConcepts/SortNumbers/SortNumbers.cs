using Shared;

do
{
    Console.WriteLine("Ingrese 3 números diferentes...");
    var a = ConsoleExtension.GetInt("Ingrese primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    var c = ConsoleExtension.GetInt("Ingrese tercer número: ");
    if (a == b || a == c || b == c)
    {
        Console.WriteLine("Los números deben ser diferentes.");
        continue;
    }
    if (a > b && a > c)
    {
        if (b > c)
        {
            Console.WriteLine($"El número mayor es {a}, el medio es {b}, el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El número mayor es {a}, el medio es {c}, el menor es {b}");
        }
    }
    else if (b > a && b > c)
    {
        if (a > c)
        {
            Console.WriteLine($"El número mayor es {b}, el medio es {a}, el menor es {c}");
        }
        else
        {
            Console.WriteLine($"El número mayor es {b}, el medio es {c}, el menor es {a}");
        }
    }
    else if (a > b)
    {
        Console.WriteLine($"El número mayor es {c}, el medio es {a}, el menor es {b}");
    }
    else
    {
        Console.WriteLine($"El número mayor es {c}, el medio es {b}, el menor es {a}");
    }
} while (true);