﻿using UnityEngine;
using System.Collections;

/// <summary>
/// 材料类
/// </summary>
public class Material : Item {

    public Material(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice,string sprite)
        : base(id, name, type, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
    }
}
