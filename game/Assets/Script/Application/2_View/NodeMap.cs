using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeMap : View
{

    public GameObject NodeCenter;
    public GameObject NodeUp;
    public GameObject NodeDown;
    public GameObject NodeLeft;
    public GameObject NodeRight;
    public GameObject NPCPanel;

    public Text NodeCenterTxt;
    public Text NodeUpTxt;
    public Text NodeDownTxt;
    public Text NodeLeftTxt;
    public Text NodeRightTxt;

    public GameObject UIHome;

    private string upPos;
    private string downPos;
    private string leftPos;
    private string rightPos;

    MapModel mm;
    GameModel gm;
    Map m_Map;
    public override string Name
    {
        get
        {
            return Consts.V_NodeMap;
        }
    }
    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_EnterInstance:
                int index = (int)data;
                mm = GetModel<MapModel>();
                gm = GetModel<GameModel>();
                mm.MapID = index;
                mm.SpawnMap();
                m_Map = mm.m_Map;
                LoadInstance();
                break;
            case Consts.E_BackInstance:
                mm = GetModel<MapModel>();
                gm = GetModel<GameModel>();
                //mm.SpawnMap();
                m_Map = mm.m_Map;
                BackInstance();
                break;
        }
    }
    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_EnterInstance);
        AttentionEvents.Add(Consts.E_BackInstance);
    }
    


     void LoadInstance()
    {
        mm.CurrentPos = m_Map.entranceIndex;        
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }

    void BackInstance()
    {
                
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }

    /*void Awake()
    {
        Debug.Log(NodeCenterTxt.text);
    }*/

    void UpdateAllNode() //参数是中心点坐标
    {
        string m_Pos = mm.CurrentPos;
        int i =int.Parse(m_Pos.Substring(0, m_Pos.IndexOf(","))); //横坐标
        int j = int.Parse(m_Pos.Substring( m_Pos.IndexOf(",")+1, m_Pos.Length - m_Pos.IndexOf(",")-1)); //纵坐标

        NodeCenterTxt.text = m_Map.allNode[mm.CurrentPos].name;

        //上方点
        if (!m_Map.allNode[mm.CurrentPos].up)
        {
            NodeUp.SetActive(false);
        }
        else
        {
            NodeUp.SetActive(true);
            upPos = i.ToString() + "," + (j+1).ToString();
            NodeUpTxt.text = m_Map.allNode[upPos].name;
        }
        //下方点
        if (!m_Map.allNode[mm.CurrentPos].down)
        {
            NodeDown.SetActive(false);
        }
        else
        {
            NodeDown.SetActive(true);
            downPos = i.ToString() + "," + (j - 1).ToString();
            NodeDownTxt.text = m_Map.allNode[downPos].name;
        }

        //左方点
        if (!m_Map.allNode[mm.CurrentPos].left)
        {
            NodeLeft.SetActive(false);
        }
        else
        {
            NodeLeft.SetActive(true);
            leftPos = (i-1).ToString() + "," + j.ToString();
            NodeLeftTxt.text = m_Map.allNode[leftPos].name;
        }
        //右方点
        if (!m_Map.allNode[mm.CurrentPos].right)
        {
            NodeRight.SetActive(false);
        }
        else
        {
            NodeRight.SetActive(true);
            rightPos = (i+1).ToString() + "," + j.ToString();
            NodeRightTxt.text = m_Map.allNode[rightPos].name;
        }
    }

    //显示NPC
    void ShowNPC()
    {
        int childCount = NPCPanel.transform.childCount;
        for (int i = 0; i < childCount; i++) 
        {
            Destroy(NPCPanel.transform.GetChild(i).gameObject);
        }
        foreach (int n in m_Map.allNode[mm.CurrentPos].includeNPC)
        {

            if (gm.NPCs[n].isdead == false)
            {
                GameObject NPC = (GameObject)Instantiate(Resources.Load("Prefab/NPC"));
                NPC.transform.parent = NPCPanel.transform;
                Text NPCname = NPC.transform.Find("name").GetComponent<Text>();
                NPCname.text = gm.NPCs[n].name;
                NPC.GetComponent<NPCButton>().NPCID = n;
            }
        }
    }

    void ShowMonster()
    {

         for(int i = 0; i< m_Map.allNode[mm.CurrentPos].includeMonster.Count;i++)
        {

                GameObject Monster = (GameObject)Instantiate(Resources.Load("Prefab/Monster"));
                Monster.transform.parent = NPCPanel.transform;
                Text Monstername = Monster.transform.Find("name").GetComponent<Text>();
                Monstername.text = Game.Instance.StaticData.getMonster(m_Map.allNode[mm.CurrentPos].includeMonster[i]).name;
                Monster.GetComponent<MonsterButton>().MonsterID = m_Map.allNode[mm.CurrentPos].includeMonster[i];
                Monster.GetComponent<MonsterButton>().MonsterIndex = i;

        }
    }
    void ShowCollection()
    {

        for (int i = 0; i < m_Map.allNode[mm.CurrentPos].includeCollection.Count; i++)
        {

            GameObject Collection = (GameObject)Instantiate(Resources.Load("Prefab/Collection"));
            Collection.transform.parent = NPCPanel.transform;
            Text Collectionname = Collection.transform.Find("name").GetComponent<Text>();
            Collectionname.text = Game.Instance.StaticData.GetItem(m_Map.allNode[mm.CurrentPos].includeCollection[i]).Name;
            Collection.GetComponent<CollectionButton>().ItemID = m_Map.allNode[mm.CurrentPos].includeCollection[i];
            Collection.GetComponent<CollectionButton>().CollectionIndex = i;

        }
    }
    //按钮事件
    public void NodeUpClick()
    {
        mm.CurrentPos = upPos;
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }

    public void NodeDownClick()
    {
        mm.CurrentPos = downPos;
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }
    public void NodeRightClick()
    {
        mm.CurrentPos = rightPos;
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }

    public void NodeLeftClick()
    {
        mm.CurrentPos = leftPos;
        UpdateAllNode();
        ShowNPC();
        ShowMonster();
        ShowCollection();
    }

    public void BackBtnClick()
    {
        gm.IsInstance = false;
        this.gameObject.SetActive(false);
        UIHome.SetActive(true);
    }

}
