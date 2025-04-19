using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "CardGame/Card")]
public class CardData : ScriptableObject
{
    public string cardName;
    public Sprite artwork;
    public int value;
}
