using System;
using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public GameObject cardPrefab; // Prefab for the card display
    public Transform playerHandRect; // UI container for the cards
    public float spacing = 50f; // Space between cards
    public float startX = -500f; // Starting position for the first card
    public List<CardData> playerCards = new List<CardData>(); 

    internal void InitializePlayer(DeckManager deckManager)
    {
        // Initialize player with the deck manager
        for (int i = 0; i < playerCards.Count; i++)
        {
           AddCard(playerCards[i]); // Add existing cards to the player hand display
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
            GameObject cardGO = Instantiate(cardPrefab, playerHandRect);
            RectTransform rt = cardGO.GetComponent<RectTransform>();
            rt.localScale = Vector3.one; // Reset scale to 1
            
            rt.anchoredPosition = new Vector2(startX + (playerCards.Count - 1) * spacing, 0);

            CardDisplay display = cardGO.GetComponent<CardDisplay>();
            display.LoadCard(card);
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
}
