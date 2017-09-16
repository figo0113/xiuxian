using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
//using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Map {

    public int ID;

    public string name;

    //入口Node索引
    public string entranceIndex;

    //所有节点
    public Dictionary <string, Node> allNode;


    public Map(int ID, string name, string entranceIndex, Dictionary<string, Node> allNode)
    {
        this.ID = ID;
        this.name = name;
        this.entranceIndex = entranceIndex;
        this.allNode = allNode;
    }


    /*public object Clone()

    {

        //创建内存流     

        MemoryStream ms = new MemoryStream();

        //以二进制格式进行序列化          
    
        BinaryFormatter bf = new BinaryFormatter();

        bf.Serialize(ms, this);

        //反序列化当前实例到一个object    

        ms.Seek(0, 0);

        object obj = bf.Deserialize(ms);

        //关闭内存流            

        ms.Close();

        return obj;

    }*/


}
