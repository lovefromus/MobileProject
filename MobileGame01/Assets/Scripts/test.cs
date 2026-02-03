using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        Deck deck = GetComponent<Deck>();
        deck.CreateDeck();
        Debug.Log(deck.CardCount()); // MUST print 54
    }
}