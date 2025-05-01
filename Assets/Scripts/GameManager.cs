using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deckManager;
    public MarketManager marketManager;

    public PlayerManager playerManager;
    public OpponentManager opponentManager; // Assuming you have an OpponentManager

    void Start()
    {
        deckManager.InitializeDeck();
        playerManager.InitializePlayer(); // Initialize player with the deck
        opponentManager.InitializeOpponent(); // Initialize opponent manager
        marketManager.InitializeMarket();
    }

    void Update()
    {

    } 
}