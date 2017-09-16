using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackpackGrid
{
    public Item Item;
    public int Count;//堆叠数

    public BackpackGrid(Item m_item, int count)
    {
        this.Item = m_item;
        this.Count = count;
    }

}
