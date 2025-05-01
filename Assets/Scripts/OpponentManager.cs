using System;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;
public class OpponentManager : CardZoneManager
{
  public void InitializeOpponent()
  {
    Initialize(7);

    RectTransform cardd = cards[3].cardRect;
        cardd.DOMoveY(cardd.position.y + 40.0f, 0.5f)
            .SetEase(Ease.InOutSine)  // Smooth ease
            .SetLoops(-1, LoopType.Yoyo);  // Loop infinitely and go back and forth
  }
  void Update ()
    {
            
    }
  

}
