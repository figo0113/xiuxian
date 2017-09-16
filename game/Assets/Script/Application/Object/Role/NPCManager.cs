using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour {

    private List<NPC> NPCList;

    void ParseNPCJson()
    {
        NPCList = new List<NPC>();
        TextAsset NPCText = Resources.Load<TextAsset>("NPC");
        string NPCJson = NPCText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(NPCJson);

        foreach (JSONObject temp in j.list)
        {
            int id = (int)temp["id"].n;
            string name = temp["name"].str;
            int sex = (int)temp["sex"].n;
            int charm = (int)temp["charm"].n;
            int luck = (int)temp["luck"].n;
            int savvy = (int)temp["savvy"].n;

            int age = (int)temp["age"].n;
            int maxAge = (int)temp["maxAge"].n;
            int trength = (int)temp["trength"].n;
            int dingli = (int)temp["dingli"].n;
            int level = (int)temp["level"].n;

            int morality = (int)temp["morality"].n;
            int killValue = (int)temp["killValue"].n;
            //int exp = (int)temp["exp"].n;

            int attack = (int)temp["attack"].n;
            int deffence = (int)temp["deffence"].n;
            int hit = (int)temp["hit"].n;
            int miss = (int)temp["miss"].n;
            int reduceHurt = (int)temp["reduceHurt"].n;
            int increaseHurt = (int)temp["increaseHurt"].n;

            int speed = (int)temp["speed"].n;
            int hp = (int)temp["hp"].n;
            int maxHp = (int)temp["maxHp"].n;

            string talk = temp["talk"].str;
            string des = temp["des"].str;

            NPC npc = new NPC(id, name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, attack, deffence, hit, miss, reduceHurt, increaseHurt, speed, hp, maxHp, talk, des);

            NPCList.Add(npc);
        }
    }


    private void Awake()
    {
        ParseNPCJson();
        //Debug.Log(NPCList[0].talk);
    }

}
