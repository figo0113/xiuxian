using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//绑到Game物体上
public class StaticData : Singleton<StaticData>
{
     Dictionary<int, Map> Maps = new Dictionary<int, Map>();
     Dictionary<int, Item> Items = new Dictionary<int, Item>();
     Dictionary<int, Level> Level = new Dictionary<int, Level>();
     Dictionary<int, Monster> Monsters = new Dictionary<int, Monster>();


    protected override void Awake()
    {
        base.Awake();
        ParseMapJson();
        ParseItemJson();
        ParseLevelJson();
        ParseMonsterJson();
    }

    public int getMaxExp(int level)
    {
        return Level[level].maxExp;
    }

    public Monster getMonster(int id)
    {
        return Monsters[id];
    }

    public Monster SpawnMonster(int Monsterid)
    {
        int id = getMonster(Monsterid).id;
        string name = getMonster(Monsterid).name;
        int sex = getMonster(Monsterid).sex;
        int charm = getMonster(Monsterid).charm;
        int luck = getMonster(Monsterid).luck;


        int age = getMonster(Monsterid).age;
        int maxAge = getMonster(Monsterid).maxAge;
        int trength = getMonster(Monsterid).trength;
        int dingli = getMonster(Monsterid).dingli;
        int level = getMonster(Monsterid).level;

        int morality = getMonster(Monsterid).morality;
        int killValue = getMonster(Monsterid).killValue;


        int attack = getMonster(Monsterid).attack;
        int deffence = getMonster(Monsterid).deffence;

        int hit = getMonster(Monsterid).hit;
        int miss = getMonster(Monsterid).miss;
        int reduceHurt = getMonster(Monsterid).reduceHurt;
        int increaseHurt = getMonster(Monsterid).increaseHurt;
        int speed = getMonster(Monsterid).speed;
        int hp = getMonster(Monsterid).hp;
        int maxHp = getMonster(Monsterid).maxHp;

        string des = getMonster(Monsterid).des;
        List<Drop> drop = getMonster(Monsterid).drop;

        Monster monster = new Monster(id, name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, 
            attack, deffence, hit, miss, reduceHurt, increaseHurt,speed, hp, maxHp, des, drop);
        return monster;
    }

    public string getLevelDes(int level)
    {
        return Level[level].levelDes;
    }

    public Map GetMap(int index)
    {
        return Maps[index];
    }
    //取道具
    public Item GetItem(int index)
    {
        return Items[index];
    }


    public void ParseMapJson()
    {
        TextAsset MapText = Resources.Load<TextAsset>("Map");
        string MapJson = MapText.text;//物品信息的Json格式
        JSONObject json = new JSONObject(MapJson);
        
        foreach (JSONObject temp in json.list)
        {
            int ID = (int)temp["ID"].n;
            string name = temp["name"].str;
            string entranceIndex =((int)temp["entranceX"].n).ToString()+"," + ((int)temp["entranceY"].n).ToString();
            JSONObject Nodes = temp["allNode"];
            Dictionary<string, Node> allNode = new Dictionary<string, Node>();
            foreach (JSONObject temp2 in Nodes.list)
            {
                string nodename = temp2["name"].str;
                int X = (int)temp2["X"].n;
                int Y = (int)temp2["Y"].n;
                bool up = temp2["up"].b;
                bool down = temp2["down"].b;
                bool left = temp2["left"].b;
                bool right = temp2["right"].b;
                JSONObject NPCs = temp2["includeNPC"];
                List<int> includeNPC = new List<int>();
                foreach (JSONObject temp3 in NPCs.list)
                {
                    int NPCID = (int)temp3.n;
                    includeNPC.Add(NPCID);
                }

                JSONObject Monsters = temp2["includeMonster"];
                List<int> includeMonster = new List<int>();
                foreach (JSONObject temp4 in Monsters.list)
                {
                    int MonsterID = (int)temp4.n;
                    includeMonster.Add(MonsterID);
                }
                JSONObject Collections = temp2["Collections"];
                List<int> incudeCollection = new List<int>();
                foreach (JSONObject temp5 in Monsters.list)
                {
                    int ItemID = (int)temp5.n;
                    incudeCollection.Add(ItemID);
                }
                string index = X.ToString() + "," + Y.ToString();
                Node node = new Node(nodename, index, up, down,left,right, includeNPC, includeMonster,incudeCollection);
                allNode.Add(index, node);
            }
            Map map = new Map(ID,name, entranceIndex, allNode);
            Maps.Add(ID, map);
         }   
    }

