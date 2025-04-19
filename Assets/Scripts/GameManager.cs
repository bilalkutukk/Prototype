using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deckManager;
    public MarketManager marketManager;

    public PlayerManager playerManager;

    void Start()
    {
        deckManager.InitializeDeck();
        marketManager.InitializeMarket(deckManager);
        playerManager.InitializePlayer(deckManager); // Initialize player with the deck
    }
}