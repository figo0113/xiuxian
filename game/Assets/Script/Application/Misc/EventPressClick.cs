using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class EventPressClick : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler

{
    private bool isin = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(this.gameObject.activeSelf&&!isin&&Input.GetMouseButton(0))
        {
            this.gameObject.SetActive(false);
        }
	}

    public void OnPointerEnter(PointerEventData eventData)//当鼠标在目标UI
    {
        isin = true;
    }

    public void OnPointerExit(PointerEventData eventData)//当鼠标移除目标UI
    {
        isin = false;
    }

    void click()
    {
        isin = true;
    }

}
