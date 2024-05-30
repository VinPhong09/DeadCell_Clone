using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabControl : MonoBehaviour
{
    public Image tabImage;
    public void SelectTab(Image tab)
    {
        tabImage.sprite = tab.sprite;
        
    }
}
