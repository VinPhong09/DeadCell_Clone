using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class CraftingRecipeUI : MonoBehaviour
{
	[Header("References")]
	[SerializeField] RectTransform arrowParent;
	[SerializeField] BaseItemSlot[] itemSlots;
	[SerializeField] Text price;
	[SerializeField] EquipmentSlot slot;
	[SerializeField] protected Text rateSuccess;
	[SerializeField] Character c;
	[SerializeField] Button craft;

	[Header("Public Variables")]
	public ItemContainer ItemContainer;
	public float randomRate;

	private CraftingRecipe craftingRecipe;
	public CraftingRecipe CraftingRecipe
	{
		get { return craftingRecipe; }
		set { SetCraftingRecipe(value); }
	}

	public event Action<BaseItemSlot> OnPointerEnterEvent;
	public event Action<BaseItemSlot> OnPointerExitEvent;

	private void OnValidate()
	{
		itemSlots = GetComponentsInChildren<BaseItemSlot>(includeInactive: true);
		ItemContainer.FindObjectOfType<Inventory>();
		c = FindObjectOfType<Character>();
	}

	private void Start()
	{
		foreach (BaseItemSlot itemSlot in itemSlots)
		{
			itemSlot.OnPointerEnterEvent += slot => OnPointerEnterEvent(slot);
			itemSlot.OnPointerExitEvent += slot => OnPointerExitEvent(slot);
		}
		//rateSuccess.text = craftingRecipe.successRate.ToString();
	}
    private void Update()
    {
        if (CanCraft())
        {
            craft.interactable = true;
        }
        else craft.interactable = false;
        
	}
    public bool CanCraft()
    {
		for (int i = 0; i < c.EquipmentPanel.EquipmentSlots.Length; i++)
		{
			foreach (ItemAmount item in craftingRecipe.Materials)
			{
                if (c.EquipmentPanel.EquipmentSlots[i].EquipmentType.Equals(item.Item.equipmentType) && c.EquipmentPanel.EquipmentSlots[i].curEnchanceLv >= c.EquipmentPanel.EquipmentSlots[i].maxEnchanceLv)
                {
					slot = c.EquipmentPanel.EquipmentSlots[i];
					if (craftingRecipe.CanCraft(ItemContainer) && craftingRecipe.price <= c.numGold)
					{
						return true;
					}
                }
                else
                {
					return false;
                }
			}
		}
		return false;
    }

	public void OnCraftButtonClick()
	{
		randomRate = Random.value;
		
		if (craftingRecipe != null && ItemContainer != null && randomRate <= craftingRecipe.successRate)
		{
            if (CanCraft())
            {
				craftingRecipe.Craft(ItemContainer);
				slot.curEnchanceLv = 0;
            }
		}
		Debug.Log("Action success");
		c.numGold -= craftingRecipe.price;
	}

	private void SetCraftingRecipe(CraftingRecipe newCraftingRecipe)
	{
		craftingRecipe = newCraftingRecipe;

		if (craftingRecipe != null)
		{
			int slotIndex = 0;
			slotIndex = SetSlots(craftingRecipe.Materials, slotIndex);
			//arrowParent.SetSiblingIndex(slotIndex);
			slotIndex = SetSlots(craftingRecipe.Results, slotIndex);

			for (int i = slotIndex; i < itemSlots.Length; i++)
			{
				itemSlots[i].transform.parent.gameObject.SetActive(false);
			}
			price.text = craftingRecipe.price.ToString();
			gameObject.SetActive(true);
		}
		else
		{
			gameObject.SetActive(false);
		}
	}

	private int SetSlots(IList<ItemAmount> itemAmountList, int slotIndex)
	{
		for (int i = 0; i < itemAmountList.Count; i++, slotIndex++)
		{
			ItemAmount itemAmount = itemAmountList[i];
			BaseItemSlot itemSlot = itemSlots[slotIndex];

			itemSlot.Item = itemAmount.Item;
			itemSlot.Amount = itemAmount.amount;
			itemSlot.transform.parent.gameObject.SetActive(true);
		}
		return slotIndex;
	}
}
