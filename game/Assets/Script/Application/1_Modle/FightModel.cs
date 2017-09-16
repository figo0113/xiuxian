using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightModel : Model
{
    public override string Name
    {
        get
        {
            return Consts.M_FightModel;
        }
    }

    public int targetType = 0;//目标类型 1--NPC 2--Monster
    public int targetID = 0;
    //public Monster targetMonster;
    //public NPC targetNpc;
    public Role targetRole;
    public int MonsterListIndex;//在列表中的位置

    public void LoadFightModel(FightArgs e )
    {
        targetType = e.TargetType;
        targetID = e.ID;
        if (targetType == 2)
        {
            targetRole = Game.Instance.StaticData.SpawnMonster(targetID);
            MonsterListIndex = e.MonsterListIndex;
        }
        if (targetType == 1)
        {
            GameModel gm = GetModel<GameModel>();
            targetRole = gm.NPCs[e.ID];
            
        }

    }


}
