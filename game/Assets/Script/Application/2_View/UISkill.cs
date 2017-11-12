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
    public GameObject FightSkill;
    public GameObject SkillIconPanel;
    public Transform[] SkillPos;

    private float leftLimit;
    private float rightLimit;
    private float upLimit;
    private float downLimit;
    public override string Name
    {
        get
        {
            return Consts.V_Skill;
        }
    }

    private void Start()
    {
        leftLimit = SkillPos[0].transform.position.x - 50;
        rightLimit = SkillPos[4].transform.position.x + 50;
        upLimit = SkillPos[0].transform.position.y + 50;
        downLimit= SkillPos[0].transform.position.y - 50;
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
            grid.transform.Find("Icon").GetComponent<DragSkill>().SkillID = key;
        }
        ShowFightSkill();
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
        AttentionEvents.Add(Consts.E_AddFightSkill);
        AttentionEvents.Add(Consts.E_MoveFightSkill);
    }

    void ShowFightSkill()
    {
        GameModel gm = GetModel<GameModel>();

        for (int i = 0; i < SkillIconPanel.transform.childCount; i++)
        {
            Destroy(SkillIconPanel.transform.GetChild(i).gameObject);
        }

        for (int i=0; i<gm.FightSkill.Count;i++)
        {
            GameObject skill = (GameObject)Instantiate(Resources.Load ("Prefab/SkillIcon"));
            Image Icon = skill.GetComponent<Image>();
            string path = "Icon/Skill/Skill_" + gm.FightSkill[i];
            Icon.sprite = Resources.Load<Sprite>(path);
            skill.transform.parent = SkillIconPanel.transform;
            skill.transform.position = SkillPos[i].position;
            skill.GetComponent<DragFightSkill>().SkillID = gm.FightSkill[i];
        }
    }

    void AddFightSkill(AddFightSkill e)
    {
        if (e.pos.x >= leftLimit && e.pos.x <= rightLimit && e.pos.y<= upLimit && e.pos.y>=downLimit)
        {
            GameModel gm = GetModel<GameModel>();
            if (!gm.FightSkill.Contains(e.id) && gm.FightSkill.Count<=5 && gm.m_Skill.ContainsKey(e.id))
            {
                GameObject skill = (GameObject)Instantiate(Resources.Load("Prefab/SkillIcon"));
                Image Icon = skill.GetComponent<Image>();
                string path = "Icon/Skill/Skill_" + e.id;
                Icon.sprite = Resources.Load<Sprite>(path);
                skill.transform.parent = SkillIconPanel.transform;
                skill.transform.position = SkillPos[gm.FightSkill.Count].position;
                skill.GetComponent<DragFightSkill>().SkillID = e.id;
                gm.FightSkill.Add(e.id);
            }
        }
    }

    void MoveFightSkill(AddFightSkill e)
    {
        GameModel gm = GetModel<GameModel>();
        if (e.pos.x >= leftLimit && e.pos.x <= rightLimit && e.pos.y <= upLimit && e.pos.y >= downLimit) //移动的位置在技能框内
        {
            float MinDistance = 100;
            int targetIndex = 0;
            
            for (int i = 0; i < 5; i++) //找到最近的技能框
            {
                if (Vector2.Distance(e.pos, SkillPos[i].position) <= MinDistance)
                {
                    MinDistance = Vector2.Distance(e.pos, SkillPos[i].position);
                    targetIndex = i;
                }
            }
            if (gm.FightSkill.Count < targetIndex+1)
            {
                targetIndex = gm.FightSkill.Count - 1;
            }
            gm.FightSkill.Remove(e.id); 
            gm.FightSkill.Insert(targetIndex, e.id);
            ShowFightSkill();
        }
        else
        {
            gm.FightSkill.Remove(e.id);
            ShowFightSkill();
        }
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
            case Consts.E_AddFightSkill:
                AddFightSkill addskill = data as AddFightSkill;
                AddFightSkill(addskill);
                break;
            case Consts.E_MoveFightSkill:
                AddFightSkill moveskill = data as AddFightSkill;
                MoveFightSkill(moveskill);
                break;

        }     
    }


}
