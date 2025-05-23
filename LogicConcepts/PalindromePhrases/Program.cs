using Shared;
using System.Text;

var answer = string.Empty;
var options = new List<string> { "s", "n" };

do
{
    //Data input
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.Clear();
    Console.WriteLine("♦♦♦ FRASES PALINDROMAS ♦♦♦");
    var phrase = ConsoleExtension.GetString("Ingrese la palabra o frase : ");

    //Data processing
    var isPalindrome = IsPalindrome(phrase);

    //Data output
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine($"La palabra/frase '{phrase}' {(isPalindrome ? "es" : "no es")} un palíndromo.");
    Console.BackgroundColor = ConsoleColor.Blue;
    Console.ForegroundColor = ConsoleColor.White;

    do
    {
        answer = ConsoleExtension.GetValidOptions("¿Deseas continuar [S]í, [N]o?: ", options);
    } while (!options.Any(x => x.Equals(answer, StringComparison.CurrentCultureIgnoreCase)));
} while (answer!.Equals("s", StringComparison.CurrentCultureIgnoreCase));

bool IsPalindrome(string? phrase)
{
    // Eliminar espacios, signos de puntuación y caracteres especiales comunes en español
    phrase = PreparePhrase(phrase);
    // Si la frase es nula o vacía, no es un palíndromo
    if (string.IsNullOrEmpty(phrase))
        return false;

    // Comprobar si la frase es un palíndromo
    int start = 0;
    int end = phrase.Length - 1;

    while (start < end)
    {
        if (phrase[start] != phrase[end])
            return false;

        start++;
        end--;
    }

    return true;
}

string? PreparePhrase(string? phrase)
{
    // Verificar si la frase es nula
    if (string.IsNullOrEmpty(phrase))
        return string.Empty;

    // Lista de caracteres a excluir
    var exceptions = new HashSet<char> {
        ' ', ',', '.', '!', '?', '¿', '¡', ':', ';', '(', ')', '[', ']', '{', '}', '\'', '"', '–', '-', '_'
    };

    var newPhrase = new StringBuilder();
    // Recorrer cada carácter de la frase
    foreach (var ch in phrase)
    {
        // Si el carácter no está en la lista de excepciones, se agrega al StringBuilder
        if (!exceptions.Contains(ch))
        {
            newPhrase.Append(ch);
        }
    }

    // Devolver la frase resultante sin los caracteres excluidos
    return newPhrase.ToString();
}