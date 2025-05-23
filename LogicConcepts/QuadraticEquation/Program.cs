using Shared;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    var a = ConsoleExtension.GetDouble("Introduce el valor de a (coeficiente cuadrático): ");
    var b = ConsoleExtension.GetDouble("Introduce el valor de b (coeficiente lineal): ");
    var c = ConsoleExtension.GetDouble("Introduce el valor de c (término independiente): ");
    var solution = QuadraticEquation(a, b, c);

    Console.WriteLine($"Las soluciones de la ecuación cuadrática son: ");
    Console.WriteLine($"X1 = {solution.X1:N5}");
    Console.WriteLine($"X2 = {solution.X2:N5}");

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

QuadraticEquationSolution QuadraticEquation(double a, double b, double c)
{
    return new QuadraticEquationSolution
    {
        X1 = (-b + Math.Sqrt(b * b - 4 * a * c)) / (2 * a),
        X2 = (-b - Math.Sqrt(b * b - 4 * a * c)) / (2 * a)
    };
}

public class QuadraticEquationSolution
{
    public double X1 { get; set; }
    public double X2 { get; set; }
}