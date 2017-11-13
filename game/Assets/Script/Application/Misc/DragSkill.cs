using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System;

public class DragSkill : View, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    private Vector2 Local_Pointer_Position;
    private Vector3 Panel_Local_Position;
    private GameObject clone;
    private RectTransform targetObject;
    private RectTransform cloneObject;
    private RectTransform parentRectTransform;  //父窗口矩阵  
    private RectTransform targetRectTransform; //移动目标矩阵 
    private RectTransform cloneParentRectTransform;
    public int SkillID;

    public override string Name
    {
        get
        {
            return Consts.V_DragSkill;
        }
    }

    void Awake()
    {
        if (targetObject == null)
        {
            targetObject = this.transform as RectTransform;
        }

        parentRectTransform = targetObject.parent as RectTransform;
        targetRectTransform = targetObject as RectTransform;


    }

    public void OnPointerDown(PointerEventData data)
    {
        GameObject go = GameObject.Find("UIMain/UISkill");
        cloneParentRectTransform = go.transform as RectTransform;
        clone = (GameObject)Instantiate(this.gameObject, this.transform.position, Quaternion.identity);
        clone.transform.parent = cloneParentRectTransform;
        cloneObject = clone.transform as RectTransform;
       
        Panel_Local_Position = cloneObject.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out Local_Pointer_Position);
        clone.transform.SetAsLastSibling();//保证当前操作的对象能够优先渲染，即不会被其它对象遮挡住  

    }


    public void OnPointerUp(PointerEventData data)
    {
         Destroy(clone);         
         SendEvent(Consts.E_AddFightSkill, new AddFightSkill() { pos = clone.transform.position, id = SkillID });
    }

    public void OnDrag(PointerEventData data)
    {

        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out localPointerPosition))
        {
            Vector3 offsetToOriginal = localPointerPosition - Local_Pointer_Position;

            cloneObject.localPosition = Panel_Local_Position + offsetToOriginal;
        }

    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }
}