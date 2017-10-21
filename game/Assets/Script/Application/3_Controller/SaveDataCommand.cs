using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class SaveDataCommand : Controller
{
    public override void Execute(object date)
    {

        GameModel gm = GetModel<GameModel>();
        MapModel mm = GetModel<MapModel>();

        if (gm.IsInstance)
        {
            gm.MapID = mm.MapID;
            gm.currentPos = mm.CurrentPos;
            gm.m_Map = mm.m_Map;
            IOHelper.SetData(Consts.saveFileName, gm);
        }
        else
        {
            IOHelper.SetData(Consts.saveFileName, gm);
        }
    }
}
