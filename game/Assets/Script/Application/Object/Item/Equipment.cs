using UnityEngine;
using System.Collections;

public class Equipment : Item {

    //装备可附加属性：气血、魅力、定力、福缘、速度、攻击、防御、命中、闪避、破击、免伤、金攻击、金防御、木攻击、木防御、水攻击、水防御、火攻击、火防御
    
    /// <summary>
    /// 气血
    /// </summary>
    public int MaxHp { get; set; }
    /// <summary>
    /// 魅力
    /// </summary>
    public int Charm { get; set; }
    /// <summary>
    /// 定力
    /// </summary>
    public int Dingli { get; set; }
    /// <summary>
    /// 福缘
    /// </summary>
    public int Luck { get; set; }
    //速度
    public int Speed { get; set; }
    //攻击
    public int Attack { get; set; }
    //防御
    public int Deffence { get; set; }
    //命中
    public int Hit { get; set; }
    //闪避
    public int Miss { get; set; }
    //破击
    public int IncreaseHurt { get; set; }
    //免伤
    public int ReduceHurt { get; set; }
    //金攻
    public int Attack_jin { get; set; }
    //金防
    public int Defence_jin { get; set; }
    //木攻
    public int Attack_mu { get; set; }
    //木防
    public int Defence_mu { get; set; }
    //水攻
    public int Attack_shui { get; set; }
    //水防
    public int Defence_shui { get; set; }
    //火攻
    public int Attack_huo { get; set; }
    //火防
    public int Defence_huo { get; set; }
    //土攻
    public int Attack_tu { get; set; }
    //土防
    public int Defence_tu { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType { get; set; }

    public Equipment(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice,string sprite,
        int maxHp,int charm,int dingli, int luck,int speed,int attack,int deffence,int hit,int miss,int increaseHurt,int reduceHurt,int attack_jin,
        int defence_jin, int attack_mu, int defence_mu, int attack_shui, int defence_shui, int attack_huo, int defence_huo, int attack_tu, int defence_tu, EquipmentType equipType)
        : base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
        this.MaxHp = maxHp;
        this.Charm = charm;
        this.Dingli = dingli;
        this.Luck = luck;
        this.Speed = speed;
        this.Attack = attack;
        this.Deffence = deffence;
        this.Hit = hit;
        this.Miss = miss;
        this.IncreaseHurt = increaseHurt;
        this.ReduceHurt = reduceHurt;
        this.Attack_jin = attack_jin;
        this.Defence_jin = defence_jin;
        this.Attack_mu = attack_mu;
        this.Defence_mu = defence_mu;
        this.Attack_shui = attack_shui;
        this.Defence_shui = defence_shui;
        this.Attack_huo = attack_huo;
        this.Defence_huo = defence_huo;
        this.Attack_tu = attack_tu;
        this.Defence_tu = defence_tu;
        this.EquipType = equipType;
    }
    public Equipment(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite,
    int[] equipProperty, EquipmentType equipType)
    : base(id, name, type, quality, des, capacity, buyPrice, sellPrice, sprite)
    {
        this.MaxHp = equipProperty[0];
        this.Charm = equipProperty[1];
        this.Dingli = equipProperty[2];
        this.Luck = equipProperty[3];
        this.Speed = equipProperty[4];
        this.Attack = equipProperty[5];
        this.Deffence = equipProperty[6];
        this.Hit = equipProperty[7];
        this.Miss = equipProperty[8];
        this.IncreaseHurt = equipProperty[9];
        this.ReduceHurt = equipProperty[10];
        this.Attack_jin = equipProperty[11];
        this.Defence_jin = equipProperty[12];
        this.Attack_mu = equipProperty[13];
        this.Defence_mu = equipProperty[14];
        this.Attack_shui = equipProperty[15];
        this.Defence_shui = equipProperty[16];
        this.Attack_huo = equipProperty[17];
        this.Defence_huo = equipProperty[18];
        this.Attack_tu = equipProperty[19];
        this.Defence_tu = equipProperty[20];
        this.EquipType = equipType;
    }

    public enum EquipmentType
    {
        None,
        Weapon,
        Headpiece,
        Armor,
        Boots,
        Jewelry,
    }

    public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string equipTypeText = "";
        switch (EquipType)
	{
		case EquipmentType.Weapon:
                equipTypeText="武器";
         break;
        case EquipmentType.Headpiece:
                equipTypeText="帽子";
         break;
        case EquipmentType.Armor:
                equipTypeText="衣服";
         break;
        case EquipmentType.Boots:
                equipTypeText="靴子";
         break;
        case EquipmentType.Jewelry:
                equipTypeText="饰品";
         break;
	}

        string newText = string.Format("{0}\n\n<color=blue>装备类型：{1}\n力量：{2}\n智力：{3}\n敏捷：{4}\n体力：{5}</color>", text,equipTypeText,MaxHp,Charm,Luck,Dingli);

