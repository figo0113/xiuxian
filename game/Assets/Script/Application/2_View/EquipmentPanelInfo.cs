using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentPanelInfo : View, IPointerEnterHandler, IPointerExitHandler
{

    public GameObject GridGroup;
    public GameObject oldEquip;

    public float OffsetY = -700; //Y方向的偏移量
    public float time = 0.55f;
    private bool isin = false;
    private bool isopen = false;
    private Vector3 originalPos;

    public override string Name
    {
        get
        {
            return Consts.V_EquipmentPanelInfo;
        }
    }

    public override void HandleEvent(string eventName, object data)
    {
        switch (eventName)
        {
            case Consts.E_EnterScene:
                SceneArgs e = data as SceneArgs;
                int scenceID = e.SceneIndex;
                if (scenceID == 2)
                    GetEquipList();
                break;
            case Consts.E_ItemUse:
                if(isopen)
                    ClosePanel();
                break;
            case Consts.E_EquipUpdate:
                UpdateEquipList();
                GetEquipList();
                break;
        }
    }

    public override void RegisterEvents()
    {
        AttentionEvents.Add(Consts.E_EnterScene);
        AttentionEvents.Add(Consts.E_EquipUpdate);
        AttentionEvents.Add(Consts.E_ItemUse);
    }

    // Use this for initialization
    void Start ()
    {
        originalPos = this.gameObject.transform.position;
	}
    private void Update()
    {

        if (Mathf.Abs(this.gameObject.transform.position.y - (originalPos.y + OffsetY)) < 0.5)
        {
            isopen = true;
        }

        if (isopen && !isin && Input.GetMouseButtonDown(0))
        {
            ClosePanel();
        }
    }

    public void ShowPanel()
    {
        if (!isopen)
        {
            this.gameObject.SetActive(true);
            iTween.MoveBy(gameObject, iTween.Hash(
                "y", OffsetY,
                "easeType", iTween.EaseType.easeOutQuad,
                "loopType", iTween.LoopType.none,
                "time", time));
        }

    }

    public void ClosePanel()
    {

        this.gameObject.SetActive(false);
        this.gameObject.transform.position = originalPos;//new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y - OffsetY, this.gameObject.transform.position.z);
        isopen = false;
    }
    public void OnPointerEnter(PointerEventData eventData)//当鼠标在目标UI
    {
        isin = true;
    }

    public void OnPointerExit(PointerEventData eventData)//当鼠标移除目标UI
    {
        isin = false;
    }

    void click()
    {
        isin = true;
    }
    void GetEquipList()
    {
        GameModel gm = GetModel<GameModel>();
        foreach (BackpackGrid gridInfo in gm.Backpack)
        {
            if (gridInfo.Item.Type == Item.ItemType.Equipment)
            {
                GameObject grid = (GameObject)Instantiate(Resources.Load("Prefab/Grid"));
                grid.transform.parent = GridGroup.transform;

                Text nametxt = grid.transform.Find("Name").GetComponent<Text>();
                //nametxt.text = gridInfo.Item.Name;
                nametxt.text = string.Format("<color={0}>{1}</color>", gridInfo.Item.GetQualityColor(), gridInfo.Item.Name);
                //nametxt.text = string.Format("<color={0}>{1}}\t<size=28>{2}</size></color>", gridInfo.Item.GetQualityColor(), gridInfo.Item.Name, gridInfo.Item.GetItemTypeText());

                Text counttxt = grid.transform.Find("Count").GetComponent<Text>();
                counttxt.text = "数量：" + gridInfo.Count.ToString();

                Text destxt = grid.transform.Find("Des").GetComponent<Text>();
                destxt.text = gridInfo.Item.GetPropertyText();

                Image Icon = grid.transform.Find("Icon").GetComponent<Image>();
                string path = "Icon/Item/" + gridInfo.Item.Sprite;
                Icon.sprite = Resources.Load<Sprite>(path);

                Button useButton = grid.transform.Find("UseBtn").GetComponent<Button>();
                //Text useButtonText = useButton.GetComponent<Text>();
                Text useButtonText = useButton.transform.Find("Text").GetComponent<Text>();
                useButton.GetComponent<ItemUseButton>().itemID = gridInfo.Item.ID;
                useButtonText.text = "装备";

                Equipment equip = (Equipment)gridInfo.Item;
                switch(equip.EquipType)
                {
                    case Equipment.EquipmentType.Weapon:
                        grid.tag = "Weapon";
                        break;
                    case Equipment.EquipmentType.Headpiece:
                        grid.tag = "Headpiece";
                        break;
                    case Equipment.EquipmentType.Armor:
                        grid.tag = "Armor";
                        break;
                    case Equipment.EquipmentType.Boots:
                        grid.tag = "Boots";
                        break;
                    case Equipment.EquipmentType.Jewelry:
                        grid.tag = "Jewelry";
                        break;
                }
            }
        }
    }

    void UpdateEquipList()
    {
        foreach(Transform child in GridGroup.transform)
        {
            if (child.name != "Equipped")
                Destroy(child.gameObject);
        }
    }
    void SetOldEquipData(int equipId)
    {
        Item item = Game.Instance.StaticData.GetItem(equipId);
        Text nametxt = oldEquip.transform.Find("Name").GetComponent<Text>();
        nametxt.text = string.Format("<color={0}>{1}</color>", item.GetQualityColor(), item.Name);

        Text destxt = oldEquip.transform.Find("Des").GetComponent<Text>();
        destxt.text = item.GetPropertyText();

        Image Icon = oldEquip.transform.Find("Icon").GetComponent<Image>();
        string path = "Icon/Item/" + item.Sprite;
        Icon.sprite = Resources.Load<Sprite>(path);
        Equipment equip = (Equipment)item;
        switch (equip.EquipType)
        {
            case Equipment.EquipmentType.Weapon:
                oldEquip.tag = "Weapon";
                break;
            case Equipment.EquipmentType.Headpiece:
                oldEquip.tag = "Headpiece";
                break;
            case Equipment.EquipmentType.Armor:
                oldEquip.tag = "Armor";
                break;
            case Equipment.EquipmentType.Boots:
                oldEquip.tag = "Boots";
                break;
            case Equipment.EquipmentType.Jewelry:
                oldEquip.tag = "Jewelry";
                break;
        }

    }
    public void GetWeaponList()
    {
        GameModel gm = GetModel<GameModel>();
        int equipnum = 0;
        if (gm.player.playerEquipment[0] == null)
            oldEquip.SetActive(false);
        else
        {
            SetOldEquipData(gm.player.playerEquipment[0].ID);
        }
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in GridGroup.transform)
        {
            if (child.tag == "Weapon")
            {
                child.gameObject.SetActive(true);
                equipnum++;
            }
        }
        if (equipnum == 0)
            SendEvent(Consts.E_MidTextShow, string.Format("<color={0}>{1}</color>", "red", "没有可装备的武器"));
        else
            ShowPanel();
    }
    public void GetHatList()
    {
        GameModel gm = GetModel<GameModel>();
        int equipnum = 0;
        if (gm.player.playerEquipment[1] == null)
            oldEquip.SetActive(false);
        else
        {
            SetOldEquipData(gm.player.playerEquipment[1].ID);
        }
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in GridGroup.transform)
        {
            if (child.tag == "Headpiece")
            {
                child.gameObject.SetActive(true);
                equipnum++;
            }
        }
        if (equipnum == 0)
            SendEvent(Consts.E_MidTextShow, string.Format("<color={0}>{1}</color>", "red", "没有可装备的帽子"));
        else
            ShowPanel();
    }
    public void GetCothesList()
    {
        GameModel gm = GetModel<GameModel>();
        int equipnum = 0;
        if (gm.player.playerEquipment[2] == null)
            oldEquip.SetActive(false);
        else
        {
            SetOldEquipData(gm.player.playerEquipment[2].ID);
        }
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in GridGroup.transform)
        {
            if (child.tag == "Armor")
            {
                child.gameObject.SetActive(true);
                if(child.name!= "Equipped")
                    equipnum++;
            }
        }
        if (equipnum == 0)
            SendEvent(Consts.E_MidTextShow, string.Format("<color={0}>{1}</color>", "red", "没有可装备的衣服"));
        else
            ShowPanel();
    }
    public void GetShoesList()
    {
        GameModel gm = GetModel<GameModel>();
        int equipnum = 0;
        if (gm.player.playerEquipment[3] == null)
            oldEquip.SetActive(false);
        else
        {
            SetOldEquipData(gm.player.playerEquipment[3].ID);
        }
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in GridGroup.transform)
        {
            if (child.tag == "Boots")
            {
                child.gameObject.SetActive(true);
                equipnum++;
            }
        }
        if (equipnum == 0)
            SendEvent(Consts.E_MidTextShow, string.Format("<color={0}>{1}</color>", "red", "没有可装备的鞋子"));
        else
            ShowPanel();
    }
    public void GetOrnamentList()
    {
        GameModel gm = GetModel<GameModel>();
        int equipnum = 0;
        if (gm.player.playerEquipment[4] == null)
            oldEquip.SetActive(false);
        else
        {
            SetOldEquipData(gm.player.playerEquipment[4].ID);
        }
        foreach (Transform child in GridGroup.transform)
        {
            child.gameObject.SetActive(false);
        }
        foreach (Transform child in GridGroup.transform)
        {
            if (child.tag == "Jewelry")
            {
                child.gameObject.SetActive(true);
                equipnum++;
            }
        }
        if (equipnum == 0)
            SendEvent(Consts.E_MidTextShow, string.Format("<color={0}>{1}</color>", "red", "没有可装备的饰品"));
        else
            ShowPanel();
    }
}
