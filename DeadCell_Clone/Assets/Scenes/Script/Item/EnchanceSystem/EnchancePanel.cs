using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class EnchancePanel : MonoBehaviour
{
	public StoneSlots[] StoneSlots;
	[SerializeField] Transform stoneSlotsParent;
	[SerializeField] Text resultNoti;

	public float rateTotalUp;
	public Character c;
	public Text rateEnchance;
	public float randomRate;
	[SerializeField]public EquipmentSlot equipSlot;
	[SerializeField] StatPanel statPanel;
	[SerializeField] EquipmentPanel equipmentPanel;
	public Button upgradeBtn;

	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	private void Start()
	{
		for (int i = 0; i < StoneSlots.Length; i++)
		{
			StoneSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
			StoneSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
			StoneSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
			StoneSlots[i].OnDragEvent += slot => OnDragEvent(slot);
			StoneSlots[i].OnDropEvent += slot => OnDropEvent(slot);
		}
		RefreshRate();
	}

	private void OnValidate()
	{
		StoneSlots = stoneSlotsParent.GetComponentsInChildren<StoneSlots>();
		c = FindObjectOfType<Character>();
	}

	public bool AddItem(EnchanceStone item, out EnchanceStone previousItem)
	{
		for (int i = 0; i < StoneSlots.Length; i++)
		{
			if (StoneSlots[i].stoneType == item.stoneType && !StoneSlots[i].isAdd)
			{
                previousItem = (EnchanceStone)StoneSlots[i].Item;
                StoneSlots[i].Item = item;
				StoneSlots[i].Amount = 1;
				StoneSlots[i].isAdd = true;
                if (equipSlot!=null)
                {
					getRateToEnchance(item);
				}
				return true;
			}
		}
		previousItem = null;
		return false;
	}

	public bool RemoveItem(EnchanceStone item)
	{
		for (int i = 0; i < StoneSlots.Length; i++)
		{
			if (StoneSlots[i].Item == item)
			{
				StoneSlots[i].Item = null;
				StoneSlots[i].Amount = 0;
				StoneSlots[i].isAdd = false;
				
				return true;
			}
		}
		return false;
	}
	public bool CanEnchance(EquipmentSlot equipmentSlot)
	{
		if (equipmentSlot.curEnchanceLv < equipmentSlot.maxEnchanceLv)
		{
			return true;
		}
		return false;
	}
	public void ChooseEquipToEnchance(EquipmentSlot equipment)
    {
		this.equipSlot = equipment;
        if (CanEnchance(equipment))
        {
			upgradeBtn.enabled = true;
			rateEnchance.text = (c.totalRateUp* 100).ToString() + "%";
			
        }
		ClearSlot();
	}
	public void Enchance()
    {
		randomRate = Random.value;
        if (CanEnchance(equipSlot))
        {
            if ((c.totalRateUp) >= randomRate)
            {
				equipSlot.curEnchanceLv += 1;
				
                resultNoti.gameObject.SetActive(true);
				
                resultNoti.text = "Thành công".ToString();
				
				ClearSlotEnchance();
				if (equipSlot == null)
				{
					upgradeBtn.interactable = false;
				}
            }
            else
            {
				
                resultNoti.gameObject.SetActive(true);
                resultNoti.text = "Thất bại";
				
				ClearSlotEnchance();
				if (equipSlot == null)
				{
					upgradeBtn.interactable = false;
				}
				
			}
			
		}
    }
	public void ClearSlotEnchance()
    {
		for (int i = 0; i < StoneSlots.Length; i++)
		{
			if (StoneSlots[i].Item != null)
			{
				c.RemoveAfterEnchance((EnchanceStone)StoneSlots[i].Item);
			}
		}
		c.totalRateUp = 0;
		
		equipmentPanel.GetStatAtCurLevel((EquippableItem)equipSlot.Item);
		statPanel.UpdateStatValues();
		RefreshRate();
	}
	public void ClearSlot()
    {
		for (int i = 0; i < StoneSlots.Length; i++)
		{
			if (StoneSlots[i].Item != null)
			{
				c.RemoveStone((EnchanceStone)StoneSlots[i].Item);
			}
		}
		c.totalRateUp = 0;
		RefreshRate();
	}
	public void RefreshRate()
	{
		rateEnchance.text = (c.totalRateUp * 100).ToString() + "%";
	}
	public void getRateToEnchance(EnchanceStone enchanceStone)
	{
		switch (equipSlot.curEnchanceLv)
		{
			case 0:
				enchanceStone.rateUp = enchanceStone.rateTo1;
				break;
			case 1:
				enchanceStone.rateUp = enchanceStone.rateTo2;
				break;
			case 2:
				enchanceStone.rateUp = enchanceStone.rateTo3;
				break;
			case 3:
				enchanceStone.rateUp = enchanceStone.rateTo4;
				break;
			case 4:
				enchanceStone.rateUp = enchanceStone.rateTo5;
				break;
			case 5:
				enchanceStone.rateUp = enchanceStone.rateTo6;
				break;
			case 6:
				enchanceStone.rateUp = enchanceStone.rateTo7;
				break;
			case 7:
				enchanceStone.rateUp = enchanceStone.rateTo8;
				break;
			case 8:
				enchanceStone.rateUp = enchanceStone.rateTo9;
				break;
			case 9:
				enchanceStone.rateUp = enchanceStone.rateTo10;
				break;
			default:
				break;
		}
	}
}
