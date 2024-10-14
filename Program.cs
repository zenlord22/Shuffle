using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var deck = InitializeDeck();
        var playerHand = new List<string>();
        var random = new Random();

        // Draw initial 5 cards for the player
        for (int i = 0; i < 5; i++)
        {
            DrawCard(deck, playerHand, random);
        }

        while (deck.Count > 0)
        {
            Console.WriteLine("Player's hand: " + string.Join(", ", playerHand));
            Console.WriteLine("Press Enter to check for pairs...");
            Console.ReadLine();

            if (!HasPairs(playerHand, deck))
            {
                Console.WriteLine("No pairs found. Drawing a card and shuffling the deck...");
                DrawCard(deck, playerHand, random);
                deck = deck.OrderBy(x => random.Next()).ToList();
            }
        }

        Console.WriteLine("Game over! No more cards in the deck.");
    }

    static List<string> InitializeDeck()
    {
        var suits = new[] { "Hearts", "Diamonds", "Clubs", "Spades" };
        var ranks = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        var deck = new List<string>();

        foreach (var suit in suits)
        {
            foreach (var rank in ranks)
            {
                deck.Add($"{rank} of {suit}");
            }
        }

        return deck.OrderBy(x => Guid.NewGuid()).ToList();
    }

    static void DrawCard(List<string> deck, List<string> hand, Random random)
    {
        if (deck.Count == 0) return;

        int cardIndex = random.Next(deck.Count);
        var card = deck[cardIndex];
        deck.RemoveAt(cardIndex);
        hand.Add(card);

        Console.WriteLine($"Drew: {card}");
    }

    static bool HasPairs(List<string> hand, List<string> deck)
    {
        var rankCounts = hand.GroupBy(card => card.Split(' ')[0])
                             .ToDictionary(group => group.Key, group => group.Count());

        foreach (var rank in rankCounts.Keys)
        {
            if (rankCounts[rank] > 1)
            {
                var pair = hand.Where(card => card.StartsWith(rank)).Take(2).ToList();
                foreach (var card in pair)
                {
                    hand.Remove(card);
                    deck.Add(card);
                }
                Console.WriteLine($"Pair found: {string.Join(", ", pair)}. Placing them at the bottom of the deck.");
                return true;
            }
        }

        return false;
    }
}
