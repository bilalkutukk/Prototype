// Scripts/CardDisplay.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public CardData cardData;
    public Image artworkImage;
    public TMP_Text nameText;

    public void LoadCard(CardData data)
    {
        cardData = data;
        artworkImage.sprite = data.artwork;
        nameText.text = data.cardName;
    }
}