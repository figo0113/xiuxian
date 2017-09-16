using UnityEngine;
using System.Collections;
/// <summary>
/// 消耗品类
/// </summary>
public class Consumable : Item {

    public int Function { get; set; } //功能枚举
    public int Value { get; set; }

    public Consumable(int id, string name, ItemType type, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice ,string sprite,int function, int value)
        :base(id,name,type,quality,des,capacity,buyPrice,sellPrice,sprite)
    {
        this.Function = function;
        this.Value = value;
    }

   /* public override string GetToolTipText()
    {
        string text = base.GetToolTipText();

        string newText = string.Format("{0}\n\n<color=blue>加血：{1}\n加蓝：{2}</color>", text, HP, MP);

        return newText;
    }*/


}
