using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//主角类
public class Player:Role  {
    public event Action<int> Upgrade;
    public event Action<int> ExpChange;

    public event Action<Player> PropertyChange;
    public event Action<Player> EquipmentChange;

    private const int maxlevel = 36; //测试等级 36级

    private int exp = 0;//经验
    public int maxExp;


    private int aptitude_jin = 0;
    private int aptitude_mu = 0;
    private int aptitude_shui = 0;
    private int aptitude_huo = 0;
    private int aptitude_tu = 0;
    //装备列表
    public Equipment[] playerEquipment = new Equipment[5];
    //装备属性
    public Dictionary<string, int> EquipmentProperty = new Dictionary<string, int>();
    //生活技能

    public Player(string name, int sex, int charm, int luck, int age, int maxAge, int trength, int dingli, int level, int morality, int killValue, int attack, int deffence, int hit, int miss, 
        int reduceHurt, int increaseHurt, int speed,int hp, int maxHp, int attack_jin = 0, int defence_jin = 0,int attack_mu = 0, int defence_mu = 0, int attack_shui = 0, int defence_shui = 0, 
        int attack_huo = 0, int defence_huo = 0, int attack_tu = 0, int defence_tu = 0) : base(name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, attack, deffence,  hit,  
            miss,  reduceHurt,  increaseHurt, speed,hp, maxHp,attack_jin,defence_jin,attack_mu,defence_mu,attack_shui,defence_shui,attack_huo,defence_huo,attack_tu,defence_tu)
    {
        this.maxExp = Game.Instance.StaticData.getMaxExp(level);
        EquipmentProperty.Add("MaxHp", 0);
        EquipmentProperty.Add("Charm", 0);
        EquipmentProperty.Add("Dingli", 0);
        EquipmentProperty.Add("Luck", 0);
        EquipmentProperty.Add("Speed", 0);
        EquipmentProperty.Add("Attack", 0);
        EquipmentProperty.Add("Deffence", 0);
        EquipmentProperty.Add("Hit", 0);
        EquipmentProperty.Add("Miss", 0);
        EquipmentProperty.Add("IncreaseHurt", 0);
        EquipmentProperty.Add("ReduceHurt", 0);
        EquipmentProperty.Add("Attack_jin", 0);
        EquipmentProperty.Add("Defence_jin", 0);
        EquipmentProperty.Add("Attack_mu", 0);
        EquipmentProperty.Add("Defence_mu", 0);
        EquipmentProperty.Add("Attack_shui", 0);
        EquipmentProperty.Add("Defence_shui", 0);
        EquipmentProperty.Add("Attack_huo", 0);
        EquipmentProperty.Add("Defence_huo", 0);
        EquipmentProperty.Add("Attack_tu", 0);
        EquipmentProperty.Add("Defence_tu", 0);
    }



    public int Exp
    {
        get
        {
            return exp;
        }

        set
        {
            if (this.Level + 1 < maxlevel) //没满级
            {

                if (value > maxExp)
                {
                    exp = value - maxExp;
                    upgrade();//升级
                }

                else
                {
                    exp = value;
                }

                if (ExpChange != null)
                    ExpChange(exp);
            }
            else
            {
                exp = 0;
            }
        }
    }

    public int Aptitude_jin
    {
        get
        {
            return aptitude_jin;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            aptitude_jin = value;
        }
    }

    public int Aptitude_mu
    {
        get
        {
            return aptitude_mu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            aptitude_mu = value;
        }
    }

    public int Aptitude_shui
    {
        get
        {

            return aptitude_shui;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            aptitude_shui = value;
        }
    }

    public int Aptitude_huo
    {
        get
        {
            return aptitude_huo;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            aptitude_huo = value;
        }
    }

    public int Aptitude_tu
    {
        get
        {

            return aptitude_tu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            aptitude_tu = value;
        }
    }

    public int Charm
    {
        get
        {
            return charm;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            charm = value;
        }
    }

    public int Luck
    {
        get
        {
            return luck;
        }

        set
        {
            luck = value;
        }
    }

    public int Age
    {
        get
        {
            return age;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            age = value;
        }
    }

    public int MaxAge
    {
        get
        {
            return maxAge;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            maxAge = value;
        }
    }

    public int Trength
    {
        get
        {
            return trength;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            trength = value;
        }
    }

    public int Dingli
    {
        get
        {
            return dingli;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            dingli = value;
        }
    }

    public int Level
    {
        get
        {
            return level;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            level = value;
        }
    }

