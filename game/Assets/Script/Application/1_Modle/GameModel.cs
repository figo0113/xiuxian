using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

public class GameModel : Model
{


    #region 常量
    #endregion

    #region 事件
    #endregion

    #region 字段

    public event Action<int> goldChange;
    
    //关卡进度
    int m_GameProgress = -1;
    //仙玉
    int m_gold = 0;
    //是否游戏中
    bool m_isNewGame = false; //是否新游戏
    bool isInstance = false;//是否在副本

    public int MapID = 0; //所在副本
    public string currentPos; //在副所在节点
    public Map m_Map;

    public Dictionary<int, NPC> NPCs= new Dictionary<int, NPC>();
    public List<BackpackGrid> Backpack = new List<BackpackGrid>(); //背包数据
    public Player player; //角色数据

    public string saveFileName;

    #endregion
    #region 属性
    public override string Name
    {
        get
        { return Consts.M_GameModel; }
    }

  

    public int Gold
    {
        get
        {
            return m_gold;
        }

        set
        {
            //减少重复
            if (value == m_gold)
                return;

            m_gold = value;
            if (goldChange != null)
                goldChange(m_gold);
        }
    }

    public bool IsNewGame
    {
        get
        {
            return m_isNewGame;
        }

        set
        {
            m_isNewGame = value;
        }
    }

    //是否全部通关
    public int GameProgress
    {
        get
        {
            return m_GameProgress;
        }

    }

    //是否在副本中
    public bool IsInstance 
    {
        get
        {
            return isInstance;
        }

        set
        {
            isInstance = value;
        }
    }

    #endregion

    #region 方法
    //初始化
    public void initialize() 
    {



        if (IsNewGame == true)
        {
            Gold = 1000;//初始金币                      
            ParseNPCJson(); //NPC初始化
            player = new Player("小小",1,80,100,15,100,80,80,1,50,0,100,40,9500,500,0,0,120,500,500);
        }
        else
        {
            
            GameModel gm = (GameModel)IOHelper.GetData(Consts.saveFileName, typeof(GameModel));
            MVC.RegisterModel(gm);
            //Debug.Log(gm.isInstance);
            if (gm.IsInstance)
            {
                MapModel mm = GetModel<MapModel>();
                mm.MapID = gm.MapID;
                mm.CurrentPos = gm.currentPos;
                mm.m_Map = gm.m_Map;

            }
            
        }
        
    }

    public void PickupItem(int itemid)
    {
        Item targetItem = Game.Instance.StaticData.GetItem(itemid);
        for(int i = 0; i< Backpack.Count; i++)
        {
            if (Backpack[i].Item.ID == itemid)//如果有相同物品
            {
                if (Backpack[i].Count < targetItem.Capacity) //堆叠数没满
                {
                    Backpack[i].Count++;
                    SendEvent(Consts.E_AddItemCount, i);
                    return;
                }
               /* else
                {                                       
                    Backpack.Add(new BackpackGrid(targetItem,1));//另占一个格子
                    return;
                }*/
            }           
        }

        Backpack.Add(new BackpackGrid(targetItem, 1));
        SendEvent(Consts.E_AddItem,itemid);
    }
    public void PickupItem2(int itemid) //不在背包场景的时候添加道具
    {
        Item targetItem = Game.Instance.StaticData.GetItem(itemid);
        for (int i = 0; i < Backpack.Count; i++)
        {
            if (Backpack[i].Item.ID == itemid)//如果有相同物品
            {
                if (Backpack[i].Count < targetItem.Capacity) //堆叠数没满
                {
                    Backpack[i].Count++;
                    //SendEvent(Consts.E_AddItemCount, i);
                    return;
                }
                /* else
                 {                                       
                     Backpack.Add(new BackpackGrid(targetItem,1));//另占一个格子
                     return;
                 }*/
            }
        }

        Backpack.Add(new BackpackGrid(targetItem, 1));
        //SendEvent(Consts.E_AddItem, itemid);
    }
    void ParseNPCJson()
    {
        
        TextAsset NPCText = Resources.Load<TextAsset>("NPC");
        string NPCJson = NPCText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(NPCJson);

        foreach (JSONObject temp in j.list)
        {
            int id = (int)temp["id"].n;
            string name = temp["name"].str;
            int sex = (int)temp["sex"].n;
            int charm = (int)temp["charm"].n;
            int luck = (int)temp["luck"].n;
            int savvy = (int)temp["savvy"].n;

            int age = (int)temp["age"].n;
            int maxAge = (int)temp["maxAge"].n;
            int trength = (int)temp["trength"].n;
            int dingli = (int)temp["dingli"].n;
            int level = (int)temp["level"].n;

            int morality = (int)temp["morality"].n;
            int killValue = (int)temp["killValue"].n;
            //int exp = (int)temp["exp"].n;

            int attack = (int)temp["attack"].n;
            int deffence = (int)temp["deffence"].n;

            int hit = (int)temp["hit"].n;
            int miss = (int)temp["miss"].n;
            int reduceHurt = (int)temp["reduceHurt"].n;
            int increaseHurt = (int)temp["increaseHurt"].n;

            int speed = (int)temp["speed"].n;
            int hp = (int)temp["hp"].n;
            int maxHp = (int)temp["maxHp"].n;

            string talk = temp["talk"].str;
            string des = temp["des"].str;

            NPC npc = new NPC(id, name, sex, charm, luck,  age, maxAge, trength, dingli, level, morality, killValue, attack, deffence, hit, miss, reduceHurt, increaseHurt, speed,hp, maxHp, talk, des);

            NPCs.Add(id,npc);
        }
    }

    //游戏开始
   /* public void StartLevel(int levelIndex)
    {
        m_PlayLevelIndex = levelIndex;     
        
    }*/
    //游戏结束
   /* public void StopLevel(bool isWin)
    {
        if (isWin && PlayLevelID > GameProgress)
        {
            Saver.SetProgress(PlayLevelID);

            m_GameProgress = Saver.GetProgress();
        }
        m_isPlaying = false;
    }*/

    //清档
    public void ClearProgress()
    {
        m_isNewGame = true;
       // m_PlayLevelIndex = -1;
        m_GameProgress = -1;
       
    }

    #endregion

    #region Unity回调
    #endregion

    #region 事件回调
    #endregion

    #region 帮助方法
    #endregion

}
