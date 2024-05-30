using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName ="Items/BaseItems")]
public class Item : ScriptableObject
{
	[SerializeField] string id;
	public string ID { get { return id; } }
	public string ItemName;
    [Range(1,999)]
    public int maxStack = 1;
	public Sprite Icon;

    protected static readonly StringBuilder sb = new StringBuilder();
    private void OnValidate()
    {
 /*       string path = AssetDatabase.GetAssetPath(this);
        id = AssetDatabase.AssetPathToGUID(path);*/
    }
    public virtual Item GetCopy()
    {
        return this;
    }
    public virtual void Destroy()
    {

    }
    public virtual string GetItemType()
    {
        return "";
    }
    public virtual string GetStat()
    {
        return "";
    }
}


