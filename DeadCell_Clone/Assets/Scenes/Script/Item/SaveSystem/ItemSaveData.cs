using System;

[Serializable]
public class ItemSlotSaveData
{
	public string ItemID;
	public int Amount;


	public ItemSlotSaveData(string id, int amount)
	{
		ItemID = id;
		Amount = amount;
	}

}
[Serializable]
public class Player
{
    public int HP;
	public int MP;
	public int curAge;
	public int def;
    public Player(int HP, int MP, int curAge, int def)
    {
		this.HP = HP;
        this.MP = MP;
		this.curAge = curAge;
		this.def = def;
    }
}
[Serializable]
public class Map
{
	
	public float HP;
	public float MP;
	public float DA;
	public float DEF;
	public float ArP;
	public float LUK;
	public int numGold;
	public int curAge;
	public int maxAge;

    public Map(float hP, float mP, float dA, float dEF, float arP, float lUK, int numGold, int curAge, int maxAge)
    {
        
        HP = hP;
        MP = mP;
        DA = dA;
        DEF = dEF;
        ArP = arP;
        LUK = lUK;
        this.numGold = numGold;
        this.curAge = curAge;
        this.maxAge = maxAge;
    }
}

[Serializable]
public class ItemContainerSaveData
{
	public ItemSlotSaveData[] SavedSlots;
	public ItemContainerSaveData(int numItems)
	{
		SavedSlots = new ItemSlotSaveData[numItems];
	}

}
