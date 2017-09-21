using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//主角类
public class Player:Role  {
    public event Action<int> Upgrade;
    public event Action<int> ExpChange;

    public event Action<Player> PropertyChange;

    private const int maxlevel = 36; //测试等级 36级

    private int exp = 0;//经验
    public int maxExp;


    private int aptitude_jin = 0;
    private int aptitude_mu = 0;
    private int aptitude_shui = 0;
    private int aptitude_huo = 0;
    private int aptitude_tu = 0;

    public Player(string name, int sex, int charm, int luck, int age, int maxAge, int trength, int dingli, int level, int morality, int killValue, int attack, int deffence, int hit, int miss, 
        int reduceHurt, int increaseHurt, int speed,int hp, int maxHp, int attack_jin = 0, int defence_jin = 0,int attack_mu = 0, int defence_mu = 0, int attack_shui = 0, int defence_shui = 0, 
        int attack_huo = 0, int defence_huo = 0, int attack_tu = 0, int defence_tu = 0) : base(name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, attack, deffence,  hit,  
            miss,  reduceHurt,  increaseHurt, speed,hp, maxHp,attack_jin,defence_jin,attack_mu,defence_mu,attack_shui,defence_shui,attack_huo,defence_huo,attack_tu,defence_tu)
    {
        this.maxExp = Game.Instance.StaticData.getMaxExp(level);
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

    private void upgrade()
    {
            this.Level++;
            this.maxExp = Game.Instance.StaticData.getMaxExp(Level);

            if (Upgrade != null)
                Upgrade(Level);
    }
}
