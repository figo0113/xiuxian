using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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
        List<int> weight = new List<int>();
        List<int> maxWeight = new List<int>();

        int luckWeight = 0;
        int sumWeight=0;
        int itemID =0;
        if (dropList.Count==0)
            return 0;

        foreach (Drop drop in dropList)
        {
            weight.Add(drop.weight);
        }
        int MinWeight = weight.Min(); //最小权值; 

        luckWeight = (luck - 20) * 100;
        luckWeight = Mathf.Clamp(luckWeight, 0, 8000); //幸运值转化的权重为0--8000，暂定
        Debug.Log("幸运权值=" + luckWeight);

        for (int i = 0; i< dropList.Count; i++)
        {
            Debug.Log("初始权值=" + weight[i]);
            if (luckWeight > weight[i] - MinWeight)
            {                
                luckWeight = luckWeight - weight[i] + MinWeight;
                weight[i] = MinWeight;
            }
            else
            {                
                weight[i] = weight[i] - luckWeight;
                luckWeight = 0;
            }                                 
            sumWeight += weight[i];
            maxWeight.Add(sumWeight) ;
            Debug.Log("加成后权值="+weight[i]+","+"累积权值="+maxWeight[i]);
        }
        
        int rand = Random.Range(0, sumWeight);
        Debug.Log("随机数=" + rand);
        for (int i = 0; i < dropList.Count; i++)
        {
            if (rand >= maxWeight[i])
            {
                continue;
            }
            else
            {
                itemID = dropList[i].id;
                Debug.Log("掉落区间=" + i);
                break;
            }
        }
        return itemID;        
    }
}
