using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISkill : View
{
    public GameObject GridGroup;
    public Text NameText;
    public Text PassiveText;
    public Text ActiveText;

    public override string Name
    {
        get
        {
            return Consts.V_Skill;
        }
    }


    void initialize()
    {
        GameModel gm = GetModel<GameModel>();
        foreach (int key  in gm.m_Skill.Keys)
        {
            Skill skill = Game.Instance.StaticData.getSkill(key);
            GameObject grid = (GameObject)Instantiate(Resources.Load("Prefab/SkillGrid"));
            grid.transform.parent = GridGroup.transform;

            Text nametxt = grid.transform.Find("Name").GetComponent<Text>();
            nametxt.text = string.Format("<color={0}>{1}</color>", skill.GetQualityColor(), skill.name);

            Text counttxt = grid.transform.Find("Level").GetComponent<Text>();
            counttxt.text = "等级："+ gm.m_Skill[key].ToString();
            
            Image Icon = grid.transform.Find("Icon").GetComponent<Image>();
            string path = "Icon/Skill/" + skill.sprite;
            Icon.sprite =Resources.Load<Sprite>(path);

            Image wx = grid.transform.Find("Icon/WxImage").GetComponent<Image>();
            string path2 = "Icon/Wx/" + skill.GetWxString();
            wx.sprite = Resources.Load<Sprite>(path2);

            grid.GetComponent<SelectSkill>().SkillID = key;
        }
    }

    void ShowSkillInfo(int id)
    {
        Skill skill = Game.Instance.StaticData.getSkill(id);
        NameText.text = string.Format("<color={0}>{1}</color>", skill.GetQualityColor(), skill.name);
        PassiveText.text = skill.passiveDes;
        ActiveText.text = skill.initiativeDes;
    }

    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_EnterScene);
        AttentionEvents.Add(Consts.E_ShowSkillInfo);
    }

    public override void HandleEvent(string eventName, object data)
    {
       switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e = data as SceneArgs;
                int scenceID = e.SceneIndex;
                if (scenceID == 2)
                    initialize();
                break;
            case Consts.E_ShowSkillInfo:
                int skillID = (int)data ;
                ShowSkillInfo(skillID);
                break;

        }     
    }


}
