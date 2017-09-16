using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIMoney : View {

    public Text goldText;

    public override string Name
    {
        get
        {
            return "UIMoney";
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    private void Awake()
    {
        
        GameModel gm = GetModel<GameModel>();
        goldText.text = Convert.ToString(gm.Gold);
        gm.goldChange += Gold_Change;
    }

    private void Gold_Change(int gold)
    {
        goldText.text = Convert.ToString(gold);
    }
}
