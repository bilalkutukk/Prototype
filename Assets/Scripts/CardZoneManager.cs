using UnityEngine;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
public class CardZoneManager : MonoBehaviour
{

    protected List<CardData> cards = new List<CardData>();
    public GameObject cardPrefab; // Prefab for the card display
    public Transform cardZoneRect; // UI container for the cards
    public DeckManager deckManager;

    private float spacing = 50f; // Space between cards
    private float startX = 0f; // Starting position for the first card
    public float cardSizeY = 300f; // Height of the card
    public float cardSizeX = 200f; // Width of the card
    public virtual void Initialize() {
        cards.Clear();
    }
    public virtual void AddCard() {
        cards.Add(deckManager.DrawCard());
        InstantiateCard(cards[cards.Count - 1]);
    }
    public virtual void RemoveCard(CardData card) {
        cards.Remove(card);
    }
    public virtual void Clear() {
        cards.Clear();
    }

    public virtual void setCardZoneRectSize() {
        RectTransform rt = cardZoneRect.GetComponent<RectTransform>();
        if (cards.Count == 0)
        {
            rt.sizeDelta = new Vector2(0, 0);
            startX = 0;
            return;
        }
        else 
        {
            rt.sizeDelta = new Vector2(cardSizeX * cards.Count + spacing * (cards.Count - 1) + spacing * 2, cardSizeY);
            startX = -(rt.sizeDelta.x / 2) + spacing + cardSizeX / 2;  
        }
    }

    public virtual void placeCards() {
        int i = 0;
        foreach (Transform child in cardZoneRect) 
        {
            RectTransform rt = child.GetComponent<RectTransform>();
            rt.localScale = Vector3.one; // Reset scale to 1 IS IT N
            rt.anchoredPosition = new Vector2(startX + (i++ *(spacing + cardSizeX)), 0);
        }
    }

    public virtual void InstantiateCard(CardData card) {
        GameObject cardGO = Instantiate(cardPrefab, cardZoneRect);
        CardDisplay display = cardGO.GetComponent<CardDisplay>();
        display.LoadCard(card);
    }

    public List<CardData> GetCards() {
        return new List<CardData>(cards);
    }    
}
