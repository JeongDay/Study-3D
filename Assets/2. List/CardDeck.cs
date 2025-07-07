using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    private List<string> deck = new List<string> { "A", "B", "C", "D", "E" };
    public int shakeCount = 100;
    
    IEnumerator Start()
    {
        PrintDeck();
        yield return new WaitForSeconds(1f);

        ShuffleDeck();
        PrintDeck();
        yield return new WaitForSeconds(1f);

        string card = DrawCard();
        Debug.Log("Drawn: " + card);
        yield return new WaitForSeconds(1f);

        Debug.Log($"{deck[0]}, {deck[1]}, {deck[2]}, {deck[3]}");
        yield return new WaitForSeconds(1f);
    }

    void ShuffleDeck()
    {
        for (int i = 0; i < shakeCount; i++)
        {
            var ranInt1 = Random.Range(0, deck.Count);
            var ranInt2 = Random.Range(0, deck.Count);

            var temp = deck[ranInt1];
            deck[ranInt1] = deck[ranInt2];
            deck[ranInt2] = temp;
        }
    }

    string DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.LogWarning("Deck is Empty");
            return null;
        }

        string drawn = deck[0];
        deck.RemoveAt(0);

        return drawn;
    }

    void PrintDeck()
    {
        Debug.Log($"{deck[0]}, {deck[1]}, {deck[2]}, {deck[3]}, {deck[4]}");
    }
}