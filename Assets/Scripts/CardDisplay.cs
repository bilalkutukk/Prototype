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

        // Make sure data is valid
        if (artworkImage != null && data.artwork != null)
            artworkImage.sprite = data.artwork;

        if (nameText != null)
            nameText.text = data.cardName;
    }
}