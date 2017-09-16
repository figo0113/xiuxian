﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : View {
    public GameObject UIHome;

    public Text nameTxt;
    public Text aptitudeTxt;
    public Text schoolTxt;
    public Text zhanliTxt;
    public Text AgeTxt;
    public Text LevelText;


    public Text ExpText;
    public Slider ExpSlider;
    GameModel gm;
    public override string Name
    {
        get
        {
            return Consts.V_UIPlayer;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        
    }

    void Start () {
        gm = GetModel<GameModel>();
        gm.player.PropertyChange += Player_PropertyChange;
        gm.player.Upgrade += showLevel;
        gm.player.ExpChange += Player_ExpChange;
        UpadaInfo(gm.player);
    }

    private void Player_PropertyChange(Player player)
    {
        UpadaInfo(player);
    }

    private void UpadaInfo(Player player)
    {
        nameTxt.text = player.name;
        //aptitudeTxt;
        //schoolTxt;
        //zhanliTxt;
        AgeTxt.text = player.Age.ToString() + "/" + player.MaxAge.ToString();

    }

    public void BackClick()
    {
        this.gameObject.SetActive(false);
        UIHome.SetActive(true);
    }
    private void Player_ExpChange(int exp)
    {
        int maxExp = gm.player.maxExp;

        ExpText.text = exp.ToString() + "/" + maxExp.ToString();
        float v = (float)exp / maxExp;
        ExpSlider.value = v;
    }

    private void showLevel(int level)
    {
        LevelText.text = Game.Instance.StaticData.getLevelDes(level);
    }
}
