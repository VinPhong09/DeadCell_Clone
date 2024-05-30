using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSaveManager : MonoBehaviour
{
	[SerializeField] ItemDatabase itemDatabase;

	private const string InventoryFileName = "Inventory";
	private const string EquipmentFileName = "Equipment";
	private const string EnchanceFileName = "Enchance";
	private const string LevelFileName = "Level";
	private const string Map_1 = "Map1";
	private const string Map_2 = "Map2";
	private const string Map_3 = "Map3";
	private const string Map_4 = "Map4";
	private const string Map_5 = "Map5";
	private const string Map_6 = "Map6";
	private const string Map_7 = "Map7";

	public static bool canLoad;
	public static bool isClicked;

    private void Update()
    {
        Map saveData = ItemSaveIO.LoadMap(Map_1);
        if (saveData != null)
        {
            canLoad = true;
        }
        else
        {
            canLoad = false;
        }

    }
	public void LoadChar(Character c)
	{
        LoadLevel(c);
        LoadEquipment(c);
        LoadInventory(c);
		LoadEnchance(c);
        StartCoroutine(stopLoad());
    }
	public static void startResume()
	{
		isClicked = true;
	}
	static IEnumerator stopLoad()
	{
		yield return new WaitForSeconds(1.5f);
		isClicked = false;
	}
    public void LoadInventory(Character character)
	{
		Debug.Log("1");
		ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(InventoryFileName+ character.curMap.ToString());
		
		if (savedSlots == null) return;
		character.Inventory.Clear();

		for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
		{
			ItemSlot itemSlot = character.Inventory.ItemSlots[i];
			ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

			if (savedSlot == null)
			{
				itemSlot.Item = null;	
				itemSlot.Amount = 0;
			}
			else
			{
				itemSlot.Item = itemDatabase.GetItemCopy(savedSlot.ItemID);
				itemSlot.Amount = savedSlot.Amount;
			}
		}
	}
    
    public void LoadLevel(Character character)
    {
		Debug.Log("2");
		//Player saveSlot = ItemSaveIO.LoadPlayer(LevelFileName+playerStatus.mapLevel.ToString());
        Map saveData = ItemSaveIO.LoadMap(character.curMap.ToString());
        if (saveData == null)
        {
			return;
        }
		character.HP.BaseValue = saveData.HP;
        character.MP.BaseValue = saveData.MP;
        character.DA.BaseValue = saveData.DA;
        character.DEF.BaseValue = saveData.DEF;
        character.ArP.BaseValue = saveData.ArP;
        character.LUK.BaseValue = saveData.LUK;
        character.numGold = saveData.numGold;
        character.GetComponent<PlayerStatus>().curAge = saveData.curAge;
        character.GetComponent<PlayerStatus>().maxAge = saveData.maxAge;
    }
	public void LoadEquipment(Character character)
	{
		Debug.Log("3");
		ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EquipmentFileName+ character.curMap.ToString());
		
		if (savedSlots == null) return;

		foreach (ItemSlotSaveData savedSlot in savedSlots.SavedSlots)
		{
			if (savedSlot == null)
			{
				continue;
			}
			
			Item item = itemDatabase.GetItemCopy(savedSlot.ItemID);
			character.Inventory.AddItem(item);
			character.Equip((EquippableItem)item);
		}
	}

	public void LoadEnchance(Character character)
    {
		Debug.Log("4");
		ItemContainerSaveData savedSlots = ItemSaveIO.LoadItems(EnchanceFileName+ character.curMap.ToString());

        if (savedSlots == null) return;

		for (int i = 0; i < savedSlots.SavedSlots.Length; i++)
		{
			EquipmentSlot itemSlot = character.EquipmentPanel.EquipmentSlots[i];
			ItemSlotSaveData savedSlot = savedSlots.SavedSlots[i];

			if (savedSlot == null)
			{
				itemSlot.Item = null;
				itemSlot.curEnchanceLv = 0; 
			}
			else
			{
				itemSlot.curEnchanceLv = savedSlot.Amount;
				character.EquipmentPanel.GetStatAtCurLevel((EquippableItem)itemSlot.Item);
				character.UpdateStatValues();
			}
		}
	}
	public static void LoadMap(MapProfile mapProfile)
    {
		Map saveData = ItemSaveIO.LoadMap(mapProfile.mapLevel.ToString());
		if (saveData == null)
        {
			mapProfile.isLocked = true;
        }else
        {
			mapProfile.isLocked = false;
		}

		mapProfile.HP_value = saveData.HP;
		mapProfile.MP_value = saveData.MP;
		mapProfile.DA_value = saveData.DA;
		mapProfile.DEF_value = saveData.DEF;
		mapProfile.ArP_value = saveData.ArP;
		mapProfile.LUK_value = saveData.LUK;
		mapProfile.amountGold_value = saveData.numGold;
		mapProfile.curAge_value = saveData.curAge;
		mapProfile.maxAge_value = saveData.maxAge;
	}
	public void SaveInventory(Character character)
	{
		Debug.Log("12");
		SaveItems(character.Inventory.ItemSlots, InventoryFileName+ character.curMap.ToString());
	}

	public void SaveEquipment(Character character)
	{
		Debug.Log("12");
		SaveItems(character.EquipmentPanel.EquipmentSlots, EquipmentFileName+ character.curMap.ToString());
	}
	public void SaveEnchance(Character character)
    {
		Debug.Log("13");
		SaveEnchance(character.EquipmentPanel.EquipmentSlots, EnchanceFileName+ character.curMap.ToString());
    }
	public void SaveLevel(PlayerStatus playerStatus)
	{
		SaveLevel(playerStatus, LevelFileName+playerStatus.mapLevel.ToString());
	}
	public void SaveMap(Character character)
	{
		Debug.Log("Map");
		canLoad = true;
		SaveMap(character, character.curMap.ToString());
	}
	private void SaveItems(IList<ItemSlot> itemSlots, string fileName)
	{
		var saveData = new ItemContainerSaveData(itemSlots.Count);

		for (int i = 0; i < saveData.SavedSlots.Length; i++)
		{
			ItemSlot itemSlot = itemSlots[i];

			if (itemSlot.Item == null)
			{
				saveData.SavedSlots[i] = null;
			}
			else
			{
				saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.Item.ID, itemSlot.Amount);
			}
		}

		ItemSaveIO.SaveItems(saveData, fileName);
	}
	private void SaveEnchance(IList<EquipmentSlot> itemSlots, string fileName)
    {
		var saveData = new ItemContainerSaveData(itemSlots.Count);
        for (int i = 0; i < saveData.SavedSlots.Length; i++)
        {
			EquipmentSlot itemSlot = itemSlots[i];
			saveData.SavedSlots[i] = new ItemSlotSaveData(itemSlot.name, itemSlot.curEnchanceLv);
        }
		ItemSaveIO.SaveItems(saveData, fileName);
	}
	private void SaveLevel(PlayerStatus playerStatus,string fileName)
    {
		Player savePlayer = new(playerStatus.HP, playerStatus.MP, playerStatus.curAge, playerStatus.Defense);
		ItemSaveIO.SavePlayer(savePlayer, fileName);
    }
	private void SaveMap(Character c, string fileName)
    {
		Map saveMap = new(c.HP.Value,c.MP.Value,c.DA.Value, c.DEF.Value, c.ArP.Value, c.LUK.Value,c.numGold,c.playerStatus.curAge,c.playerStatus.maxAge);
		ItemSaveIO.SaveMap(saveMap,fileName);
    }
}
