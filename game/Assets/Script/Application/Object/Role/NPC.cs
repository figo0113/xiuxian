using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC:Role  {


    public int id;
    public int relationshipValue = 0;//亲密值
    public int relationship =0;//关系：路人，朋友，知己，师傅，徒弟，夫妻，仇人
    public string talk;
    public bool isdead = false;
    public string des;

    public NPC(int id, string name, int sex, 
            int charm, int luck, int age, 
            int maxAge, int trength, 
            int dingli, int level, int morality, 
            int killValue, int attack, int deffence, 
            int hit, int miss, int reduceHurt, 
            int increaseHurt,int speed, int hp, int maxHp,  
            string talk, string des) 
        : base(name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue,  attack, deffence, hit, miss, reduceHurt, 
            increaseHurt, speed ,hp, maxHp)
    {
        this.id = id;
        //this.relationship = relationship;
        //this.relationshipValue = relationshipValue;
        this.talk = talk;
        this.des = des;
    }
}
