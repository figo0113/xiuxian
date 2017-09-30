using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPlayer : View {
    public GameObject UIHome;
    public GameObject PropertyWuxing;

    public GameObject[] EquipmentIcon;


    public Text nameTxt;
    public Text aptitudeTxt;
    public Text schoolTxt;
    public Text zhanliTxt;
    public Text AgeTxt;
    public Text LevelText;

    public Text HPTxt;
    public Text CharmTxt;
    public Text DingliTxt;
    public Text LuckTxt;
    public Text SpeedTxt;
    public Text MoralityTxt;
    public Text KillValueTxt;
    public Text AttactTxt;
    public Text HitTxt;
    public Text IncreaseHurtTxt;
    public Text DeffenceTxt;
    public Text MissTxt;
    public Text ReduceHurtTxt;

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
        gm.player.EquipmentChange += Player_EquipmentChange;
        UpadaInfo(gm.player);
        Player_ExpChange(gm.player.Exp);
        Player_EquipmentChange(gm.player);
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
        HPTxt.text = player.Hp.ToString() + "/" + player.MaxHp.ToString();
        CharmTxt.text = player.Charm.ToString();
        DingliTxt.text = player.Dingli.ToString();
        LuckTxt.text = player.Luck.ToString();
        SpeedTxt.text = player.Speed.ToString();
        MoralityTxt.text = player.Morality.ToString();
        KillValueTxt.text = player.KillValue.ToString();
        AttactTxt.text = player.Attack.ToString();
        HitTxt.text = (player.Hit / 100).ToString() + "%";
        IncreaseHurtTxt.text = (player.IncreaseHurt / 100).ToString() + "%";
        DeffenceTxt.text = player.Deffence.ToString();
        MissTxt.text = (player.Miss / 100).ToString() + "%";
        ReduceHurtTxt.text = (player.ReduceHurt / 100).ToString() + "%";

    }
    private void Player_EquipmentChange(Player player)
    {
        for(int i=0;i<EquipmentIcon.Length;i++)
        {
            if (player.playerEquipment[i] != null)
            {
                EquipmentIcon[i].SetActive(true);
                Image Icon = EquipmentIcon[i].GetComponent<Image>();
                string path = "Icon/Item/" + player.playerEquipment[i].Sprite;
                Icon.sprite = Resources.Load<Sprite>(path);
            }
            else
                EquipmentIcon[i].SetActive(false);
        }
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
    public void PropertyJinClick()
    {
        PropertyWuxing.gameObject.SetActive(true);
        Text attackText = PropertyWuxing.transform.Find("attack").GetComponent<Text>();
        Text defenceText= PropertyWuxing.transform.Find("defence").GetComponent<Text>();

        attackText.text = "金属性攻击：" + gm.player.attack_jin.ToString();
        defenceText.text = "金属性防御：" + gm.player.defence_jin.ToString();
    }
    public void PropertyMuClick()
    {
        PropertyWuxing.gameObject.SetActive(true);
        Text attackText = PropertyWuxing.transform.Find("attack").GetComponent<Text>();
        Text defenceText = PropertyWuxing.transform.Find("defence").GetComponent<Text>();

        attackText.text = "木属性攻击：" + gm.player.attack_mu.ToString();
        defenceText.text = "木属性防御：" + gm.player.defence_mu.ToString();
    }
    public void PropertyShuiClick()
    {
        PropertyWuxing.gameObject.SetActive(true);
        Text attackText = PropertyWuxing.transform.Find("attack").GetComponent<Text>();
        Text defenceText = PropertyWuxing.transform.Find("defence").GetComponent<Text>();

        attackText.text = "水属性攻击：" + gm.player.attack_shui.ToString();
        defenceText.text = "水属性防御：" + gm.player.defence_shui.ToString();
    }
    public void PropertyHuoClick()
    {
        PropertyWuxing.gameObject.SetActive(true);
        Text attackText = PropertyWuxing.transform.Find("attack").GetComponent<Text>();
        Text defenceText = PropertyWuxing.transform.Find("defence").GetComponent<Text>();

        attackText.text = "火属性攻击：" + gm.player.attack_huo.ToString();
        defenceText.text = "火属性防御：" + gm.player.defence_huo.ToString();
    }
    public void PropertyTuClick()
    {
        PropertyWuxing.gameObject.SetActive(true);
        Text attackText = PropertyWuxing.transform.Find("attack").GetComponent<Text>();
        Text defenceText = PropertyWuxing.transform.Find("defence").GetComponent<Text>();

        attackText.text = "土属性攻击：" + gm.player.attack_tu.ToString();
        defenceText.text = "土属性防御：" + gm.player.defence_tu.ToString();
    }
}
