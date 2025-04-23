// Scripts/Managers/DeckManager.cs
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    public List<CardData> allCardTypes; // Fill this in Inspector
    public int[] cardQuantities;        // Matches allCardTypes
    private List<CardData> deck;

    public void InitializeDeck()
    {
        deck = new List<CardData>();

        for (int i = 0; i < allCardTypes.Count; i++)
        {
            for (int j = 0; j < cardQuantities[i]; j++)
            {
                deck.Add(allCardTypes[i]);
            }
        }
        Shuffle(deck);
    }

    private void Shuffle(List<CardData> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            CardData temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public CardData DrawCard()
    {
        if (deck.Count == 0) return null;

        CardData drawn = deck[0];
        deck.RemoveAt(0);
        return drawn;
    }

    public int CardsLeft => deck.Count;
}
