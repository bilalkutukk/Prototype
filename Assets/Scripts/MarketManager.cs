// Scripts/Managers/MarketManager.cs
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public List<CardData> marketCards = new List<CardData>();
    public int maxMarketSize = 5;

    public void FillMarket(DeckManager deckManager)
    {
        while (marketCards.Count < maxMarketSize && deckManager.CardsLeft > 0)
        {
            CardData drawn = deckManager.DrawCard();
            if (drawn != null)
            {
                marketCards.Add(drawn);
            }
        }
    }

    public void ClearMarket()
    {
        marketCards.Clear();
    }

    public void RemoveCard(CardData card)
    {
        marketCards.Remove(card);
    }
}
