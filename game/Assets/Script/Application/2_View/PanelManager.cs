using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PanelManager : View,IPointerEnterHandler, IPointerExitHandler
{


    public float OffsetY = -700; //Y方向的偏移量
    public float time = 0.55f;
    private bool isin = false;
    private bool isopen = false;
    private Vector3 originalPos;

    
    public override string Name
    {
        get
        {
            return Consts.V_PanelManager;
        }
    }

    public void ShowPanel()
    {
        if (!isopen)
        {
            this.gameObject.SetActive(true);
            iTween.MoveBy(gameObject, iTween.Hash(
                "y", OffsetY,
                "easeType", iTween.EaseType.easeOutQuad,
                "loopType", iTween.LoopType.none,
                "time", time));
           
        }

    }

    public void ClosePanel()
    {

        this.gameObject.SetActive(false);
        this.gameObject.transform.position = originalPos;//new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - OffsetY, this.gameObject.transform.position.z);
        isopen = false;
    }

    private void Start()
    {
        originalPos = this.gameObject.transform.position;
    }
    private void Update()
    {

        if (Mathf.Abs( this.gameObject.transform.position.y - (originalPos.y + OffsetY))<0.5)
        {
            isopen = true;
        }

        if (isopen && !isin && Input.GetMouseButtonDown(0))
        {
            ClosePanel();
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
    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_CommunicateNPC);      
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_CommunicateNPC:
                //int NPCID =(int) data ;
                ShowPanel();
                break;         
        }
    }
}
