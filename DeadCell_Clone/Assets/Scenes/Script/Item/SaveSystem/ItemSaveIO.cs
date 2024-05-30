using UnityEngine;

public static class ItemSaveIO
{
	private static readonly string baseSavePath;

	static ItemSaveIO()
	{
		baseSavePath = Application.persistentDataPath;
	}

	public static void SaveItems(ItemContainerSaveData items, string path)
	{
		FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", items);
	}
	
	public static ItemContainerSaveData LoadItems(string path)
	{
		string filePath = baseSavePath + "/" + path + ".dat";

		if (System.IO.File.Exists(filePath))
		{
			return FileReadWrite.ReadFromBinaryFile<ItemContainerSaveData>(filePath);
		}
		return null;
	}
	public static void SavePlayer(Player player, string path)
    {
		FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", player);
	}

	
	public static Player LoadPlayer(string path)
	{
		string filePath = baseSavePath + "/" + path + ".dat";

		if (System.IO.File.Exists(filePath))
		{
			return FileReadWrite.ReadFromBinaryFile<Player>(filePath);
		}
		return null;
	}
	public static void SaveMap(Map map, string path)
	{
		FileReadWrite.WriteToBinaryFile(baseSavePath + "/" + path + ".dat", map);
	}


	public static Map LoadMap(string path)
	{
		string filePath = baseSavePath + "/" + path + ".dat";

		if (System.IO.File.Exists(filePath))
		{
			return FileReadWrite.ReadFromBinaryFile<Map>(filePath);
		}
		return null;
	}
}