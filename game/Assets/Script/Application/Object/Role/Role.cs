using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Role  {

    public event Action<Role> Dead; //死亡
    public event Action<int> HpChange; //死亡

    public string name;
    public int sex;//0-女 1-男
    public int charm;//魅力
    public int luck;//福缘
    

    public int age ;//年龄
    public int maxAge ;//寿命上限
    public int trength;//体魄
    public int dingli;//定力
    public int level;//境界=等级
                    
    public int morality = 0;//道德
    public int killValue = 0;//杀戮值



    //战斗属性后续再添加
    public int attack;
    public int deffence;
    public int hit;//命中 万分率
    public int miss;//闪避 万分率
    public int reduceHurt;//免伤  万分率
    public int increaseHurt;//增伤 万分率
    public int attack_jin;//金攻
    public int defence_jin;//金防
    public int attack_mu;//木攻
    public int defence_mu;//木防
    public int attack_shui;//水攻
    public int defence_shui;//水防
    public int attack_huo;//火攻
    public int defence_huo;//火防
    public int attack_tu;//土攻
    public int defence_tu;//土防

    public int speed;//攻速 基础100
    public int hp;
    public int maxHp;

    

    //生活技能（炼丹、炼器等）todo(应该写到player里)
    //技能列表（todo）

    public Role(string name, int sex, int charm, int luck, int age, int maxAge, int trength, int dingli, int level, int morality, int killValue,
        int attack, int deffence, int hit, int miss, int reduceHurt, int increaseHurt, int speed, int hp,int maxHp,int attack_jin=0,int defence_jin = 0,
        int attack_mu = 0, int defence_mu = 0, int attack_shui = 0, int defence_shui = 0, int attack_huo = 0, int defence_huo = 0, int attack_tu = 0, int defence_tu = 0)
    {
        this.name = name;
        this.sex = sex;
        this.charm = charm;
        this.luck = luck;
        

        this.age = age;
        this.maxAge = maxAge;
        this.trength = trength;
        this.dingli = dingli;
        this.level = level;

        this.morality = morality;
        this.killValue = killValue;

        this.attack = attack;
        this.deffence = deffence;
        this.hit =hit;
        this.miss = miss;
        this.reduceHurt = reduceHurt;
        this.increaseHurt = increaseHurt;
        this.speed = speed;

        this.attack_jin = attack_jin;
        this.defence_jin = defence_jin;
        this.attack_mu = attack_mu;
        this.defence_mu = defence_mu;
        this.attack_shui = attack_shui;
        this.defence_shui = defence_shui;
        this.attack_huo = attack_huo;
        this.defence_huo = defence_huo;
        this.attack_tu = attack_tu;
        this.defence_tu = defence_tu;

        this.hp = hp;
        this.maxHp = maxHp;

    }
    public int Hp
    {
        get
        {
            return hp;
        }

        set
        {
            if (hp < 0)
                hp = 0;
            hp = value;
            if (HpChange != null)
                HpChange(hp);
            if (hp == 0)
            {
                if (Dead != null)
                    Dead(this);
            }
        }
    }
}
