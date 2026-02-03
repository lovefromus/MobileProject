using UnityEngine;

public class CardData : MonoBehaviour
{
    // -------------------------
    // ENUMS (fixed categories)
    // -------------------------

    public enum Suit
    {
        Hearts,
        Diamonds,
        Clubs,
        Spades,
        Joker
    }

    // -------------------------
    // CARD IDENTITY
    // -------------------------

    [Header("Card Identity")]

    // 2–14 = normal cards
    // 11 = Jack
    // 12 = Queen
    // 13 = King
    // 14 = Ace
    // 15 = Joker (beats anything)
    [Range(2, 15)]
    public int rank;

    public Suit suit;

    // -------------------------
    // VISUAL STATE
    // -------------------------

    [Header("Visual State")]

    public bool isFaceUp = false;

    public Sprite frontSprite;
    public Sprite backSprite;

    private SpriteRenderer spriteRenderer;

    // -------------------------
    // UNITY LIFECYCLE
    // -------------------------

    private void Awake()
    {
        // Cache the SpriteRenderer once
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Safety check
        if (spriteRenderer == null)
        {
            Debug.LogError("CardData requires a SpriteRenderer component.");
        }

        // Ensure correct sprite at start
        UpdateVisual();
    }

    // -------------------------
    // PUBLIC METHODS
    // -------------------------

    /// <summary>
    /// Sets the card face-up or face-down
    /// This does NOT animate.
    /// Animation should handle flipping visually.
    /// </summary>
    public void SetFaceUp(bool faceUp)
    {
        isFaceUp = faceUp;
        UpdateVisual();
    }

    /// <summary>
    /// Returns true if this card beats another card
    /// Used for comparison logic only
    /// </summary>
    public bool Beats(CardData otherCard)
    {
        return rank > otherCard.rank;
    }

    // -------------------------
    // PRIVATE METHODS
    // -------------------------

    /// <summary>
    /// Updates the sprite based on face-up state
    /// </summary>
    private void UpdateVisual()
    {
        if (spriteRenderer == null)
            return;

        if (isFaceUp)
        {
            spriteRenderer.sprite = frontSprite;
        }
        else
        {
            spriteRenderer.sprite = backSprite;
        }
    }
}
