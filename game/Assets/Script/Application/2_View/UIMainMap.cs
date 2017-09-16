using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMainMap : View {
    public GameObject NodeMap;

    public override string Name
    {
        get
        {
            return Consts.V_UIMainMap;

        }
    }

    public override void HandleEvent(string eventName, object data)
    {
      
    }

    public void GoBtnClick()
    {
        this.gameObject.SetActive(false);
        NodeMap.SetActive(true);
        GameModel gm = GetModel<GameModel>();
        gm.IsInstance = true;
        SendEvent(Consts.E_EnterInstance,1);

    }

}
