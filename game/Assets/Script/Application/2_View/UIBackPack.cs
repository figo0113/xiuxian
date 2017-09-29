using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIBackPack : View
{
    public GameObject GridGroup;
    public override string Name
    {
        get
        {
            return Consts.V_UIBackPack;
        }
    }


    void initialize()
    {
        GameModel gm = GetModel<GameModel>();
        foreach (BackpackGrid gridInfo in gm.Backpack)
        {
            GameObject grid = (GameObject)Instantiate(Resources.Load("Prefab/Grid"));
            grid.transform.parent = GridGroup.transform;

            Text nametxt = grid.transform.Find("Name").GetComponent<Text>();
            //nametxt.text = gridInfo.Item.Name;
            nametxt.text = string.Format("<color={0}>{1}</color>", gridInfo.Item.GetQualityColor(), gridInfo.Item.Name);

            Text counttxt = grid.transform.Find("Count").GetComponent<Text>();
            counttxt.text = "数量："+gridInfo.Count.ToString();

            Text destxt = grid.transform.Find("Des").GetComponent<Text>();
            if (gridInfo.Item.Type == Item.ItemType.Equipment)
            {
                nametxt.text = string.Format("<color={0}>{1}}\t<size=28>{2}</size></color>", gridInfo.Item.GetQualityColor(), gridInfo.Item.Name, gridInfo.Item.GetItemTypeText());
                destxt.text = gridInfo.Item.GetPropertyText();
            }
            else
            {
                nametxt.text = string.Format("<color={0}>{1}</color>", gridInfo.Item.GetQualityColor(), gridInfo.Item.Name);
                destxt.text = gridInfo.Item.Description;
            }

            Image Icon = grid.transform.Find("Icon").GetComponent<Image>();
            string path = "Icon/Item/" + gridInfo.Item.Sprite;
            Icon.sprite =Resources.Load<Sprite>(path);
        }
    }

    void AddItem(int itemid,int count=1 )
    {
        GameModel gm = GetModel<GameModel>();
        Item item = Game.Instance.StaticData.GetItem(itemid);

        GameObject grid = (GameObject)Instantiate(Resources.Load("Prefab/Grid"));
        grid.transform.parent = GridGroup.transform;

        Text nametxt = grid.transform.Find("Name").GetComponent<Text>();
        //nametxt.text = item.Name;

        Text counttxt = grid.transform.Find("Count").GetComponent<Text>();
        counttxt.text = "数量：" + count.ToString();

        
        Text destxt = grid.transform.Find("Des").GetComponent<Text>();
        if (item.Type == Item.ItemType.Equipment)
        {
            nametxt.text = string.Format("<color={0}>{1}\t<size=28>{2}</size></color>", item.GetQualityColor(), item.Name,item.GetItemTypeText());
            destxt.text = item.GetPropertyText();
        }
        else
        {
            nametxt.text = string.Format("<color={0}>{1}</color>", item.GetQualityColor(), item.Name);
            destxt.text = item.Description;
        }

        Image Icon = grid.transform.Find("Icon").GetComponent<Image>();
        string path = "Icon/Item/" + item.Sprite;
        Icon.sprite = Resources.Load<Sprite>(path);
       

    }

    void AddItemCount(int index)
    {
        GameModel gm = GetModel<GameModel>();
        GameObject go = GridGroup.transform.GetChild(index).gameObject;
        Text counttxt = go.transform.Find("Count").GetComponent<Text>();
        //counttxt.text = (int.Parse(counttxt.text) + 1).ToString();
        counttxt.text = "数量：" + gm.Backpack[index].Count.ToString();
    }

    void RemoveItem(int index)
    {
        GameModel gm = GetModel<GameModel>();
        GameObject go = GridGroup.transform.GetChild(index).gameObject;
        Destroy(go);
    }

    void RemoveItemCount(int index)
    {
        GameModel gm = GetModel<GameModel>();
        GameObject go = GridGroup.transform.GetChild(index).gameObject;
        Text counttxt = go.transform.Find("Count").GetComponent<Text>();
        //counttxt.text = (int.Parse(counttxt.text) + 1).ToString();
        counttxt.text = "数量：" + gm.Backpack[index].Count.ToString();
    }


    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_EnterScene);
        AttentionEvents.Add(Consts.E_AddItem);
        AttentionEvents.Add(Consts.E_AddItemCount);
        AttentionEvents.Add(Consts.E_RemoveItem);
        AttentionEvents.Add(Consts.E_RemoveItemCount);
    }

    public override void HandleEvent(string eventName, object data)
    {
       switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e = data as SceneArgs;
                int scenceID = e.SceneIndex;
                if (scenceID == 2)
                    initialize();
                break;
            case Consts.E_AddItem:
                int itemid = (int)data;
                AddItem(itemid);
                break;
            case Consts.E_AddItemCount:
                int count = (int)data;
                AddItemCount(count);
                break;
            case Consts.E_RemoveItem:
                int index = (int)data;
                RemoveItem(index);
                break;
            case Consts.E_RemoveItemCount:
                int c_index = (int)data;
                RemoveItemCount(c_index);
                break;


        }

       
    }
    public void BoltAllitem()
    {
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public void BoltEquipment()
    {
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(true);
        }
        GameModel gm = GetModel<GameModel>();
        foreach (BackpackGrid gridInfo in gm.Backpack)
        {
            if (gridInfo.Item.Type != Item.ItemType.Equipment)
            {
                int index = gm.Backpack.IndexOf(gridInfo);
                GameObject go = GridGroup.transform.GetChild(index).gameObject;
                go.gameObject.SetActive(false);
            }
        }
    }

    public void BoltOtheritem()
    {
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(true);
        }
        GameModel gm = GetModel<GameModel>();
        foreach (BackpackGrid gridInfo in gm.Backpack)
        {
            if (gridInfo.Item.Type == Item.ItemType.Equipment)
            {
                int index = gm.Backpack.IndexOf(gridInfo);
                GameObject go = GridGroup.transform.GetChild(index).gameObject;
                go.gameObject.SetActive(false);
            }
        }
    }

}
