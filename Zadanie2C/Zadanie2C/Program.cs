using System;
using System.Collections.Generic;

class Card
{
    public string Rank { get; }
    public string Suit { get; }

    public Card(string rank, string suit)
    {
        Rank = rank;
        Suit = suit;
    }

    public int GetValue()
    {
        if (int.TryParse(Rank, out int number))
            return number;

        if (Rank == "A") return 11;
        return 10; // J, Q, K
    }

    public void Print()
    {
        if (Suit == "♥" || Suit == "♦")
            Console.ForegroundColor = ConsoleColor.Red;
        else
            Console.ForegroundColor = ConsoleColor.White;

        Console.Write(Rank + Suit + " ");
        Console.ResetColor();
    }
}

class Deck
{
    private List<Card> cards = new List<Card>();
    private Random rand = new Random();

    public Deck()
    {
        string[] suits = { "♠", "♥", "♦", "♣" };
        string[] ranks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K" };

        foreach (var s in suits)
            foreach (var r in ranks)
                cards.Add(new Card(r, s));
    }

    public void Shuffle()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            int j = rand.Next(cards.Count);
            (cards[i], cards[j]) = (cards[j], cards[i]);
        }
    }

    public Card Draw()
    {
        Card c = cards[0];
        cards.RemoveAt(0);
        return c;
    }
}

class Hand
{
    public List<Card> Cards { get; } = new List<Card>();

    public void Add(Card c) => Cards.Add(c);

    public int GetValue()
    {
        int total = 0;
        int aces = 0;
        foreach (var c in Cards)
        {
            total += c.GetValue();
            if (c.Rank == "A") aces++;
        }
        while (total > 21 && aces > 0)
        {
            total -= 10;
            aces--;
        }
        return total;
    }

    public void Print()
    {
        foreach (var c in Cards)
            c.Print();
        Console.WriteLine($" (wartość: {GetValue()})");
    }
}

class Player
{
    public Hand Hand { get; } = new Hand();
}

class Dealer
{
    public Hand Hand { get; } = new Hand();
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== PROSTY BLACKJACK ===");

        Deck deck = new Deck();
        deck.Shuffle();

        Player player = new Player();
        Dealer dealer = new Dealer();

        player.Hand.Add(deck.Draw());
        player.Hand.Add(deck.Draw());
        dealer.Hand.Add(deck.Draw());
        dealer.Hand.Add(deck.Draw());

        Console.WriteLine("\nTwoje karty:");
        player.Hand.Print();

        Console.WriteLine("\nKarta krupiera:");
        dealer.Hand.Cards[0].Print();
        Console.WriteLine("[X]");

        // tura gracza
        while (true)
        {
            Console.Write("\nHit czy Stand (h/s)? ");
            string choice = Console.ReadLine().ToLower();
            if (choice == "h")
            {
                player.Hand.Add(deck.Draw());
                Console.WriteLine("Twoje karty:");
                player.Hand.Print();

                if (player.Hand.GetValue() > 21)
                {
                    Console.WriteLine("Przegrałeś.");
                    return;
                }
            }
            else if (choice == "s")
                break;
        }

        // tura krupiera
        Console.WriteLine("\nKarty krupiera:");
        dealer.Hand.Print();

        while (dealer.Hand.GetValue() < 17)
        {
            dealer.Hand.Add(deck.Draw());
            Console.WriteLine("Krupier dobiera...");
            dealer.Hand.Print();
        }

        // wynik
        int playerValue = player.Hand.GetValue();
        int dealerValue = dealer.Hand.GetValue();

        Console.WriteLine("\n=== WYNIK ===");
        Console.WriteLine($"Twoje punkty: {playerValue}");
        Console.WriteLine($"Punkty krupiera: {dealerValue}");

        if (dealerValue > 21 || playerValue > dealerValue)
            Console.WriteLine("Wygrałeś!");
        else if (dealerValue == playerValue)
            Console.WriteLine("Remis!");
        else
            Console.WriteLine("Przegrałeś!");
    }
}
