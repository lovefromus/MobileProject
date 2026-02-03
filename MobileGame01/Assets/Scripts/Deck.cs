using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    // -------------------------
    // INSPECTOR REFERENCES
    // -------------------------

    [Header("Deck Setup")]

    // Assign your Card prefab here
    public GameObject cardPrefab;

    // Parent transform to keep hierarchy clean
    public Transform deckParent;

    // -------------------------
    // INTERNAL DATA
    // -------------------------

    private List<CardData> cards = new List<CardData>();

    // -------------------------
    // PUBLIC METHODS
    // -------------------------

    /// <summary>
    /// Creates a full 54-card deck
    /// </summary>
    public void CreateDeck()
    {
        cards.Clear();

        // Create standard cards (2–Ace)
        CreateStandardCards();

        // Create 2 Jokers
        CreateJokers();

        Shuffle();
    }

    /// <summary>
    /// Shuffles the deck using Fisher-Yates
    /// </summary>
    public void Shuffle()
    {
        for (int i = cards.Count - 1; i > 0; i--)
        {
            int randomIndex = Random.Range(0, i + 1);

            CardData temp = cards[i];
            cards[i] = cards[randomIndex];
            cards[randomIndex] = temp;
        }
    }

    /// <summary>
    /// Draws the top card from the deck
    /// Returns null if deck is empty
    /// </summary>
    public CardData DrawTopCard()
    {
        if (cards.Count == 0)
        {
            return null;
        }

        CardData topCard = cards[0];
        cards.RemoveAt(0);

        return topCard;
    }

    /// <summary>
    /// Returns the number of cards left in the deck
    /// </summary>
    public int CardCount()
    {
        return cards.Count;
    }

    // -------------------------
    // PRIVATE METHODS
    // -------------------------

    private void CreateStandardCards()
    {
        foreach (CardData.Suit suit in System.Enum.GetValues(typeof(CardData.Suit)))
        {
            if (suit == CardData.Suit.Joker)
                continue;

            // Ranks 2–14
            for (int rank = 2; rank <= 14; rank++)
            {
                CreateCard(rank, suit);
            }
        }
    }

    private void CreateJokers()
    {
        CreateCard(15, CardData.Suit.Joker);
        CreateCard(15, CardData.Suit.Joker);
    }

    private void CreateCard(int rank, CardData.Suit suit)
    {
        GameObject cardObject = Instantiate(cardPrefab, deckParent);

        CardData cardData = cardObject.GetComponent<CardData>();

        if (cardData == null)
        {
            Debug.LogError("Card prefab is missing CardData.");
            return;
        }

        cardData.rank = rank;
        cardData.suit = suit;
        cardData.SetFaceUp(false);

        cards.Add(cardData);
    }
}
