using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInput : MonoBehaviour
{
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject Equipment;
    [SerializeField] GameObject bookUI;
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject craftWindownGameObject;
    [SerializeField] GameObject enchanceWindownGameObject;
    [SerializeField] GameObject settingPanel;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject chestInvetory;
    [SerializeField] KeyCode[] openBook;
    [SerializeField] KeyCode[] openInven;
    [SerializeField] KeyCode[] openCraft;
    [SerializeField] KeyCode[] openSetting;
    [SerializeField] KeyCode[] openEnchance;

    [SerializeField] bool showAndHideMouse = true;

    void Update()
    {

        OpenBook();
        CraftPanel();
        EnchancePanel();
        
        if (inventory.activeSelf||craftWindownGameObject.activeSelf||enchanceWindownGameObject.activeSelf||Equipment.activeSelf)
        {
            bookUI.SetActive(true);
            ClearScene();
        }
        else
        {
            bookUI.SetActive(false);
            OpenSetting();
        }
        if (!bookUI.activeSelf)
        {
            Time.timeScale = 1;
            Debug.Log('1');
            Panel.SetActive(false);
        }
        else
        {
            Time.timeScale = 0;
            Debug.Log(0);
            Panel.SetActive(true);
        }
        if (settingPanel.activeSelf || chestInvetory.activeSelf)
        {
            Debug.Log(0);
            Time.timeScale = 0;
        }
        chestInvetory = FindObjectOfType<ChestInventory>().itemsParent.gameObject;

    }
    public void ClearScene()
    {
        for (int i = 0; i < openSetting.Length; i++)
        {
            if (Input.GetKeyDown(openSetting[i]))
            {
                bookUI.SetActive(false);
                inventory.SetActive(false);
                Equipment.SetActive(false);
                enchanceWindownGameObject.SetActive(false);
                craftWindownGameObject.SetActive(false);
                break;
            }
        }
        
        
    }
    private void OpenSetting()
    {
        for (int i = 0; i < openSetting.Length; i++)
        {
            if (Input.GetKeyDown(openSetting[i]))
            {
                
                gameUI.SetActive(!gameUI.activeSelf);
                
                settingPanel.SetActive(!gameUI.activeSelf);

                
                break;
            }
        }
    }
    public void OpenBook()
    {
        for (int i = 0; i < openBook.Length; i++)
        {
            if (Input.GetKeyDown(openBook[i]))
            {
                if (!enchanceWindownGameObject.activeSelf && !craftWindownGameObject.activeSelf)
                {
                    
                    Equipment.SetActive(!Equipment.activeSelf);
                    inventory.SetActive(Equipment.activeSelf);
                }
                else
                {
                    
                    enchanceWindownGameObject.SetActive(false);
                    craftWindownGameObject.SetActive(false);
                    Equipment.SetActive(true);
                    inventory.SetActive(Equipment.activeSelf);
                }
                
                
                break;
            }
        }
    }

    

    public void ShowMouseCursor()
    {
        if (showAndHideMouse)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void HideMouseCursor()
    {
        if (showAndHideMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    
    public void CraftPanel()
    {
        for (int i = 0; i < openCraft.Length; i++)
        {
            if (Input.GetKeyDown(openCraft[i]))
            {
                if (bookUI.activeSelf)
                {
                    if (Equipment.activeSelf || inventory.activeSelf || enchanceWindownGameObject.activeSelf)
                    {
                        Equipment.SetActive(false);
                        inventory.SetActive(false);
                        enchanceWindownGameObject.SetActive(false);
                    }
                    craftWindownGameObject.SetActive(!craftWindownGameObject.activeSelf);
                }
                else
                {
                    bookUI.SetActive(true);
                    craftWindownGameObject.SetActive(true);
                }
                
                break;
            }
        }
    }
    public void EnchancePanel()
    {
        for (int i = 0; i < openEnchance.Length; i++)
        {
            if (Input.GetKeyDown(openEnchance[i]))
            {
                if (bookUI.activeSelf)
                {
                    if (Equipment.activeSelf || craftWindownGameObject.activeSelf)
                    {
                        Equipment.SetActive(false);
                        craftWindownGameObject.SetActive(false);
                    }
                    enchanceWindownGameObject.SetActive(!enchanceWindownGameObject.activeSelf);
                    inventory.SetActive(enchanceWindownGameObject.activeSelf);

                }
                else
                {
                    bookUI.SetActive(true);
                    enchanceWindownGameObject.SetActive(true);
                    inventory.SetActive(enchanceWindownGameObject.activeSelf);
                }
                
                break;
            }
        }
    }
}
