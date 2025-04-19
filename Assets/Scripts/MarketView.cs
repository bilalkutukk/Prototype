// Scripts/Views/MarketView.cs
using System.Collections.Generic;
using UnityEngine;

public class MarketView : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform marketArea; // UI container
    public float spacing = 250f;

    public void ShowMarketCards(List<CardData> cards)
    {
        // Clear old cards first
        foreach (Transform child in marketArea)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < cards.Count; i++)
        {
            GameObject cardGO = Instantiate(cardPrefab, marketArea);
            RectTransform rt = cardGO.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * spacing, 0);

            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.LoadCard(cards[i]);
        }
    }
}
