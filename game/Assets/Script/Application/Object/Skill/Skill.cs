﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill  {
    public int id;
    public string name;
    public int quality;//品质 1--绿色 2--蓝色 3--紫色 4--橙色
    public string sprite;
    public int maxLevel;
    public int trigger;//触发方式 1-攻击 2--被攻击 3--死亡
    public int tProbability;//出发概率 万分率
    public int target;//目标 1--敌方 2--自己
    public string formula; //公式
    public int buff;
    public int cd;
    public string Property;//被动增加的属性
    public string PropertyValue;//被动增加的属性值
    public string initiativeDes;//主动技能描述
    public string passiveDes;//被动技能描述


    public Skill(int id, string name, int quality,string sprite, int maxLevel,
     int trigger,int tProbability,int target, string formula,  int buff,int cd,
     string Property, string PropertyValue, string initiativeDes, string passiveDes)
    {
        this.id = id;
        this.name=name;
        this.quality= quality;
        this.sprite=sprite;
        this.maxLevel=maxLevel;
        this.trigger=trigger;
        this.tProbability= tProbability;
        this.target=target;
        this.formula= formula;
        this.buff=buff;
        this.cd=cd;
        this.Property=Property;
        this.PropertyValue=PropertyValue;
        this.initiativeDes= initiativeDes;
        this.passiveDes=passiveDes;
   }

}
