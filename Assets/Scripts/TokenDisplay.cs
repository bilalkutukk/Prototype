// Scripts/TokenDisplay.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenDisplay : MonoBehaviour
{
    public TokenData tokenData;
    public Image artworkImage;
    public TMP_Text nameText;
    public TMP_Text[] tokenPointText = new TMP_Text[4];

    public void LoadToken(TokenData data)
    {
         tokenData = data; //do I really need this?
         tokenPointText[0].text = data.tokenPointText[0];
         tokenPointText[1].text = data.tokenPointText[1];
         tokenPointText[2].text = data.tokenPointText[2];
         tokenPointText[3].text = data.tokenPointText[3];

        // Make sure data is valid
        if (artworkImage != null && data.artwork != null)
            artworkImage.sprite = data.artwork;

        if (nameText != null)
            nameText.text = data.tokenName;
    }
}