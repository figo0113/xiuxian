using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class EventPressHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    GameObject img;
    protected  void Start()
    {
        img = transform.Find("Image").gameObject;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        img.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        img.SetActive(false);
    }
}