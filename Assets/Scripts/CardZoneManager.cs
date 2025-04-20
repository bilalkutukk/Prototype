using UnityEngine;
using System.Collections.Generic;
public abstract class CardZoneManager : MonoBehaviour
{

    protected List<CardData> cards = new List<CardData>();

    public virtual void Initialize() {
        cards.Clear();
    }
    public virtual void AddCard(CardData card) {
        cards.Add(card);
    }
    public virtual void RemoveCard(CardData card) {
        cards.Remove(card);
    }
    public virtual void Clear() {
        cards.Clear();
    }
    public List<CardData> GetCards() {
        return new List<CardData>(cards);
    }    
}
