using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemUseButton : View
{

    public int itemID;

    public override string Name
    {
        get
        {
            return Consts.V_ItemUseButton;
        }
    }

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

        SendEvent(Consts.E_ItemUse, itemID);
    }

    public override void HandleEvent(string eventName, object data)
    {

    }
}
