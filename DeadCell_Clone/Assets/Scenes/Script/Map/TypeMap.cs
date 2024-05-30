using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeMap : MonoBehaviour
{
    public MapLevel mapLevel;
    public ItemSaveManager itemSaveManager;
    [SerializeField] Character c;
    private void Start()
    {
        c = FindObjectOfType<Character>();
        itemSaveManager = FindObjectOfType<ItemSaveManager>();
    }
    private void Awake()
    {
        StartCoroutine(AutoSave());
    }
    IEnumerator AutoSave()
    {
        yield return new WaitForSeconds(2f);
        itemSaveManager.SaveMap(c);
        itemSaveManager.SaveInventory(c);
        itemSaveManager.SaveEquipment(c);
        itemSaveManager.SaveEnchance(c);
        itemSaveManager.SaveLevel(c.GetComponent<PlayerStatus>());
    }
}
