using UnityEngine;
using UnityEngine.EventSystems;
public class test : MonoBehaviour, IPointerEnterHandler
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
     public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Hovered this button!");
    }
}
