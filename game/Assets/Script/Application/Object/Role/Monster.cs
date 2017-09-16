using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Monster : Role
{
    
    public int id;
    public string des;
    public List<Drop> drop;
    public Monster(int id,string name, int sex, int charm, int luck, int age, int maxAge, int trength, int dingli, int level, int morality, int killValue, int attack, int deffence, int hit, int miss, int reduceHurt, int increaseHurt, int speed, int hp, int maxHp,string des, List<Drop> drop) : base(name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, attack, deffence, hit, miss, reduceHurt, increaseHurt,speed, hp, maxHp)
    {
        this.id = id;
        this.des = des;
        this.drop = drop;
    }



}
