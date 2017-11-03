using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class TextManager : View
{
    public float OffsetY = 40; //Y方向的偏移量
    public float time = 0.55f;

    public override string Name
    {
        get
        {
            return Consts.V_TextManager;
        }
    }

    public void ShowText(string[] textList)
    {

    }
    public override void HandleEvent(string eventName, object data)
    {

    }
}
