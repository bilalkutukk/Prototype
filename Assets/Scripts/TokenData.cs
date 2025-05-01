using UnityEngine;

[CreateAssetMenu(fileName = "NewToken", menuName = "CardGame/Token")]
public class TokenData : ScriptableObject
{
    public string tokenName;
    public Sprite artwork;
    public int value;
    public RectTransform tokenRect; // Reference to the card's transform in the UI
    public GameObject instanceGO; // Reference to the card's transform in the UI
}
