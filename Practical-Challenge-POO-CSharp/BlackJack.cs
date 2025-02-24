namespace Practical_Challenge_POO_CSharp;

class BlackJack
{
    public static int maxTotalCards;
    public static int crupiertStopLimit;
    public static int maxCardValue;
    public static int minCardValue;


    BlackJack()
    {
        maxTotalCards = 21;
        crupiertStopLimit = 17;
        maxCardValue = 11;
        minCardValue = 1;
    }

    public static bool PlayGame()
    {
        var playerCards = new List<int>();
        var crupierCards = new List<int>();

        Console.WriteLine("Repartiendo cartas...!");

        for (int i = 0; i < 2; i++)
        {
            playerCards.Add(DealCards());
            crupierCards.Add(DealCards());
        }

        Console.WriteLine($"Tus cartas son: [{playerCards[0]}] [{playerCards[1]}] (Total: {playerCards.Sum()})");
        Console.WriteLine($"Carta visible de Crupier: [{crupierCards[0]}]");
        Console.WriteLine();

        int cardPlayer;
        do
        {
            cardPlayer = DealCardsPlayer();

            if (cardPlayer > 0)
            {
                playerCards.Add(cardPlayer);
                Console.WriteLine($"El jugador recibe: [{cardPlayer}] (Total: {playerCards.Sum()})");
                Console.WriteLine();

                if (playerCards.Sum() > maxTotalCards)
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine($"El crupier revela su segunda carta: [{crupierCards[0]}] [{crupierCards[1]}] (Total: {crupierCards.Sum()})");
                Console.WriteLine();

                if (playerCards.Sum() < crupierCards.Sum())
                {
                    return false;
                }
            }

        }
        while (cardPlayer > 0);

        int cardCrupier;
        do
        {
            cardCrupier = DealCardsCrupier(crupierCards);


            if (cardCrupier > 0)
            {
                crupierCards.Add(cardCrupier);
                Console.WriteLine("Repartiendo cartas...!");
                Console.WriteLine($"El crupier recibe: [{cardCrupier}] (Total: {crupierCards.Sum()})");
                Console.WriteLine();

                if (crupierCards.Sum() > maxTotalCards)
                {
                    return true;
                }
            }
            else
            {
                Console.WriteLine($"El crupier se planta con un total de: {crupierCards.Sum()}");
                if (playerCards.Sum() > crupierCards.Sum())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
        while (cardCrupier > 0);

        Console.WriteLine("Fin del juego!");
        return false;
    }

    static int DealCardsPlayer()
    {
        Console.Write("Deseas pedir otra carta? (yes/no): ");
        string valDealCards = Utilities.GetValidInput(["yes", "no"]);
        Console.WriteLine();

        switch (valDealCards)
        {
            case "yes":
                return DealCards();
            case "no":
                return 0;
            default:
                Console.WriteLine("Opción no válida!");
                return 0;
        }
    }

    static int DealCardsCrupier(List<int> crupierCards)
    {
        if (crupierCards.Sum() < crupiertStopLimit)
        {
            return DealCards();
        }
        else
        {
            return 0;
        }
    }

    static int DealCards()
    {
        var random = new Random();
        return random.Next(minCardValue, maxCardValue);
    }
}