    public int Morality
    {
        get
        {
            return morality;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            morality = value;
        }
    }

    public int KillValue
    {
        get
        {
            return killValue;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            killValue = value;
        }
    }

    public int Attack
    {
        get
        {
            return attack;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack = value;
        }
    }

    public int Deffence
    {
        get
        {
            return deffence;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            deffence = value;
        }
    }

    public int Hit
    {
        get
        {
            return hit;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            hit = value;
        }
    }

    public int Miss
    {
        get
        {
            return miss;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            miss = value;
        }
    }

    public int ReduceHurt
    {
        get
        {
            return reduceHurt;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            reduceHurt = value;
        }
    }

    public int IncreaseHurt
    {
        get
        {
            return increaseHurt;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            increaseHurt = value;
        }
    }

    public int Speed
    {
        get
        {
            return speed;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            speed = value;
        }
    }


    public int MaxHp
    {
        get
        {
            return maxHp;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            maxHp = value;
        }
    }

    public int Attack_jin
    {
        get
        {
            return attack_jin;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack_jin = value;
        }
    }

    public int Defence_jin
    {
        get
        {
            return defence_jin;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            defence_jin = value;
        }
    }

    public int Attack_mu
    {
        get
        {
            return attack_mu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack_mu = value;
        }
    }

    public int Defence_mu
    {
        get
        {
            return defence_mu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            defence_mu = value;
        }
    }

    public int Attack_shui
    {
        get
        {
            return attack_shui;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack_shui = value;
        }
    }

    public int Defence_shui
    {
        get
        {
            return defence_shui;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            defence_shui = value;
        }
    }

    public int Attack_huo
    {
        get
        {
            return attack_huo;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack_huo = value;
        }
    }

    public int Defence_huo
    {
        get
        {
            return defence_huo;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            defence_huo = value;
        }
    }

    public int Attack_tu
    {
        get
        {
            return attack_tu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            attack_tu = value;
        }
    }

    public int Defence_tu
    {
        get
        {
            return defence_tu;
        }

        set
        {
            if (PropertyChange != null)
                PropertyChange(this);
            defence_tu = value;
        }
    }

    private void upgrade()
    {
            this.Level++;
            this.maxExp = Game.Instance.StaticData.getMaxExp(Level);

            if (Upgrade != null)
                Upgrade(Level);
    }

    public Equipment Equip(Equipment equip)
    {
        Equipment oldEquipment = null;//用于存放旧装备
        switch (equip.EquipType)
        {
            case Equipment.EquipmentType.Weapon:
                if (playerEquipment[0] !=null)
                    oldEquipment = playerEquipment[0];
                playerEquipment[0] = equip;
                break;
            case Equipment.EquipmentType.Headpiece:
                if (playerEquipment[1] != null)
                    oldEquipment = playerEquipment[1];
                playerEquipment[1] = equip;
                break;
            case Equipment.EquipmentType.Armor:
                if (playerEquipment[2] != null)
                    oldEquipment = playerEquipment[2];
                playerEquipment[2] = equip;
                break;
            case Equipment.EquipmentType.Boots:
                if (playerEquipment[3] != null)
                    oldEquipment = playerEquipment[3];
                playerEquipment[3] = equip;
                break;
            case Equipment.EquipmentType.Jewelry:
                if (playerEquipment[4] != null)
                    oldEquipment = playerEquipment[4];
                playerEquipment[4] = equip;
                break;
        }
        if(EquipmentChange!=null)
            EquipmentChange(this);
        UpdateEquipProperty(equip, oldEquipment);
        AddEquipProperty();
        return oldEquipment;
    }

