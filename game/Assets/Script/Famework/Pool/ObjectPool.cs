using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class ObjectPool : Singleton<ObjectPool>
{
    public string ResourseDir = "";
    Dictionary<string, SubPool> m_pool = new Dictionary<string, SubPool>();

    //取对象
    public GameObject Spawn(string name)
    {
        if (!m_pool.ContainsKey(name))
            RegisterNew(name);
        SubPool pool = m_pool[name];
        return pool.Spawn();
    }

    //回收对象
    public void Unspawn(GameObject go)
    {
        SubPool pool = null;
        foreach (SubPool p in m_pool.Values)
        {
            if (p.Contains(go))
            {
                pool = p;
                break;
            }
        }
        pool.Unspawn(go);
    }
    //回收所有对象
    public void UnSpawnAll()
    {
        foreach (SubPool p in m_pool.Values)
            p.UnspawnAll();
    }


    //创建新池子

    void RegisterNew(string name)
    {
        string path = "";
        if (String.IsNullOrEmpty(ResourseDir))
            path = name;
        else
            path = ResourseDir + "/" + name;

        GameObject prefab = Resources.Load<GameObject>(path);

        SubPool p = new SubPool(transform, prefab);
        m_pool.Add(p.Name, p);

    }
}