using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DeckManager deckManager;
    public MarketManager marketManager;
    public MarketView marketView;

    void Start()
    {
        deckManager.InitializeDeck();
        marketManager.FillMarket(deckManager);
        marketView.ShowMarketCards(marketManager.marketCards);
    }
}