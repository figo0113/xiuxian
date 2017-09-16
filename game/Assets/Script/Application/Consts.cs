using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class Consts
{
    //目录
    public static readonly string LevelDir = Application.dataPath + @"\Game\Resources\Res\Levels";
    public static readonly string MapDir = Application.dataPath + @"\Game\Resources\Res\Maps";
    public static readonly string CardDir = Application.dataPath + @"\Game\Resources\Res\Cards";

    //存档
    public const string GameProgress = "GameProgress";

    //定义存档路径
    public static  string dirpath = Application.persistentDataPath + "/Save";

    
    //定义存档文件路径
    public static string saveFileName = dirpath + "/GameData.sav";




    public const float DotClosedDistance = 0.1f;
    public const float RangeClosedDistance = 0.3f;

    //Model
    public const string M_GameModel = "M_GameModel";
    public const string M_MapModel = "M_MapModel";
    public const string M_FightModel = "M_FightModel";

    //View
    public const string V_Start = "V_Start";
    public const string V_UIMain = "V_UIMain";
    public const string V_Home = "V_Home";
    public const string V_NPCPanelinfo = "V_NPCPanelinfo";
    public const string V_MonsterPanelInfo = "V_MonsterPanelInfo";
    public const string V_CollectionPanelInfo = "V_CollectionPanelInfo";
    public const string V_UIFounctionBtn = "V_UIFounctionBtn";
    public const string V_UIMainMap = "V_UIMainMap";
    public const string V_UIRegionMap = "V_UIRegionMap";
    public const string V_NPCButton = "V_NPCButton";
    public const string V_NodeMap = "V_NodeMap";
    public const string V_PanelManager = "V_PanelManager";
    public const string V_MonsterPanelManager = "V_MonsterPanelManager";
    public const string V_UIBackPack = "V_UIBackPack";
    public const string V_FightManger = "V_FightManger";
    public const string V_UIPlayer = "V_UIPlayer";
    public const string V_UIWin = "V_UIWin";
    public const string V_UILost = "V_UILost";
    //Controller
    public const string E_StartUp = "E_StartUp";
    public const string E_SaveData = "E_SaveData";
    public const string E_EnterScene = "E_EnterScene"; //SceneArgs
    public const string E_ExitScene = "E_ExitScene";//SceneArgs
    public const string E_CommunicateNPC= "E_CommunicateNPC";//SceneArgs
    public const string E_CommunicateMonster = "E_CommunicateMonster";//SceneArgs
    public const string E_PickItem = "E_PickItem";//SceneArgs
    public const string E_InitBackPack = "E_InitBackPack";//SceneArgs
    public const string E_AddItemCount = "E_AddItemCount";
    public const string E_AddItem = "E_AddItem";
    public const string E_StartFight = "E_StartFight";
    public const string E_ExitFight = "E_ExitFight";
    public const string E_EnterInstance = "E_EnterInstance";
    public const string E_BackInstance = "E_BackInstance";
    public const string E_Win = "E_Win";
    public const string E_Lost = "E_Lost";
    /*    public const string E_StartLevel = "E_StartLevel"; //StartLevelArgs
         public const string E_EndLevel = "E_EndLevel";//EndLevelArgs

         public const string E_CountDownComplete = "E_CountDownComplete";

         public const string E_StartRound = "E_StartRound";//StartRoundArgs
         public const string E_SpawnMonster = "E_SpawnMonster";//SpawnMonsterArgs
         public const string E_SpawnTower = "E_SpawnTower";//SpawnTowerArgs
         public const string E_UpgradeTower = "E_UpgradeTower";//UpgradeTowerArgs
         public const string E_SellTower = "E_SellTower";//SellTowerArgs

         public const string E_ShowCreate = "E_ShowCreate";//ShowCreatorArgs
         public const string E_ShowUpgrade = "E_ShowUpgrade";//ShowUpgradeArgs
         public const string E_HidePopup = "E_HidePopup";*/





}

public enum GameSpeed
{
    One,
    Two
}

public enum MonsterType
{
    Monster0,
    Monster1,
    Monster2,
    Monster3,
    Monster4,
    Monster5
}