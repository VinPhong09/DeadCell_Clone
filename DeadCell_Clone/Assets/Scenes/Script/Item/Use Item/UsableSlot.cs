using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableSlot : ItemSlot
{
    public UsableItemType itemType;
    public bool isAdd = false;

    protected override void OnValidate()
    {
        base.OnValidate();
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
