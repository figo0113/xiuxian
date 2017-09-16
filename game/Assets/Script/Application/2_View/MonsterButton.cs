using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MonsterButton : View
{
    public int MonsterID;
    public int MonsterIndex;

    public override string Name
    {
        get
        {
            return Consts.V_NPCButton;
        }
    }

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

        SendEvent(Consts.E_CommunicateMonster, new CommunicateMonsterArgs() { ID = MonsterID, MonsterListIndex= MonsterIndex } );
    }

    public override void HandleEvent(string eventName, object data)
    {

    }
}
