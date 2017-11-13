using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SelectSkill : View
{
    public int SkillID;

    public override string Name
    {
        get
        {
            return Consts.V_SelectSkill;
        }
    }

    void Start()
    {
        Button btn = this.GetComponent<Button>();
        btn.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {

        SendEvent(Consts.E_ShowSkillInfo, SkillID);
    }

    public override void HandleEvent(string eventName, object data)
    {

    }
}
