using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;
using System;

public class CardInteractionHandler : MonoBehaviour, 
    IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;

    private bool isSelected = false;
    public bool isDragging { get; private set; } = false;
    private Vector2 originalPosition;

    public float hoverScaleAmount = 1.1f;
    public float selectionShiftY = 15f;
    public float animationDuration = 0.2f;

    private Tween scaleTween;

    private CardZoneManager currentZone;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        originalPosition = rectTransform.anchoredPosition;
    }

    public void SetZone(CardZoneManager zone)
    {
        currentZone = zone;
    }

    public void SetTargetPosition(Vector2 targetPos)
    {
        rectTransform.anchoredPosition = targetPos;
        originalPosition = targetPos;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
        scaleTween = rectTransform.DOScale(hoverScaleAmount, animationDuration).SetEase(Ease.OutBack).SetId(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
        rectTransform.DOScale(1f, animationDuration).SetEase(Ease.InBack);

        rectTransform.DOAnchorPos(
            isSelected ? originalPosition + Vector2.up * selectionShiftY : originalPosition,
            animationDuration
        );
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isDragging) return; // Ignore clicks while dragging
        
        isSelected = !isSelected;

        Vector2 targetPos = isSelected
            ? originalPosition + Vector2.up * selectionShiftY
            : originalPosition;

        rectTransform.DOAnchorPos(targetPos, animationDuration);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        isDragging = true;
        originalPosition = rectTransform.anchoredPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 globalMousePos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(
            rectTransform.parent as RectTransform,
            eventData.position,
            eventData.pressEventCamera,
            out globalMousePos))
        {
            rectTransform.anchoredPosition = globalMousePos;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        isDragging = false;

        currentZone?.HandleCardDrop(this); // Let the zone handle reordering
    }

    void OnDisable()
    {
        if (scaleTween != null && scaleTween.IsActive()) scaleTween.Kill();
    }
}