    public void ParseItemJson()
    {
        Items = new Dictionary<int, Item>();
        //文本为在Unity里面是 TextAsset类型
        TextAsset itemText = Resources.Load<TextAsset>("Item");
        string itemsJson = itemText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(itemsJson);
        foreach (JSONObject temp in j.list)
        {
            string typeStr = temp["type"].str;
            Item.ItemType type = (Item.ItemType)System.Enum.Parse(typeof(Item.ItemType), typeStr);

            //下面的事解析这个对象里面的公有属性
            int id = (int)(temp["id"].n);
            string name = temp["name"].str;
            Item.ItemQuality quality = (Item.ItemQuality)System.Enum.Parse(typeof(Item.ItemQuality), temp["quality"].str);
            string description = temp["description"].str;
            int capacity = (int)(temp["capacity"].n);
            int buyPrice = (int)(temp["buyPrice"].n);
            int sellPrice = (int)(temp["sellPrice"].n);
            string sprite = temp["sprite"].str;

            Item item = null;
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int function = (int)(temp["function"].n);
                    int value = (int)(temp["value"].n);
                    item = new Consumable(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, function, value);
                    break;
                case Item.ItemType.Equipment:
                    Equipment.EquipmentType equipType = (Equipment.EquipmentType)System.Enum.Parse(typeof(Equipment.EquipmentType), temp["equipType"].str);
                    JSONObject equipProperty = temp["equipProperty"];
                    int[] property = new int[21];
                    int i = 0;
                    foreach (JSONObject temp2 in equipProperty.list)
                    {
                        property[i] = (int)temp2.n;
                        i++;
                    }
                    item = new Equipment(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, property, equipType);
                    break;
                case Item.ItemType.Material:
                    //
                    item = new Material(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite);
                    break;
            }
            Items.Add(id, item);
           
        }
    }
    public void ParseLevelJson()
    {
        Level = new Dictionary<int, Level>();
        //文本为在Unity里面是 TextAsset类型
        TextAsset itemText = Resources.Load<TextAsset>("Level");
        string itemsJson = itemText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(itemsJson);
        foreach (JSONObject temp in j.list)
        {
            int level =(int) temp["level"].n;
            int exp = (int)temp["exp"].n;
            string des = temp["des"].str;

            Level m_level = new Level(level, exp, des);
            Level.Add(level, m_level);
        }
     }

    void ParseMonsterJson()
    {

        TextAsset MonsterText = Resources.Load<TextAsset>("Monster");
        string MonsterJson = MonsterText.text;//物品信息的Json格式
        JSONObject j = new JSONObject(MonsterJson);

        foreach (JSONObject temp in j.list)
        {
            int id = (int)temp["id"].n;
            string name = temp["name"].str;
            int sex = (int)temp["sex"].n;
            int charm = (int)temp["charm"].n;
            int luck = (int)temp["luck"].n;
            

            int age = (int)temp["age"].n;
            int maxAge = (int)temp["maxAge"].n;
            int trength = (int)temp["trength"].n;
            int dingli = (int)temp["dingli"].n;
            int level = (int)temp["level"].n;

            int morality = (int)temp["morality"].n;
            int killValue = (int)temp["killValue"].n;
           

            int attack = (int)temp["attack"].n;
            int deffence = (int)temp["deffence"].n;

            int hit = (int)temp["hit"].n;
            int miss = (int)temp["miss"].n;
            int reduceHurt = (int)temp["reduceHurt"].n;
            int increaseHurt = (int)temp["increaseHurt"].n;
            int speed = (int)temp["speed"].n;
            int hp = (int)temp["hp"].n;
            int maxHp = (int)temp["maxHp"].n;

            
            string des = temp["des"].str;

            JSONObject drops = temp["drop"];
            List<Drop> dropList= new List<Drop>();
            foreach (JSONObject temp2 in drops.list)
            {
                int itemId = (int)temp2["id"].n;
                int weight = (int)temp2["weight"].n;
                dropList.Add(new Drop(id,weight));
            }
            Monster monster = new Monster(id,name, sex, charm, luck, age, maxAge, trength, dingli, level, morality, killValue, attack, deffence, hit, miss, reduceHurt, increaseHurt, speed,hp, maxHp, des, dropList);

            Monsters.Add(id, monster);
        }
    }

}
