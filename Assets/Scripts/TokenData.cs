using UnityEngine;

[CreateAssetMenu(fileName = "NewToken", menuName = "CardGame/Token")]
public class TokenData : ScriptableObject
{
    public string tokenName;
    public Sprite artwork;
    public int value;
}
