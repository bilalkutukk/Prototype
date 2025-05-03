using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class CardZoneManager : MonoBehaviour
{
    protected List<CardData> cards = new List<CardData>();
    public GameObject cardPrefab;
    public Transform cardZoneRect;
    public DeckManager deckManager;

    public Button takeButton;
    public Button sellButton;
    public Button tradeButton;

    private float _spacing = 50f;
    private float _startX = 0f;
    private float _cardSizeY = 150f;
    private float _cardSizeX = 100f;

    public virtual void Initialize(int noOfCards)
    {
        cards.Clear();

        for (int i = 0; i < noOfCards; i++)
        {
            AddCard();
        }
    }

  public virtual void AddCard()
    {
        CardData newCard = deckManager.DrawCard();
        cards.Add(newCard);
        InstantiateCard(newCard);
        setCardZoneRectSize();  // update zone size immediately
        placeCards();           // re-place every card immediately
    }

    public virtual void setCardZoneRectSize()
    {
        RectTransform rt = cardZoneRect.GetComponent<RectTransform>();
        if (cards.Count == 0)
        {
            rt.sizeDelta = new Vector2(0, 0);
            _startX = 0;
            return;
        }

        rt.sizeDelta = new Vector2(
            _cardSizeX * cards.Count + _spacing * (cards.Count - 1) + _spacing * 2,
            _cardSizeY
        );

        _startX = -(rt.sizeDelta.x / 2) + _spacing + _cardSizeX / 2;
    }

    public virtual void placeCards()
    {
        for (int i = 0; i < cards.Count; i++)
        {
            RectTransform rt = cards[i].cardRect;

            CardInteractionHandler handler = cards[i].instanceGO.GetComponent<CardInteractionHandler>();

            rt.localScale = Vector3.one;
            Vector2 targetPos = new Vector2(_startX + (i * (_spacing + _cardSizeX)), 0);
            handler?.SetTargetPosition(targetPos);
        }
    }

    private void InstantiateCard(CardData card)
    {
        GameObject cardGO = Instantiate(cardPrefab, cardZoneRect);
        card.instanceGO = cardGO;

        RectTransform rt = cardGO.GetComponent<RectTransform>();
        card.cardRect = rt;

        CardDisplay display = cardGO.GetComponent<CardDisplay>();
        display.LoadCard(card);

        if (cardGO.TryGetComponent(out CardInteractionHandler handler))
        {
            handler.SetZone(this); // Connect card to this zone
        }
    }

    // Called by CardInteractionHandler on EndDrag
    public void HandleCardDrop(CardInteractionHandler draggedHandler)
    {
        RectTransform draggedRect = draggedHandler.GetComponent<RectTransform>();
        float draggedX = draggedRect.anchoredPosition.x;

        // Get CardData for this dragged card
        CardData draggedCard = cards.Find(card => card.instanceGO == draggedHandler.gameObject);
        if (draggedCard == null) return;

        cards.Remove(draggedCard);

        int newIndex = FindClosestIndex(draggedX);
        cards.Insert(newIndex, draggedCard);

        setCardZoneRectSize();
        placeCards();
    }

    private int FindClosestIndex(float x)
    {
        if (cards.Count == 0) return 0;

        int closestIndex = 0;
        float closestDistance = Mathf.Abs(cards[0].cardRect.anchoredPosition.x - x);

        for (int i = 1; i < cards.Count; i++)
        {
            float dist = Mathf.Abs(cards[i].cardRect.anchoredPosition.x - x);
            if (dist < closestDistance)
            {
                closestDistance = dist;
                closestIndex = i;
            }
        }
        return closestIndex;
    }
}
