using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class UsableItemEffect : ScriptableObject
{
    public abstract void ExecuteEffect(UsableItem parentItem, PlayerStatus playerStatus);
    public abstract string GetStat();
}
