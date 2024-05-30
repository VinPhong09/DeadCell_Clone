using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[Serializable]
public struct ItemAmount
{
    public EquippableItem Item;
    [Range(1,999)]
    public int amount;
    
}
[CreateAssetMenu]
public class CraftingRecipe : ScriptableObject
{
    public List<ItemAmount> Materials;
    public List<ItemAmount> Results;
    public int price;
    public float successRate;
    public bool CanCraft(IItemContainer itemContainer)
    {
        foreach (ItemAmount itemAmount in Materials)
        {
            if ((itemContainer.ItemCount(itemAmount.Item.ID) < itemAmount.amount))
            {
                return false;
            }
        }
        return true;
    }
    
    public void Craft(IItemContainer itemContainer)
    {
        
            foreach (ItemAmount itemAmount in Materials)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    Item oldItem = itemContainer.RemoveItem(itemAmount.Item.ID);
                    oldItem.Destroy();
                }
            }

            foreach (ItemAmount itemAmount in Results)
            {
                for (int i = 0; i < itemAmount.amount; i++)
                {
                    itemContainer.AddItem(itemAmount.Item.GetCopy());
                }
            }
        
    }
}
