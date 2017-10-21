using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFounctionBtn : View
{
    public GameObject UIHome;
    public GameObject UIBackPack;
    public GameObject UIMainMap;
    public GameObject NodeMap;
    public GameObject UIPlayer;
    public GameObject UISkill;

    GameModel gm;
    public override string Name
    {
        get
        {
            return Consts.V_UIFounctionBtn;
        }
    }

    void Start()
    {
        gm = GetModel<GameModel>();
    }

    public void TravelBtnClick()
    {
        if (!gm.IsInstance)
        {
            UISkill.SetActive(false);
            UIPlayer.SetActive(false);
            UIBackPack.SetActive(false);
            UIHome.SetActive(false);
            UIMainMap.SetActive(true);
            
}
        else
        {
            UISkill.SetActive(false);
            UIBackPack.SetActive(false);
            UIHome.SetActive(false);
            NodeMap.SetActive(true);
        }

    }

    public void HomeBtnClick()
    {
        if (!gm.IsInstance)
        {
            UISkill.SetActive(false);
            UIPlayer.SetActive(false);
            UIMainMap.SetActive(false);
            UIBackPack.SetActive(false);
            UIHome.SetActive(true);
        }
        else
        {
            UISkill.SetActive(false);
            UIPlayer.SetActive(false);
            NodeMap.SetActive(false);
            UIBackPack.SetActive(false);
            UIHome.SetActive(true);
        }
    }
    public void BackPackClick()
    {
        if (!gm.IsInstance)
        {
            UISkill.SetActive(false);
            UIPlayer.SetActive(false);
            UIMainMap.SetActive(false);
            UIHome.SetActive(false);
            UIBackPack.SetActive(true);
        }
        else
        {
            UISkill.SetActive(false);
            UIPlayer.SetActive(false);
            NodeMap.SetActive(false);
            UIHome.SetActive(false);
            UIBackPack.SetActive(true);
        }
    }

    public void SkillClick()
    {
           UIPlayer.SetActive(false);
            UIMainMap.SetActive(false);
            UIHome.SetActive(false);
            UIBackPack.SetActive(false);
            UISkill.SetActive(true);

    }

    public override void HandleEvent(string eventName, object data)
    {
     
    }
}
