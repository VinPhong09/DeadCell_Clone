using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuanVo.CharacterStat;

public enum EquipmentType
{
    Helmet,
    Chest,
    Gloves,
    Boots,
    Trousers,
    LeafWeapon,
    FireWeapon,
    WindWeapon,
    MentalWeapon
}
[CreateAssetMenu(menuName ="Items/EquippableItem")]
public class EquippableItem : Item
{
    public int HP;
    public int MP;
    public int DA;//Dame Attack
    public int DEF;
    public int ArP; //Armor Penetration
    public int AS;//Attack Speed
    [Space]
    public float HPPercentBonus;
    public float MPPercentBonus;
    public float DAPercentBonus;//Dame Attack
    public float DEFPercentBonus;
    public float ArPPercentBonus; //Armor Penetration
    public float ASPercentBonus;//Attack Speed
    [Space]
    public EquipmentType equipmentType;

    public override Item GetCopy()
    {
        return Instantiate(this);
    }
    public override void Destroy()
    {
        Destroy(this);
    }

    public void Equip(Character c)
    {
        if (HP != 0)
            c.HP.AddModifier(new StatModifier(HP, StatModType.Flat, this));
        if (MP != 0)
            c.MP.AddModifier(new StatModifier(MP , StatModType.Flat, this));
        if (DA != 0)
            c.DA.AddModifier(new StatModifier(DA , StatModType.Flat, this));
        if (DEF != 0)
                c.DEF.AddModifier(new StatModifier(DEF , StatModType.Flat, this));
        if (ArP != 0)
            c.ArP.AddModifier(new StatModifier(ArP, StatModType.Flat, this));
        if (AS != 0)
            c.LUK.AddModifier(new StatModifier(AS , StatModType.Flat, this));

        if (HPPercentBonus != 0)
            c.HP.AddModifier(new StatModifier(HPPercentBonus, StatModType.PercentMult, this));
        if (MPPercentBonus != 0)
            c.MP.AddModifier(new StatModifier(MPPercentBonus, StatModType.PercentMult, this));
        if (DAPercentBonus != 0)
            c.DA.AddModifier(new StatModifier(DAPercentBonus, StatModType.PercentMult, this));
        if (DEFPercentBonus != 0)
            c.DEF.AddModifier(new StatModifier(DEFPercentBonus , StatModType.PercentMult, this));
        if (ArPPercentBonus != 0)
            c.ArP.AddModifier(new StatModifier(ArPPercentBonus, StatModType.PercentMult, this));
        if (ASPercentBonus != 0)
            c.LUK.AddModifier(new StatModifier(ASPercentBonus, StatModType.PercentMult, this));
    }

    public void Unequip(Character c)
    {
        c.HP.RemoveAllModifiersFromSource(this);
        c.MP.RemoveAllModifiersFromSource(this);
        c.DA.RemoveAllModifiersFromSource(this);
        c.DEF.RemoveAllModifiersFromSource(this);
        c.ArP.RemoveAllModifiersFromSource(this);
        c.LUK.RemoveAllModifiersFromSource(this);
    }
    public override string GetItemType()
    {
        return equipmentType.ToString();
    }
    public override string GetStat()
    {
        sb.Length = 0;

        AddStatText(HP, " HP");
        AddStatText(MP, " MP");
        AddStatText(DA, " DA");
        AddStatText(DEF, " DEF");
        AddStatText(ArP, " ArP");
        AddStatText(AS, " Luk");

        AddStatText(HPPercentBonus * 100, "% HP");
        AddStatText(MPPercentBonus * 100, "% MP");
        AddStatText(DAPercentBonus * 100, "% DA");
        AddStatText(DEFPercentBonus * 100, "% DEF");
        AddStatText(ArPPercentBonus * 100, "% ArP");
        AddStatText(ASPercentBonus * 100, "% AS");
        return sb.ToString();
    }
    private void AddStatText(float statBonus, string statName)
    {
        if (statBonus != 0)
        {
            if (sb.Length > 0)
                sb.AppendLine();

            if (statBonus > 0)
                sb.Append("+");

            sb.Append(statBonus);
            sb.Append(statName);
        }
    }

}

