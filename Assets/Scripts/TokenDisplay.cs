// Scripts/TokenDisplay.cs
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TokenDisplay : MonoBehaviour
{
    public TokenData tokenData;
    public Image artworkImage;
    public TMP_Text nameText;

    public void LoadToken(TokenData data)
    {
         tokenData = data;

        // Make sure data is valid
        if (artworkImage != null && data.artwork != null)
            artworkImage.sprite = data.artwork;

        if (nameText != null)
            nameText.text = data.tokenName;
    }
}