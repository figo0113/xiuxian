using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIWin : View
{
    int targetType;
    int targetID;
    public GameObject ItemPanel;

    public override string Name
    {
        get
        {
            return Consts.V_UIWin;
        }
    }


    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_Win:
                FightArgs e = data as FightArgs;
                targetType = e.TargetType;
                targetID = e.ID;
                this.gameObject.SetActive(true);
                drop();
                break;
        }
    }

    void drop()
    {
        GameModel gm = GetModel<GameModel>();
        if (targetType == 2)
        {
            Monster monster = Game.Instance.StaticData.getMonster(targetID);
            int itemID;
            itemID = Formula.DropItem(monster.drop,gm.player.Luck);
            if(itemID ==0)
                return;
            gm.PickupItem2(itemID);
            GameObject Item = (GameObject)Instantiate(Resources.Load("Prefab/Item"));
            Item.transform.parent = ItemPanel.transform;
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Close();
            Game.Instance.LoadScene(2);
        }
    }

    void Close()
    {
        this.gameObject.SetActive(false);
    }

    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_Win);
    }
}
