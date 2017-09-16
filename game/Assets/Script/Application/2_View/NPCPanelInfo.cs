using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCPanelInfo : View
{
    public Text NPCDes;
    public Text NPCName;

    int m_ID;
    public override string Name
    {
        get
        {
            return Consts.V_NPCPanelinfo;
        }
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
                 m_ID = (int)data;
                
                initialize(m_ID);
                break;
        }
    }

    void initialize(int NPCID)
    {
        GameModel gm = GetModel<GameModel>();
        NPCDes.text = gm.NPCs[NPCID].des;
        NPCName.text = gm.NPCs[NPCID].name;
    }
    public void killBtnClick()
    {
        SendEvent(Consts.E_StartFight, new FightArgs() { TargetType = 1, ID = m_ID });

    }
}
