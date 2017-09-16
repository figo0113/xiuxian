using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Formula  {

    public static void Attack(Role A, Role D)
    {
        int ActualHit = A.hit - D.miss;//实际命中
        int rand = Random.Range(1, 10000);
        int damage = 0;
        if (rand <= ActualHit)
        {
            damage = A.attack - D.deffence;

            if (damage < (int)(A.attack * 0.1))
                damage = (int)(A.attack * 0.1);
            if (damage < 1)
                damage = 1;
        }
        
        D.Hp = D.Hp - damage;
        if (D.Hp < 0)
            D.Hp = 0;
    }

    public static int DropItem(List<Drop> dropList,int luck)
    {
        int sumWeight=0;
        int itemID =0;
        if (dropList == null)
            return 0;
        foreach (Drop drop in dropList)
        {            
            sumWeight += drop.weight;
            drop.maxWeight = sumWeight;
        }

        int rand = Random.Range(0, sumWeight);
        foreach (Drop drop in dropList)
        {
            if (rand > drop.maxWeight)
                continue;
            else
            {
                itemID = drop.id;
                break;
            }
        }
        return itemID;        
    }
}
