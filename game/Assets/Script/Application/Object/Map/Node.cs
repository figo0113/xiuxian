using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Node  {

    public string name;

    //坐标
    public string coordinate;

    //public int X;
    //public int Y;

    //连通节点
    public bool up;
    public bool down;
    public bool left;
    public bool right;

    //包含的NPC
    public List<int> includeNPC =null;
    public List<int> includeMonster = null;
    public List<int> includeCollection = null;//包含的采集物（道具）
    public Node(string name, string coordinate, bool up, bool down, bool left, bool right, List<int> includeNPC, List<int> includeMonster, List<int> includeCollection)
    {
        this.name = name;
        this.coordinate = coordinate;
        this.up = up;
        this.down = down;
        this.left = left;
        this.right = right;
        this.includeNPC = includeNPC;
        this.includeMonster = includeMonster;
        this.includeCollection = includeCollection;
    }

   

}
