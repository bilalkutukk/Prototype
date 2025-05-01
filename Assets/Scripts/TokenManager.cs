using UnityEngine;
using System.Collections.Generic;

public class TokenManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject tokenPrefab; // Prefab for the token display
    public Transform tokenZone; // Parent transform for the token zone
    public List<TokenData> allTokenTypes; // Fill this in Inspector
    public int[] tokenQuantities; // Token stacks
    private List<TokenData> diamondTokens = new List<TokenData>();
    private List<TokenData> goldTokens = new List<TokenData>();
    private List<TokenData> silverTokens = new List<TokenData>();
    private List<TokenData> clothTokens = new List<TokenData>();
    private List<TokenData> spiceTokens = new List<TokenData>();
    private List<TokenData> leatherTokens = new List<TokenData>();
    private List<TokenData> bonus3Tokens = new List<TokenData>();
    private List<TokenData> bonus4Tokens = new List<TokenData>();
    private List<TokenData> bonus5Tokens = new List<TokenData>();
    private List<TokenData> bonus3SpecialTokens = new List<TokenData>();

    private TokenData camelToken; // Reference to the camel token
    private TokenData ExcellenceTokenMale;
    private TokenData ExcellenceTokenFemale;

    // Value arrays
    private readonly int[] diamondValues = { 5, 5, 7, 7, 7 };
    private readonly int[] goldValues    = { 5, 5, 5, 6, 6 };
    private readonly int[] silverValues  = { 5, 5, 5, 5, 5 };
    private readonly int[] clothValues   = { 1, 2, 2, 2, 3, 3, 5 };
    private readonly int[] spiceValues   = { 1, 1, 2, 2, 3, 3, 3 };
    private readonly int[] leatherValues = { 1, 1, 1, 1, 1, 1, 2, 3, 4 };

    private readonly int[] bonus3Values  = { 3, 3, 3, 4, 4, 5 };
    private readonly int[] bonus4Values  = { 4, 5, 6, 7, 7, 8 };
    private readonly int[] bonus5Values  = { 8, 8, 9, 10, 10, 11 };
    private readonly int[] bonus3SpecialValues = { 7, 7, 7};

    public void Initialize()
    {
        for (int i = 0; i < allTokenTypes.Count; i++)
        {
            string tokenName = allTokenTypes[i].tokenName;
            int quantity = tokenQuantities[i];

            for (int j = 0; j < quantity; j++)
            {
                TokenData token = ScriptableObject.Instantiate(allTokenTypes[i]);

                if (tokenName == "diamond")
                {
                    token.value = diamondValues[j];
                    diamondTokens.Add(token);
                }
                else if (tokenName == "gold")
                {
                    token.value = goldValues[j];
                    goldTokens.Add(token);
                }
                else if (tokenName == "silver")
                {
                    token.value = silverValues[j];
                    silverTokens.Add(token);
                }
                else if (tokenName == "cloth")
                {
                    token.value = clothValues[j];
                    clothTokens.Add(token);
                }
                else if (tokenName == "spice")
                {
                    token.value = spiceValues[j];
                    spiceTokens.Add(token);
                }
                else if (tokenName == "leather")
                {
                    token.value = leatherValues[j];
                    leatherTokens.Add(token);
                }
                else if (tokenName == "bonus3")
                {
                    token.value = bonus3Values[Random.Range(0, bonus3Values.Length)];
                    bonus3Tokens.Add(token);
                }
                else if (tokenName == "bonus4")
                {
                    token.value = bonus4Values[Random.Range(0, bonus4Values.Length)];
                    bonus4Tokens.Add(token);
                }
                else if (tokenName == "bonus5")
                {
                    token.value = bonus5Values[Random.Range(0, bonus5Values.Length)];
                    bonus5Tokens.Add(token);
                }
                else if (tokenName == "bonus3Special")
                {
                    token.value = bonus3SpecialValues[Random.Range(0, bonus3SpecialValues.Length)];
                    bonus3SpecialTokens.Add(token);
                }
                else if (tokenName == "camel")
                {
                    token.value = 5;
                    camelToken = token; // Set the camel token reference
                }
                else if (tokenName == "excellenceMale")
                {
                    token.value = 0; // Set value to 0 for ExcellenceTokenMale
                    ExcellenceTokenMale = token;
                }
                else if (tokenName == "excellenceFemale")
                {
                    token.value = 0; // Set value to 0 for ExcellenceTokenFemale
                    ExcellenceTokenFemale = token;
                }
                token.tokenPointText[0] = token.value.ToString();
                token.tokenPointText[1] = token.value.ToString();
                token.tokenPointText[2] = token.value.ToString();
                token.tokenPointText[3] = token.value.ToString();
            }
        }
        placeAllTokens(); // Call to place all tokens after initialization
    }

    public void placeAllTokens()
    {
        // Place all tokens in their respective zones
        PlaceTokens(diamondTokens, new Vector2(-100, 300), 30);
        PlaceTokens(goldTokens, new Vector2(-100, 200), 30);
        PlaceTokens(silverTokens, new Vector2(-100, 100), 30);
        PlaceTokens(clothTokens, new Vector2(-100, 0), 30);
        PlaceTokens(spiceTokens, new Vector2(-100, -100), 30);
        PlaceTokens(leatherTokens, new Vector2(-100, -200), 30);
        PlaceTokens(bonus3Tokens, new Vector2(-100, -300), 10);
        PlaceTokens(bonus4Tokens, new Vector2(0, -300), 10);
        PlaceTokens(bonus5Tokens, new Vector2(100, -300), 10);
        PlaceTokens(bonus3SpecialTokens, new Vector2(200, -300), 10);

        // Place camel token separately if needed
        if (camelToken != null)
            PlaceTokens(new List<TokenData> { camelToken }, new Vector2(-100, -400), 30);
        // Excellence tokens can be placed similarly if needed
        if (ExcellenceTokenMale != null)
            PlaceTokens(new List<TokenData> { ExcellenceTokenMale }, new Vector2(0, -400), 30);
        if (ExcellenceTokenFemale != null)
            PlaceTokens(new List<TokenData> { ExcellenceTokenFemale }, new Vector2(100, -400), 30);
    }
    public void PlaceTokens(List<TokenData> tokenList, Vector2 startPos, float xSpacing)
    {
        for (int i = 0; i < tokenList.Count; i++)
        {
            TokenData tokenData = tokenList[i];

            GameObject tokenGO = Instantiate(tokenPrefab, tokenZone);
            RectTransform rect = tokenGO.GetComponent<RectTransform>();
            rect.localScale = Vector3.one; // Reset scale to 1
            rect.anchoredPosition = new Vector2(startPos.x + i * xSpacing, startPos.y);

            TokenDisplay display = tokenGO.GetComponent<TokenDisplay>();
            display.LoadToken(tokenData); // Applies image, name, values, etc.

            // Store instance reference (optional but helpful)
            tokenData.instanceGO = tokenGO;
            tokenData.tokenRect = rect;
        }
    }
}