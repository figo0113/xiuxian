using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapModel : Model
{
    public override string Name
    {
        get
        {
            return Consts.M_MapModel;
        }
    }

    public int MapID = 0;
    public Map m_Map;

    string currentPos;
    public string CurrentPos
    {
        get
        {
            return currentPos;
        }

        set
        {
            currentPos = value;
        }
    }

    public void SpawnMap()
    {
        m_Map = Game.Instance.StaticData.GetMap(MapID).DeepClone();
    }
  
    

}
