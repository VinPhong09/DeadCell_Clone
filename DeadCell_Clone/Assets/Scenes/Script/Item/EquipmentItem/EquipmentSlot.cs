using QuanVo.CharacterStat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSlot : ItemSlot
{
    public EquipmentType EquipmentType;
    [SerializeField]public EquippableItem equipItem;
    [SerializeField] Character c;
    [SerializeField] StatPanel statPanel;
    public Text currentLevel;
    public int curEnchanceLv;
    public int maxEnchanceLv;
    protected override void OnValidate()
    {
        base.OnValidate();
        gameObject.name = EquipmentType.ToString();
        currentLevel.enabled = true;
        c = FindObjectOfType<Character>();
        statPanel = FindObjectOfType<StatPanel>();
    }
    private void Update()
    {
        currentLevel.text = curEnchanceLv.ToString();
        equipItem = this.Item as EquippableItem;
        statPanel.UpdateStatValues();
    }
    public override bool CanReceiveItem(Item item)
    {
        if (item == null)
        {
            return true;
        }
        EquippableItem equippableItem = item as EquippableItem;
        return equippableItem != null && equippableItem.equipmentType == EquipmentType;
    }
    
}