    private void UpdateEquipProperty(Equipment equip,Equipment oldEquip=null)
    {
        //如果有旧装备，减去旧装备属性
        if (oldEquip!=null)
        {
            if (oldEquip.MaxHp != 0)
            {
                EquipmentProperty["MaxHp"] -= oldEquip.MaxHp;
            }
            if (oldEquip.Charm != 0)
            {
                EquipmentProperty["Charm"] -= oldEquip.Charm;
            }
            if (oldEquip.Dingli != 0)
            {
                EquipmentProperty["Dingli"] -= oldEquip.Dingli;
            }
            if (oldEquip.Luck != 0)
            {
                EquipmentProperty["Luck"] -= oldEquip.Luck;
            }
            if (oldEquip.Speed != 0)
            {
                EquipmentProperty["Speed"] -= oldEquip.Speed;
            }
            if (oldEquip.Attack != 0)
            {
                EquipmentProperty["Attack"] -= oldEquip.Attack;
            }
            if (oldEquip.Deffence != 0)
            {
                EquipmentProperty["Deffence"] -= oldEquip.Deffence;
            }
            if (oldEquip.Hit != 0)
            {
                EquipmentProperty["Hit"] -= oldEquip.Hit;
            }
            if (oldEquip.Miss != 0)
            {
                EquipmentProperty["Miss"] -= oldEquip.Miss;
            }
            if (oldEquip.IncreaseHurt != 0)
            {
                EquipmentProperty["IncreaseHurt"] -= oldEquip.IncreaseHurt;
            }
            if (oldEquip.ReduceHurt != 0)
            {
                EquipmentProperty["ReduceHurt"] -= oldEquip.ReduceHurt;
            }
            if (oldEquip.Attack_jin != 0)
            {
                EquipmentProperty["Attack_jin"] -= oldEquip.Attack_jin;
            }
            if (oldEquip.Defence_jin != 0)
            {
                EquipmentProperty["Defence_jin"] -= oldEquip.Defence_jin;
            }
            if (oldEquip.Attack_mu != 0)
            {
                EquipmentProperty["Attack_mu"] -= oldEquip.Attack_mu;
            }
            if (oldEquip.Defence_mu != 0)
            {
                EquipmentProperty["Defence_mu"] -= oldEquip.Defence_mu;
            }
            if (oldEquip.Attack_shui != 0)
            {
                EquipmentProperty["Attack_shui"] -= oldEquip.Attack_shui;
            }
            if (oldEquip.Defence_shui != 0)
            {
                EquipmentProperty["Defence_shui"] -= oldEquip.Defence_shui;
            }
            if (oldEquip.Attack_huo != 0)
            {
                EquipmentProperty["Attack_huo"] -= oldEquip.Attack_huo;
            }
            if (oldEquip.Defence_huo != 0)
            {
                EquipmentProperty["Defence_huo"] -= oldEquip.Defence_huo;
            }
            if (oldEquip.Attack_tu != 0)
            {
                EquipmentProperty["Attack_tu"] -= oldEquip.Attack_tu;
            }
            if (oldEquip.Defence_tu != 0)
            {
                EquipmentProperty["Defence_tu"] -= oldEquip.Defence_tu;
            }
        }

        //加新装备属性
        if (equip.MaxHp != 0)
        {
            EquipmentProperty["MaxHp"] += equip.MaxHp;
        }
        if (equip.Charm != 0)
        {
            EquipmentProperty["Charm"] += equip.Charm;
        }
        if (equip.Dingli != 0)
        {
            EquipmentProperty["Dingli"] += equip.Dingli;
        }
        if (equip.Luck != 0)
        {
            EquipmentProperty["Luck"] += equip.Luck;
        }
        if (equip.Speed != 0)
        {
            EquipmentProperty["Speed"] += equip.Speed;
        }
        if (equip.Attack != 0)
        {
            EquipmentProperty["Attack"] += equip.Attack;
        }
        if (equip.Deffence != 0)
        {
            EquipmentProperty["Deffence"] += equip.Deffence;
        }
        if (equip.Hit != 0)
        {
            EquipmentProperty["Hit"] += equip.Hit;
        }
        if (equip.Miss != 0)
        {
            EquipmentProperty["Miss"] += equip.Miss;
        }
        if (equip.IncreaseHurt != 0)
        {
            EquipmentProperty["IncreaseHurt"] += equip.IncreaseHurt;
        }
        if (equip.ReduceHurt != 0)
        {
            EquipmentProperty["ReduceHurt"] += equip.ReduceHurt;
        }
        if (equip.Attack_jin != 0)
        {
            EquipmentProperty["Attack_jin"] += equip.Attack_jin;
        }
        if (equip.Defence_jin != 0)
        {
            EquipmentProperty["Defence_jin"] += equip.Defence_jin;
        }
        if (equip.Attack_mu != 0)
        {
            EquipmentProperty["Attack_mu"] += equip.Attack_mu;
        }
        if (equip.Defence_mu != 0)
        {
            EquipmentProperty["Defence_mu"] += equip.Defence_mu;
        }
        if (equip.Attack_shui != 0)
        {
            EquipmentProperty["Attack_shui"] += equip.Attack_shui;
        }
        if (equip.Defence_shui != 0)
        {
            EquipmentProperty["Defence_shui"] += equip.Defence_shui;
        }
        if (equip.Attack_huo != 0)
        {
            EquipmentProperty["Attack_huo"] += equip.Attack_huo;
        }
        if (equip.Defence_huo != 0)
        {
            EquipmentProperty["Defence_huo"] += equip.Defence_huo;
        }
        if (equip.Attack_tu != 0)
        {
            EquipmentProperty["Attack_tu"] += equip.Attack_tu;
        }
        if (equip.Defence_tu != 0)
        {
            EquipmentProperty["Defence_tu"] += equip.Defence_tu;
        }
    }

