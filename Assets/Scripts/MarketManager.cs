// Scripts/Managers/MarketManager.cs
using System.Collections.Generic;
using UnityEngine;

public class MarketManager : MonoBehaviour
{
    public List<CardData> marketCards = new List<CardData>();
    public int maxMarketSize = 5;
    public GameObject cardPrefab;
    public Transform marketArea; // UI container
    public float spacing = 50f; 
    public float startX = -500f;

    public void InitializeMarket(DeckManager deckManager)
    {
        while (marketCards.Count < maxMarketSize && deckManager.CardsLeft > 0)
        {
            CardData drawn = deckManager.DrawCard();
            if (drawn != null)
            {
                AddCard(drawn); // Add the drawn card to the market display
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
    
    public void AddCard(CardData card)
    {
        if (marketCards.Count < maxMarketSize)
        {
            marketCards.Add(card);
            GameObject cardGO = Instantiate(cardPrefab, marketArea);
            RectTransform rt = cardGO.GetComponent<RectTransform>();
            rt.localScale = Vector3.one; // Reset scale to 1
            rt.anchoredPosition = new Vector2(startX + (marketCards.Count - 1) * spacing, 0);

            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.LoadCard(card);
        }
    }
}
