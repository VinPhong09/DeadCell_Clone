using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UsableItemType
{
    HP,
    MP
}
[CreateAssetMenu(menuName = "Items/Usable Item")]
public class UsableItem : Item
{
    public UsableItemType itemType;
    public bool IsConsumable;
    public List<UsableItemEffect> Effects;
    public virtual void Use(PlayerStatus character)
    {
        foreach ( UsableItemEffect effect in Effects)
        {
            effect.ExecuteEffect(this, character);
        }
    }
    public override string GetItemType()
    {
        return IsConsumable ? "Consumable" : "Usable";
    }
    public override string GetStat()
    {
        sb.Length = 0;
        foreach (UsableItemEffect effect in Effects)
        {
            sb.AppendLine(effect.GetStat());
        }
        return sb.ToString();
    }
}
