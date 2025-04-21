using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab for the card display
    public Transform playerHandRect; // UI container for the cards
    private float spacing = 250f; // Space between cards
    private float startX = -500f; // Starting position for the first card
    public List<CardData> playerCards = new List<CardData>();

    private float cardSizeY = 300f;
    private float cardSizeX = 200f;

    private float borderWidth = 100f;
    internal void InitializePlayer(DeckManager deckManager)
    {
        // Initialize player with the deck manager
        for (int i = 0; i < 3; i++)
        {
           AddCard(deckManager.DrawCard()); // Add existing cards to the player hand display
        }
    }

    public void ClearHand()
    {
        playerCards.Clear();
        foreach (Transform child in playerHandRect)
        {
            Destroy(child.gameObject);
        }
    }

    public void RemoveCard(CardData card)
    {
        playerCards.Remove(card);
        foreach (Transform child in playerHandRect)
        {
            CardDisplay display = child.GetComponent<CardDisplay>();
            if (display.cardData == card)
            {
                Destroy(child.gameObject);
                break;
            }
        }
    }

    public void AddCard(CardData card)
    {
        if (playerCards.Count < 7) // Assuming a max hand size of 7
        {
            playerCards.Add(card);
            setRectSize(); // Update the size of the player hand rect
            GameObject cardGO = Instantiate(cardPrefab, playerHandRect);
            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.LoadCard(card);
            placeCards(); // Place the cards in the hand
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void setRectSize() {
        RectTransform rt = playerHandRect.GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2(cardSizeX * playerCards.Count + 50 * (playerCards.Count - 1) + borderWidth, cardSizeY);
        
        Debug.Log("RectTransform size x: " + rt.sizeDelta.x);

        startX = -(rt.sizeDelta.x / 2) + 50 + cardSizeX / 2; 

        Debug.Log("StartX: " + startX);
    }

    private void placeCards() {
        int i = 0;
        foreach (Transform child in playerHandRect)
        {
            RectTransform rt = child.GetComponent<RectTransform>();
            rt.localScale = Vector3.one; // Reset scale to 1
            rt.anchoredPosition = new Vector2(startX + (i++ * spacing), 0);
            Debug.Log("Card position: " + rt.anchoredPosition.x);
        }
    }
}
