namespace Practical_Challenge_POO_CSharp;

class Utilities
{
    public static string GetValidInput(string[] validOptions)
    {
        do
        {
            string? inputStr = Console.ReadLine();
            if (inputStr != null && Array.Exists(validOptions, option => option.Equals(inputStr, StringComparison.OrdinalIgnoreCase)))
            {
                return inputStr;
            }
            else
            {
                Console.WriteLine($"Ingrese una opción valida ({string.Join("/", validOptions)}):");
            }
        }
        while (true);
    }
}
