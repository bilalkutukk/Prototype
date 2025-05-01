using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deckManager;
    public MarketManager marketManager;

    public PlayerManager playerManager;
    public OpponentManager opponentManager;

    public TokenManager tokenManager; // Reference to the TokenManager

    void Start()
    {
        deckManager.InitializeDeck();
        playerManager.InitializePlayer(); // Initialize player with the deck
        opponentManager.InitializeOpponent(); // Initialize opponent manager
        marketManager.InitializeMarket();
        tokenManager.Initialize(); // Initialize the token manager
    }

    void Update()
    {

    } 
}