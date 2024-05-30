using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using QuanVo.CharacterStat;
public class Inventory : ItemContainer
{
	[SerializeField] protected Item[] startingItems;
	[SerializeField] protected Transform itemsParent;

	protected override void OnValidate()
	{
		if (itemsParent != null)
			itemsParent.GetComponentsInChildren(includeInactive: true, result: ItemSlots);

		if (!Application.isPlaying)
		{
			SetStartingItems();
		}
	}

	protected override void Awake()
	{
		base.Awake();	
		SetStartingItems();
	}
    private void Update()
    {
        
    }

    private void SetStartingItems()
	{
		//Clear();
		foreach (Item item in startingItems)
		{
			AddItem(item.GetCopy());
		}
	}
}