    private void RemoveEquipProperty(Equipment equip)
    {
        if (equip.MaxHp != 0)
        {
            EquipmentProperty["MaxHp"] -= equip.MaxHp;
        }
        if (equip.Charm != 0)
        {
            EquipmentProperty["Charm"] -= equip.Charm;
        }
        if (equip.Dingli != 0)
        {
            EquipmentProperty["Dingli"] -= equip.Dingli;
        }
        if (equip.Luck != 0)
        {
            EquipmentProperty["Luck"] -= equip.Luck;
        }
        if (equip.Speed != 0)
        {
            EquipmentProperty["Speed"] -= equip.Speed;
        }
        if (equip.Attack != 0)
        {
            EquipmentProperty["Attack"] -= equip.Attack;
        }
        if (equip.Deffence != 0)
        {
            EquipmentProperty["Deffence"] -= equip.Deffence;
        }
        if (equip.Hit != 0)
        {
            EquipmentProperty["Hit"] -= equip.Hit;
        }
        if (equip.Miss != 0)
        {
            EquipmentProperty["Miss"] -= equip.Miss;
        }
        if (equip.IncreaseHurt != 0)
        {
            EquipmentProperty["IncreaseHurt"] -= equip.IncreaseHurt;
        }
        if (equip.ReduceHurt != 0)
        {
            EquipmentProperty["ReduceHurt"] -= equip.ReduceHurt;
        }
        if (equip.Attack_jin != 0)
        {
            EquipmentProperty["Attack_jin"] -= equip.Attack_jin;
        }
        if (equip.Defence_jin != 0)
        {
            EquipmentProperty["Defence_jin"] -= equip.Defence_jin;
        }
        if (equip.Attack_mu != 0)
        {
            EquipmentProperty["Attack_mu"] -= equip.Attack_mu;
        }
        if (equip.Defence_mu != 0)
        {
            EquipmentProperty["Defence_mu"] -= equip.Defence_mu;
        }
        if (equip.Attack_shui != 0)
        {
            EquipmentProperty["Attack_shui"] -= equip.Attack_shui;
        }
        if (equip.Defence_shui != 0)
        {
            EquipmentProperty["Defence_shui"] -= equip.Defence_shui;
        }
        if (equip.Attack_huo != 0)
        {
            EquipmentProperty["Attack_huo"] -= equip.Attack_huo;
        }
        if (equip.Defence_huo != 0)
        {
            EquipmentProperty["Defence_huo"] -= equip.Defence_huo;
        }
        if (equip.Attack_tu != 0)
        {
            EquipmentProperty["Attack_tu"] -= equip.Attack_tu;
        }
        if (equip.Defence_tu != 0)
        {
            EquipmentProperty["Defence_tu"] -= equip.Defence_tu;
        }

    }
    private void AddEquipProperty()
    {
        MaxHp += EquipmentProperty["MaxHp"];
        Charm += EquipmentProperty["Charm"];
        Dingli += EquipmentProperty["Dingli"];
        Luck += EquipmentProperty["Luck"];
        Speed += EquipmentProperty["Speed"];
        Attack += EquipmentProperty["Attack"];
        Deffence += EquipmentProperty["Deffence"];
        Hit += EquipmentProperty["Hit"];
        Miss += EquipmentProperty["Miss"];
        IncreaseHurt += EquipmentProperty["IncreaseHurt"];
        ReduceHurt += EquipmentProperty["ReduceHurt"];
        Attack_jin += EquipmentProperty["Attack_jin"];
        Defence_jin += EquipmentProperty["Defence_jin"];
        Attack_mu += EquipmentProperty["Attack_mu"];
        Defence_mu += EquipmentProperty["Defence_mu"];
        Attack_shui += EquipmentProperty["Attack_shui"];
        Defence_shui += EquipmentProperty["Defence_shui"];
        Attack_huo += EquipmentProperty["Attack_huo"];
        Defence_huo += EquipmentProperty["Defence_huo"];
        Attack_tu += EquipmentProperty["Attack_tu"];
        Defence_tu += EquipmentProperty["Defence_tu"];


    }
}
