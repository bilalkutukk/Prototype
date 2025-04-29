using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using DG.Tweening;

public class PlayerManager : CardZoneManager
{

    public void InitializePlayer()
    {
        Initialize(5);
    }

    void Update ()
    {

        cards[0].cardRect.transform.DOMoveY(50, 0.1f).SetEase(Ease.InOutBounce).SetLoops(4, LoopType.Yoyo);;

    }
}
