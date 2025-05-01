using UnityEngine;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
public class CardZoneManager : MonoBehaviour
{

    protected List<CardData> cards = new List<CardData>();
    public GameObject cardPrefab; // Prefab for the card display
    public Transform cardZoneRect; // UI container for the cards
    public DeckManager deckManager;

    private float _spacing = 50f; // Space between cards
    private float _startX = 0f; // Starting position for the first card
    private float _cardSizeY = 150f; // Height of the card
    private float _cardSizeX = 100f; // Width of the card
    public virtual void Initialize(int noOfCards) {
        cards.Clear();
         for (int i = 0; i < noOfCards; i++)
        {
            AddCard();
        }
        setCardZoneRectSize(); // Update the size of the opponent hand rect
        placeCards(); // Place the cards in the hand
    }
    public virtual void AddCard() {
        CardData newCard = deckManager.DrawCard();
        cards.Add(newCard);
        InstantiateCard(cards[cards.Count - 1]);
    }
    public virtual void setCardZoneRectSize() {
        RectTransform rt = cardZoneRect.GetComponent<RectTransform>();
        if (cards.Count == 0)
        {
            rt.sizeDelta = new Vector2(0, 0);
            _startX = 0;
            return;
        }
        else 
        {
            rt.sizeDelta = new Vector2(_cardSizeX * cards.Count + _spacing * (cards.Count - 1) + _spacing * 2, _cardSizeY);
            _startX = -(rt.sizeDelta.x / 2) + _spacing + _cardSizeX / 2;  
        }
    }
    public virtual void placeCards() {

        for (int i = 0; i < cards.Count; i++)
        {
            RectTransform rt = cards[i].cardRect;
            rt.localScale = Vector3.one;
            rt.anchoredPosition = new Vector2(_startX + (i *(_spacing + _cardSizeX)), 0);
            Debug.Log($"Card is placed at x: {rt.anchoredPosition.x}");
        }
    }

    private void InstantiateCard(CardData card) {
        GameObject cardGO = Instantiate(cardPrefab, cardZoneRect);
        card.instanceGO = cardGO;
        
        RectTransform rt = cardGO.GetComponent<RectTransform>();
        card.cardRect = rt;

        CardDisplay display = cardGO.GetComponent<CardDisplay>();
        display.LoadCard(card);
    }
}
