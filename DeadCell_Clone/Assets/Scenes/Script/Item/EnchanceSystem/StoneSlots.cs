using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneSlots : ItemSlot
{
    public StoneType stoneType;
    public bool isAdd = false;
    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = stoneType.ToString();
    }

    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
        {
            return true;
        }
        EnchanceStone stoneItem = item as EnchanceStone;
        return stoneItem != null;
    }
}
