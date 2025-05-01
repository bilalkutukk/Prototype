
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class CardInteractionHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private RectTransform rectTransform;
    private bool isSelected = false;
    private Vector2 originalPosition;
    private Tween scaleTween;

    public float hoverScaleAmount = 1.1f;
    public float selectionShiftY = 15f;
    public float animationDuration = 0.2f;

    private bool hasCachedOriginal = false;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!hasCachedOriginal)
        {
            originalPosition = rectTransform.anchoredPosition;
            hasCachedOriginal = true;
        }
        Debug.Log($"Pointer Entered: {originalPosition}");
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
        scaleTween = rectTransform.DOScale(hoverScaleAmount, animationDuration).SetEase(Ease.OutBack).SetId(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
        rectTransform.DOScale(1f, animationDuration).SetEase(Ease.InBack);
        rectTransform.DOAnchorPos(isSelected ? originalPosition + Vector2.up * selectionShiftY : originalPosition, animationDuration);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        isSelected = !isSelected;
        Debug.Log($"Pointer Clicked: {originalPosition}");
        Vector2 targetPos = isSelected
            ? originalPosition + Vector2.up * selectionShiftY
            : originalPosition;

        rectTransform.DOAnchorPos(targetPos, animationDuration);
    }

    void OnDisable()
    {
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
    }
}
