using System;
using UnityEngine;
using System.Collections.Generic;

public class OpponentManager : CardZoneManager
{
  public void InitializeOpponent()
  {
    // Initialize opponent with the deck manager
    for (int i = 0; i < 3; i++)
    {
      AddCard();
    }
    setCardZoneRectSize(); // Update the size of the opponent hand rect
    placeCards(); // Place the cards in the hand
  }
}
