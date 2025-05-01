using UnityEngine;
using DG.Tweening;

public class PlayerManager : CardZoneManager
{

    public void InitializePlayer()
    {
        Initialize(5);
        RectTransform cardd = cards[0].cardRect;
        cardd.DOMoveY(cardd.position.y + 40.0f, 0.5f)
            .SetEase(Ease.InOutSine)  // Smooth ease
            .SetLoops(-1, LoopType.Yoyo);  // Loop infinitely and go back and forth

        int i = 0;
        foreach (CardData child in cards) {
            Debug.Log($" For each Player Card name is {child.cardName} and its order is {i++}");
        }

        for (i = 0; i < 5; i++)
        {
            CardData card = cards[i];
            Debug.Log($" Only For Player Card name is {card.cardName} and its order is {i}");
        }
    }

    void Update ()
    {
        

    }
}
