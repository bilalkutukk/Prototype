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
    }

    void Update ()
    {
        

    }


}
