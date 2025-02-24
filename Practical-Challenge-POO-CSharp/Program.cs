namespace Practical_Challenge_POO_CSharp;

internal class Program
{
    static void Main()
    {
        Console.WriteLine("**** BIENVENIDO AL JUEGO DE 21 BLACK-JACK ****\n");
        
        Console.Write("Deseas jugar una partida? (yes/no): ");
        string valStartGame = Utilities.GetValidInput(["yes","no"]);
        Console.WriteLine();

        bool playerWinGame;

        switch (valStartGame)
        {
            case "yes":
                playerWinGame = BlackJack.PlayGame();

                if (playerWinGame)
                {
                    Console.WriteLine("¡Felicidades! ¡Ganaste!");
                }
                else
                {
                    Console.WriteLine("¡Suerte en la proxima!, has perdido la partida");
                }
                break;
            case "no":
                Console.WriteLine("Gracias por jugar, hasta la próxima!");
                break;
            default:
                Console.WriteLine("Opcion no valida!");
                break;
        }
    }
}

