using UnityEngine;

public class WarComparer : MonoBehaviour
{
    // -------------------------
    // COMPARISON RESULT
    // -------------------------

    public enum ComparisonResult
    {
        PlayerOneWins,
        PlayerTwoWins,
        War
    }

    // -------------------------
    // PUBLIC METHOD
    // -------------------------

    /// <summary>
    /// Compares two cards and returns the result
    /// </summary>
    public ComparisonResult Compare(CardData playerOneCard, CardData playerTwoCard)
    {
        // Safety checks
        if (playerOneCard == null || playerTwoCard == null)
        {
            Debug.LogError("Compare called with null CardData.");
            return ComparisonResult.War;
        }

        // Same rank = War
        if (playerOneCard.rank == playerTwoCard.rank)
        {
            return ComparisonResult.War;
        }

        // Higher rank wins
        if (playerOneCard.rank > playerTwoCard.rank)
        {
            return ComparisonResult.PlayerOneWins;
        }
        else
        {
            return ComparisonResult.PlayerTwoWins;
        }
    }
}