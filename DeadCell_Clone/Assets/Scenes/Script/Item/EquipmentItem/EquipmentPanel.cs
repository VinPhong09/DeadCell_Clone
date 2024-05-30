using QuanVo.CharacterStat;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentPanel : MonoBehaviour
{
	public EquipmentSlot[] EquipmentSlots;
	[SerializeField] Character c;
	[SerializeField] Transform equipmentSlotsParent;

	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;
	public event Action<BaseItemSlot> OnRightClickEvent;
	public event Action<BaseItemSlot> OnBeginDragEvent;
	public event Action<BaseItemSlot> OnEndDragEvent;
	public event Action<BaseItemSlot> OnDragEvent;
	public event Action<BaseItemSlot> OnDropEvent;

	private void Start()
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			EquipmentSlots[i].OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			EquipmentSlots[i].OnPointerExitEvent += slot => OnPointerExitEvent(slot);
			EquipmentSlots[i].OnRightClickEvent += slot => OnRightClickEvent(slot);
			EquipmentSlots[i].OnBeginDragEvent += slot => OnBeginDragEvent(slot);
			EquipmentSlots[i].OnEndDragEvent += slot => OnEndDragEvent(slot);
			EquipmentSlots[i].OnDragEvent += slot => OnDragEvent(slot);
			EquipmentSlots[i].OnDropEvent += slot => OnDropEvent(slot);
		}
	}

	private void OnValidate()
	{
		EquipmentSlots = equipmentSlotsParent.GetComponentsInChildren<EquipmentSlot>();
		c = FindObjectOfType<Character>();
	}

	public bool AddItem(EquippableItem item, out EquippableItem previousItem)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].EquipmentType == item.equipmentType)
			{
				previousItem = (EquippableItem)EquipmentSlots[i].Item;
				EquipmentSlots[i].Item = item;
				EquipmentSlots[i].Amount = 1;
				return true;
			}
		}
		previousItem = null;
		return false;
	}

	public bool RemoveItem(EquippableItem item)
	{
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].Item == item)
			{
				EquipmentSlots[i].Item = null;
				EquipmentSlots[i].Amount = 0;
				return true;
			}
		}
		return false;
	}
	public void GetStatAtCurLevel(EquippableItem equipItem)
    {
		for (int i = 0; i < EquipmentSlots.Length; i++)
		{
			if (EquipmentSlots[i].EquipmentType == equipItem.equipmentType)
			{
				
				c.HP.AddModifier(new StatModifier(equipItem.HP * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));
				c.playerStatus.IncreaseHealth(Convert.ToInt32(100 * (equipItem.HP *(1+ (EquipmentSlots[i].curEnchanceLv) * 0.05f))));
				
				c.MP.AddModifier(new StatModifier(equipItem.MP * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));
				c.playerStatus.IncreaseMana(Convert.ToInt32(50 * (equipItem.MP * (1 + (EquipmentSlots[i].curEnchanceLv) * 0.05f))));
				c.DA.AddModifier(new StatModifier(equipItem.DA * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));
				c.DEF.AddModifier(new StatModifier(equipItem.DEF * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));
				c.playerStatus.IncreaseDef(Convert.ToInt32(10 * (equipItem.DEF * (1 + (EquipmentSlots[i].curEnchanceLv) * 0.05f))));
				c.ArP.AddModifier(new StatModifier(equipItem.ArP * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));
				c.LUK.AddModifier(new StatModifier(equipItem.AS * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.Flat, this));

				if (equipItem.HPPercentBonus != 0)
					c.HP.AddModifier(new StatModifier(equipItem.HPPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
				if (equipItem.MPPercentBonus != 0)
					c.MP.AddModifier(new StatModifier(equipItem.MPPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
				if (equipItem.DAPercentBonus != 0)
					c.DA.AddModifier(new StatModifier(equipItem.DAPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
				if (equipItem.DEFPercentBonus != 0)
					c.DEF.AddModifier(new StatModifier(equipItem.DEFPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
				if (equipItem.ArPPercentBonus != 0)
					c.ArP.AddModifier(new StatModifier(equipItem.ArPPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
				if (equipItem.ASPercentBonus != 0)
					c.LUK.AddModifier(new StatModifier(equipItem.ASPercentBonus * (EquipmentSlots[i].curEnchanceLv) * 0.05f, StatModType.PercentMult, this));
			}
		}
	}
	public void GetOutEquip(Character c)
	{
		c.HP.RemoveAllModifiersFromSource(this);
		c.MP.RemoveAllModifiersFromSource(this);
		c.DA.RemoveAllModifiersFromSource(this);
		c.DEF.RemoveAllModifiersFromSource(this);
		c.ArP.RemoveAllModifiersFromSource(this);
		c.LUK.RemoveAllModifiersFromSource(this);
	}
}

