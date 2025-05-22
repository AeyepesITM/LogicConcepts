using Shared;

do
{
    var a = ConsoleExtension.GetInt("Ingrese primer número: ");
    var b = ConsoleExtension.GetInt("Ingrese segundo número: ");
    if (a % b == 0)
    {
        Console.WriteLine($"{a} es múltiplo de {b}");
    }
    else if (b % a == 0)
    {
        Console.WriteLine($"{b} es múltiplo de {a}");
    }
    else
    {
        Console.WriteLine($"{a} y {b} no son múltiplos entre sí.");
    }
}
while (true);