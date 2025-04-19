// Scripts/CardSpawner.cs
using System.Collections.Generic;
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
public GameObject cardPrefab;
    public Transform marketArea;
    public Transform playerHand;
    public List<CardData> marketCards;
    public List<CardData> playerCards;
    public float spacing = 200f;

    void Start()
    {

    }

    void SpawnCards(List<CardData> cards, Transform parent)
    {
        for (int i = 0; i < cards.Count; i++)
        {
            GameObject card = Instantiate(cardPrefab);
            card.transform.SetParent(parent, false);

            RectTransform rt = card.GetComponent<RectTransform>();
            rt.anchoredPosition = new Vector2(i * spacing, 0);

            card.GetComponent<CardDisplay>().LoadCard(cards[i]);
        }
    }
}
