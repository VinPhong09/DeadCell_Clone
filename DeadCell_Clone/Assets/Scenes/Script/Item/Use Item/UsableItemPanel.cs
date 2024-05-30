using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsableItemPanel : MonoBehaviour
{
    public UsableSlot[] usableSlots;
    [SerializeField] Transform usableSlotsParent;
	[SerializeField] Character c;
	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	private void Start()
	{
		for (int i = 0; i < usableSlots.Length; i++)
		{
			usableSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
			usableSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
			usableSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
			usableSlots[i].OnDragEvent += slot => OnDragEvent(slot);
			usableSlots[i].OnDropEvent += slot => OnDropEvent(slot);
		}
;
	}

	private void OnValidate()
	{
		usableSlots = usableSlotsParent.GetComponentsInChildren<UsableSlot>();
		c = FindObjectOfType<Character>();
		
	}
	// Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        
    }
	public void UseItem(UsableSlot item)
    {
		
		if (item.Item != null)
		{
			c.UsePotion(item);
		}
		
    }
    
    public bool AddItem(UsableItem item, out UsableItem previousItem)
    {
        for (int i = 0; i < usableSlots.Length; i++)
        {
            if (usableSlots[i].itemType == item.itemType)
            {
                previousItem = (UsableItem)usableSlots[i].Item;
                usableSlots[i].Item = item;
                usableSlots[i].Amount += 1;
                usableSlots[i].isAdd = true;

                return true;
            }
        }
        previousItem = null;
        return false;
    }
    public bool RemoveItem(UsableItem item)
	{
		for (int i = 0; i < usableSlots.Length; i++)
		{
			if (usableSlots[i].Item == item)
			{
				usableSlots[i].Item = null;
				usableSlots[i].Amount = 0;
				usableSlots[i].isAdd = false;

				return true;
			}
		}
		return false;
	}
}
