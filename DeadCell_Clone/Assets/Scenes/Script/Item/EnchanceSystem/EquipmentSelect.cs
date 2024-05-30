using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EquipmentSelect : MonoBehaviour
{
    public Character c;
    public EquipmentType type;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        c = FindObjectOfType<Character>();
        for (int i = 0; i < c.EquipmentPanel.EquipmentSlots.Length; i++)
        {
            if (c.EquipmentPanel.EquipmentSlots[i].EquipmentType == type)
            {
                image.sprite = c.EquipmentPanel.EquipmentSlots[i].equipItem.Icon;
                Debug.Log("1");
            }
            
        }
    }
    private void OnValidate()
    {
        
    }
}