        return newText;
    }
    public override string GetPropertyText()
    {
        string propertyText = "";
        int p_num = 0;
        if(this.MaxHp!=0)
        {
            if (p_num == 0)
                propertyText += "气血+" + MaxHp;
            else
                propertyText += "\t气血+" + MaxHp;
            p_num++;
        }
        if (this.Charm != 0)
        {
            if (p_num == 0)
                propertyText += "魅力+" + Charm;
            else
                propertyText += "\t魅力+" + Charm;
            p_num++;
        }
        if (this.Dingli != 0)
        {
            if (p_num == 0)
                propertyText += "定力+" + Dingli;
            else
                propertyText += "\t定力+" + Dingli;
            p_num++;
        }
        if (this.Luck != 0)
        {
            if (p_num == 0)
                propertyText += "福缘+" + Luck;
            else
                propertyText += "\t福缘+" + Luck;
            p_num++;
        }
        if (this.Speed != 0)
        {
            if (p_num == 0)
                propertyText += "速度+" + Speed;
            else
                propertyText += "\t速度+" + Speed;
            p_num++;
        }
        if (this.Attack != 0)
        {
            if (p_num == 0)
                propertyText += "攻击+" + Attack;
            else
                propertyText += "\t攻击+" + Attack;
            p_num++;
        }
        if (this.Deffence != 0)
        {
            if (p_num == 0)
                propertyText += "防御+" + Deffence;
            else
                propertyText += "\t防御+" + Deffence;
            p_num++;
        }
        if (this.Hit != 0)
        {
            if (p_num == 0)
                propertyText += "命中+" + Hit;
            else
                propertyText += "\t命中+" + Hit;
            p_num++;
        }
        if (this.Miss != 0)
        {
            if (p_num == 0)
                propertyText += "闪避+" + Miss;
            else
                propertyText += "\t闪避+" + Miss;
            p_num++;
        }
        if (this.IncreaseHurt != 0)
        {
            if (p_num == 0)
                propertyText += "破击+" + IncreaseHurt;
            else
                propertyText += "\t破击+" + IncreaseHurt;
            p_num++;
        }
        if (this.ReduceHurt != 0)
        {
            if (p_num == 0)
                propertyText += "免伤+" + ReduceHurt;
            else
                propertyText += "\t免伤+" + ReduceHurt;
            p_num++;
        }
        if (this.Attack_jin != 0)
        {
            if (p_num == 0)
                propertyText += "金攻+" + Attack_jin;
            else
                propertyText += "\t金攻+" + Attack_jin;
            p_num++;
        }
        if (this.Defence_jin != 0)
        {
            if (p_num == 0)
                propertyText += "金防+" + Defence_jin;
            else
                propertyText += "\t金防+" + Defence_jin;
            p_num++;
        }
        if (this.Attack_mu != 0)
        {
            if (p_num == 0)
                propertyText += "木攻+" + Attack_mu;
            else
                propertyText += "\t木攻+" + Attack_mu;
            p_num++;
        }
        if (this.Defence_mu != 0)
        {
            if (p_num == 0)
                propertyText += "木防+" + Defence_mu;
            else
                propertyText += "\t木防+" + Defence_mu;
            p_num++;
        }
        if (this.Attack_shui != 0)
        {
            if (p_num == 0)
                propertyText += "水攻+" + Attack_shui;
            else
                propertyText += "\t水攻+" + Attack_shui;
            p_num++;
        }
        if (this.Defence_shui != 0)
        {
            if (p_num == 0)
                propertyText += "水防+" + Defence_shui;
            else
                propertyText += "\t水防+" + Defence_shui;
            p_num++;
        }
        if (this.Attack_huo != 0)
        {
            if (p_num == 0)
                propertyText += "火攻+" + Attack_huo;
            else
                propertyText += "\t火攻+" + Attack_huo;
            p_num++;
        }
        if (this.Defence_huo != 0)
        {
            if (p_num == 0)
                propertyText += "火防+" + Defence_huo;
            else
                propertyText += "\t火防+" + Defence_huo;
            p_num++;
        }
        if (this.Attack_tu != 0)
        {
            if (p_num == 0)
                propertyText += "土攻+" + Attack_tu;
            else
                propertyText += "\t土攻+" + Attack_tu;
            p_num++;
        }
        if (this.Defence_tu != 0)
        {
            if (p_num == 0)
                propertyText += "土防+" + Defence_tu;
            else
                propertyText += "\t土防+" + Defence_tu;
            p_num++;
        }

        return propertyText;
    }
    public override string GetItemTypeText()
    {
        string equipType = "";
        switch (EquipType)
        {
            case EquipmentType.Weapon:
                equipType = "『武器』";
                break;
            case EquipmentType.Headpiece:
                equipType = "〖帽子〗";
                break;
            case EquipmentType.Armor:
                equipType = "〖衣服〗";
                break;
            case EquipmentType.Boots:
                equipType = "『靴子』";
                break;
            case EquipmentType.Jewelry:
                equipType = "『饰品』";
                break;
        }
        return equipType;
    }
}
