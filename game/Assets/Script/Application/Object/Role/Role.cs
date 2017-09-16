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
    public int reduceHurt;//免伤
    public int increaseHurt;//增伤

    public int speed;//攻速 基础100
    public int hp;
    public int maxHp;

    

    //生活技能（炼丹、炼器等）todo

    public Role(string name, int sex, int charm, int luck, int age, int maxAge, int trength, int dingli, int level, int morality, int killValue,
        int attack, int deffence, int hit, int miss, int reduceHurt, int increaseHurt, int speed, int hp,int maxHp)
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
