using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum StoneType
{
    EnchanceStone

}

[CreateAssetMenu(menuName = "Items/EnchanceStone")]
public class EnchanceStone : Item
{
    public StoneType stoneType;
    public EnchancePanel enchancePanel;
    [SerializeField] public float rateTo1;
    [SerializeField] public float rateTo2;
    [SerializeField] public float rateTo3;
    [SerializeField] public float rateTo4;
    [SerializeField] public float rateTo5;
    [SerializeField] public float rateTo6;
    [SerializeField] public float rateTo7;
    [SerializeField] public float rateTo8;
    [SerializeField] public float rateTo9;
    [SerializeField] public float rateTo10;

    public float rateUp;
    public override string GetItemType()
    {
        return stoneType.ToString();
    }
    public override Item GetCopy()
    {
        return Instantiate(this);
    }
    
    public void AddStone(Character c)
    {
        //getRateToEnchance();
        c.totalRateUp += rateUp;
    }
    public void RemoveStone(Character c)
    {
        //getRateToEnchance();
        c.totalRateUp -= rateUp;
    }
    public void getRateToEnchance()
    {
        switch (enchancePanel.equipSlot.curEnchanceLv)
        {
            case 0:
                rateUp = rateTo1;
                break;
            case 1:
                rateUp = rateTo2;
                break;
            case 2:
                rateUp = rateTo3;
                break;
            case 3:
                rateUp = rateTo4;
                break;
            case 4:
                rateUp = rateTo5;
                break;
            case 5:
                rateUp = rateTo6;
                break;
            case 6:
                rateUp = rateTo7;
                break;
            case 7:
                rateUp = rateTo8;
                break;
            case 8:
                rateUp = rateTo9;
                break;
            case 9:
                rateUp = rateTo10;
                break;
            default:
                break;
        }
    }
}
