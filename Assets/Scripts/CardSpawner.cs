// Scripts/CardSpawner.cs
using UnityEngine;

public class CardSpawner : MonoBehaviour
{
    public GameObject cardPrefab;
    public Transform spawnPoint;
    public CardData testCard;

    void Start()
    {
        GameObject card = Instantiate(cardPrefab, spawnPoint.localPosition, Quaternion.identity);
        card.transform.SetParent(spawnPoint, false);
        card.GetComponent<CardDisplay>().LoadCard(testCard);

        Debug.Log("Card spawn point x and y: " + spawnPoint.position.x + ", " + spawnPoint.position.y);
    }
}
