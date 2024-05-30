using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="BossDrop")]
public class BossDrop : ScriptableObject
{
    public int amountDropItems;
    public List<DropRate> dropList;
}
