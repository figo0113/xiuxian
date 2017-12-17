using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIHome : View {

    public GameObject UIPlayer;

    public Text LogText;
    public Text NameText;
    public Text LevelText;
    public Text ExpText;
    public Slider ExpSlider;
    GameModel gm;
    public override string Name
    {
        get
        {
            return Consts.V_Home;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    void Start()
    {
        gm = GetModel<GameModel>();
        int maxExp = gm.player.maxExp;
        int Exp = gm.player.Exp;
        LevelText.text = Game.Instance.StaticData.getLevelDes(gm.player.Level);
        ExpText.text = "修为："+ Exp.ToString() + "/" + maxExp.ToString();
        float v = (float)Exp / maxExp;
        ExpSlider.value = v;
        NameText.text = gm.player.name;
        gm.player.Upgrade += showLevel;
        gm.player.ExpChange += Player_ExpChange;

    }

    private void Player_ExpChange(int exp)
    {
        int maxExp = gm.player.maxExp;

        ExpText.text = "修为：" + exp.ToString() +"/" + maxExp.ToString();
        float v = (float)exp / maxExp;
        ExpSlider.value = v;
    }

    private void showLevel( int level)
    {
        LevelText.text = Game.Instance.StaticData.getLevelDes(level);
    }


    public void NPCListTest()
    {
        //GameModel gm = GetModel<GameModel>();
      
        string isDeadStr0 = gm.NPCs[1].isdead ? "死的" : "活的";
        string isDeadStr1 = gm.NPCs[2].isdead ? "死的" : "活的";
        LogText.text = gm.NPCs[1].name + " 他是" + isDeadStr0 + "\n" + gm.NPCs[2].name + " 他是"+ isDeadStr1;
    }


    public void QuickClick() //加速测试 获得道具1
    {
        //GameModel gm = GetModel<GameModel>();
        gm.PickupItem(1);
        gm.PickupItem(2);
        gm.PickupItem(3);
        gm.PickupItem(4);
        gm.PickupItem(5);
        gm.PickupItem(6);
        gm.PickupItem(7);
        gm.PickupItem(8);
        IOHelper.SetData(Consts.saveFileName, gm);
    }
    public void DazuoiClick() //打坐测试 获得道具2
    {
        //GameModel gm = GetModel<GameModel>();
        //gm.PickupItem(2);
        //IOHelper.SetData(Consts.saveFileName, gm);
        //gm.m_Skill[FightSkill(1)];
        Monster monster1 = Game.Instance.StaticData.getMonster(1);
        string formula = Game.Instance.StaticData.getSkill(gm.FightSkill[1]).formula;
        double hurt = Formula.hurt(gm.player, monster1, formula, 1);
        
    }

    public void PlayerClick()
    {
        this.gameObject.SetActive(false);
        UIPlayer.SetActive(true);
    }
}
