using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : View
{
    public GameObject UIHome;
    public GameObject NodeMap;
    //public GameObject UIPlayer;


    public override string Name
    {
        get
        {
            return Consts.V_UIMain;
        }
    }

    void Start()
    {
        GameModel gm = GetModel<GameModel>();
        if (gm.IsInstance)
        {
            UIHome.SetActive(false);
            NodeMap.SetActive(true);
            SendEvent(Consts.E_BackInstance);
        }
        else
        {
            UIHome.SetActive(true);
            NodeMap.SetActive(false);
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

}
