using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QuanVo.CharacterStat;
using UnityEngine.UI;
using Unity.VisualScripting;

public class Character : MonoBehaviour
{
    public static Character Instance;
    public float totalRateUp = 0;
    public float dameTotal = 0;
    public bool OutStat = false;
    public int numGold = 0;

    public float randomNum;
    public MapLevel curMap;

    [Header("Stats")]
    public CharacterStat HP;
    public CharacterStat MP;
    public CharacterStat DA;
    public CharacterStat DEF;
    public CharacterStat ArP;
    public CharacterStat LUK;

    [Header("Public")]
    [SerializeField] public Inventory Inventory;
    [SerializeField] public EquipmentPanel EquipmentPanel;
    [SerializeField] public EnchancePanel EnchancePanel;
    [SerializeField] GameObject equipPanel;
    [SerializeField] public PlayerStatus playerStatus;
    [SerializeField] public UsableItemPanel UsablePanel;

    [Header("Serialize Field")]
    [SerializeField] CraftingWindow craftingWindow;
    [SerializeField] public StatPanel statPanel;
    [SerializeField] public ItemTooltip itemTooltip;
    [SerializeField] public Image draggableItem;
    [SerializeField] DropItemArea dropItemArea;
    [SerializeField] public Transform chestInventory;
    [SerializeField] QuestionDialog reallyDropItemDialog;
    [SerializeField] ItemSaveManager itemSaveManager;

    private BaseItemSlot draggedSlot;
    public GameObject game;
    public GameObject spawn; public GameObject ui;

    private void OnValidate()
    {
        if (itemTooltip == null)
        {
            itemTooltip = FindObjectOfType<ItemTooltip>();
        }
        playerStatus = FindObjectOfType<PlayerStatus>();

    }
    private void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    private void Awake()
    {
        statPanel.SetStats(HP, MP, DA, DEF, ArP, LUK);
        statPanel.UpdateStatValues();
        curMap = FindObjectOfType<TypeMap>().mapLevel;
        
        // Setup Events:
        // Right Click
        Inventory.OnRightClickEvent += InventoryRightClick;
        EquipmentPanel.OnRightClickEvent += EquipmentPanelRightClick;
        EnchancePanel.OnRightClickEvent += EnchancePanelRightClickEvent;
        UsablePanel.OnRightClickEvent += UsablePanelRightClickEvent;
        // Pointer Enter
        Inventory.OnPointerEnterEvent += ShowTooltip;
        EquipmentPanel.OnPointerEnterEvent += ShowTooltip;
        //craftingWindow.OnPointerEnterEvent += ShowTooltip;
        // Pointer Exit
        Inventory.OnPointerExitEvent += HideTooltip;
        EquipmentPanel.OnPointerExitEvent += HideTooltip;
        //craftingWindow.OnPointerExitEvent += HideTooltip;
        // Begin Drag
        Inventory.OnBeginDragEvent += BeginDrag;
        EquipmentPanel.OnBeginDragEvent += BeginDrag;
        EnchancePanel.OnBeginDragEvent += BeginDrag;
        UsablePanel.OnBeginDragEvent += BeginDrag;
        // End Drag
        Inventory.OnEndDragEvent += EndDrag;
        EquipmentPanel.OnEndDragEvent += EndDrag;
        EnchancePanel.OnEndDragEvent += EndDrag;
        UsablePanel.OnEndDragEvent += EndDrag;
        // Drag
        Inventory.OnDragEvent += Drag;
        EquipmentPanel.OnDragEvent += Drag;
        EnchancePanel.OnDragEvent += Drag;
        UsablePanel.OnDragEvent += Drag;
        // Drop
        Inventory.OnDropEvent += Drop;
        EquipmentPanel.OnDropEvent += Drop;
        EnchancePanel.OnDropEvent += Drop;
        dropItemArea.OnDropEvent += DropItemOutsideUI;
        UsablePanel.OnDropEvent += Drop;

        /*itemSaveManager.LoadEquipment(this);
		itemSaveManager.LoadInventory(this);*/
    }
    public float GetDame()
    {
        if (randomNum > (LUK.Value / 100))
        {
            //Normal dame
            return dameTotal = (DA.Value * 20);
        }
        else
        {
            //Crit dame
            return dameTotal = (DA.Value * 20 ) * 2;
        }
    }
    private void Update()
    {
        if (!ui.activeSelf)
        {
            StartCoroutine(openUI());
        }
        UpdateStatValues();

        spawn = FindObjectOfType<Spawn>().gameObject;
        game = spawn.GetComponent<Spawn>().panelTele.gameObject;
        
        curMap = FindObjectOfType<TypeMap>().mapLevel;
        itemSaveManager = FindObjectOfType<ItemSaveManager>();
        chestInventory = FindObjectOfType<ChestInventory>().itemsParent.transform;
        Debug.Log(ItemSaveManager.isClicked);
        if (ItemSaveManager.isClicked)
        {
            itemSaveManager.LoadChar(this);
            ItemSaveManager.isClicked = false;
            playerStatus.HP = playerStatus.GetHP(); 
            playerStatus.MP = playerStatus.GetMP();
            playerStatus.Defense = playerStatus.GetDef();
        }
    }
    private void EnchancePanelRightClickEvent(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EnchanceStone)
        {
            RemoveStone((EnchanceStone)itemSlot.Item);
        }
    }
    private void UsablePanelRightClickEvent(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is UsableItem)
        {
            RemovePotion((UsableItem)itemSlot.Item);
        }
    }
    public void UsePotion(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is UsableItem)
        {
            UsableItem usableItem = (UsableItem)itemSlot.Item;
            usableItem.Use(playerStatus);

            if (usableItem.IsConsumable)
            {
                itemSlot.Amount--;
                usableItem.Destroy();
            }
        }

    }

    private void InventoryRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem && equipPanel.activeSelf)
        {
            Equip((EquippableItem)itemSlot.Item);
        }
        else if (itemSlot.Item is UsableItem)
        {

            AddPotion((UsableItem)itemSlot.Item);
        }
        else if (itemSlot.Item is EnchanceStone && EnchancePanel.gameObject.activeSelf)
        {
            AddStone((EnchanceStone)itemSlot.Item);
        }
    }

    private void EquipmentPanelRightClick(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item is EquippableItem)
        {
            Unequip((EquippableItem)itemSlot.Item);
        }
    }

    private void ShowTooltip(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            itemTooltip.ShowTooltip(itemSlot.Item);
        }
    }

    private void HideTooltip(BaseItemSlot itemSlot)
    {
        if (itemTooltip.gameObject.activeSelf)
        {
            itemTooltip.HideTooltip();
        }
    }

    private void BeginDrag(BaseItemSlot itemSlot)
    {
        if (itemSlot.Item != null)
        {
            draggedSlot = itemSlot;

            draggableItem.GetComponentInChildren<Image>().sprite = itemSlot.Item.Icon;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.gameObject.SetActive(true);
        }
    }

    private void Drag(BaseItemSlot itemSlot)
    {
        draggableItem.transform.position = Input.mousePosition;
    }

    private void EndDrag(BaseItemSlot itemSlot)
    {
        draggedSlot = null;
        draggableItem.gameObject.SetActive(false);
    }

    private void Drop(BaseItemSlot dropItemSlot)
    {
        if (draggedSlot == null) return;

        if (dropItemSlot.CanAddStack(draggedSlot.Item))
        {
            AddStacks(dropItemSlot);
        }
        else if (dropItemSlot.CanReceiveItem(draggedSlot.Item) && draggedSlot.CanReceiveItem(dropItemSlot.Item))
        {
            SwapItems(dropItemSlot);
        }
    }

    private void AddStacks(BaseItemSlot dropItemSlot)
    {
        int numAddableStacks = dropItemSlot.Item.maxStack - dropItemSlot.Amount;
        int stacksToAdd = Mathf.Min(numAddableStacks, draggedSlot.Amount);

        dropItemSlot.Amount += stacksToAdd;
        draggedSlot.Amount -= stacksToAdd;
    }

    private void SwapItems(BaseItemSlot dropItemSlot)
    {
        EquippableItem dragEquipItem = draggedSlot.Item as EquippableItem;
        EquippableItem dropEquipItem = dropItemSlot.Item as EquippableItem;

        if (dropItemSlot is EquipmentSlot)
        {
            if (dragEquipItem != null) dragEquipItem.Equip(this);
            if (dropEquipItem != null) dropEquipItem.Unequip(this);
        }
        if (draggedSlot is EquipmentSlot)
        {
            if (dragEquipItem != null) dragEquipItem.Unequip(this);
            if (dropEquipItem != null) dropEquipItem.Equip(this);
        }
        statPanel.UpdateStatValues();

        Item draggedItem = draggedSlot.Item;
        int draggedItemAmount = draggedSlot.Amount;

        draggedSlot.Item = dropItemSlot.Item;
        draggedSlot.Amount = dropItemSlot.Amount;

        dropItemSlot.Item = draggedItem;
        dropItemSlot.Amount = draggedItemAmount;
    }

    private void DropItemOutsideUI()
    {
        if (draggedSlot == null) return;

        reallyDropItemDialog.Show();
        BaseItemSlot slot = draggedSlot;
        reallyDropItemDialog.OnYesEvent += () => DestroyItemInSlot(slot);

    }

    private void DestroyItemInSlot(BaseItemSlot itemSlot)
    {
        // If the item is equiped, unequip first
        if (itemSlot is EquipmentSlot)
        {
            EquippableItem equippableItem = (EquippableItem)itemSlot.Item;
            equippableItem.Unequip(this);
        }

        itemSlot.Item.Destroy();
        itemSlot.Item = null;
    }

    public void Equip(EquippableItem item)
    {
        if (Inventory.RemoveItem(item))
        {
            EquippableItem previousItem;
            if (EquipmentPanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    Inventory.AddItem(previousItem);
                    previousItem.Unequip(this);
                    statPanel.UpdateStatValues();
                }
                item.Equip(this);
                EquipmentPanel.GetStatAtCurLevel(item);
                statPanel.UpdateStatValues();
            }
            else
            {
                Inventory.AddItem(item);
            }
        }
    }

    public void Unequip(EquippableItem item)
    {
        if (Inventory.CanAddItem(item) && EquipmentPanel.RemoveItem(item))
        {
            item.Unequip(this);
            EquipmentPanel.GetOutEquip(this);
            statPanel.UpdateStatValues();
            Inventory.AddItem(item);
        }
    }

    public void AddStone(EnchanceStone item)
    {
        if (Inventory.RemoveItem(item))
        {
            EnchanceStone previousItem;
            if (EnchancePanel.AddItem(item, out previousItem))
            {
                if (previousItem != null)
                {
                    Inventory.AddItem(previousItem);
                    previousItem.RemoveStone(this);
                }
                item.AddStone(this);
            }
            else
            {
                Inventory.AddItem(item);
            }
        }
        EnchancePanel.RefreshRate();
    }
    public void AddPotion(UsableItem item)
    {
        if (Inventory.RemoveItem(item))
        {
            UsableItem previousItem;

            if (UsablePanel.AddItem(item, out previousItem))
            {

            }
            else
            {
                Inventory.AddItem(item);
            }
        }
    }
    public void RemovePotion(UsableItem item)
    {
        if (Inventory.CanAddItem(item) && UsablePanel.RemoveItem(item))
        {

            //statPanel.UpdateStatValues();
            Inventory.AddItem(item);

        }
    }
    public void RemoveStone(EnchanceStone enchanceStone)
    {
        if (Inventory.CanAddItem(enchanceStone) && EnchancePanel.RemoveItem(enchanceStone))
        {
            enchanceStone.RemoveStone(this);
            //statPanel.UpdateStatValues();
            Inventory.AddItem(enchanceStone);

        }
        EnchancePanel.RefreshRate();
    }
    public void RemoveAfterEnchance(EnchanceStone enchanceStone)
    {
        if (EnchancePanel.RemoveItem(enchanceStone))
        {
            enchanceStone.RemoveStone(this);
            //Destroy(enchanceStone);

        }
        EnchancePanel.RefreshRate();
    }
    private ItemContainer openItemContainer;

    private void TransferToItemContainer(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if (item != null && openItemContainer.CanAddItem(item))
        {
            Inventory.RemoveItem(item);
            openItemContainer.AddItem(item);
        }
    }

    private void TransferToInventory(BaseItemSlot itemSlot)
    {
        Item item = itemSlot.Item;
        if (item != null && Inventory.CanAddItem(item))
        {
            openItemContainer.RemoveItem(item);
            Inventory.AddItem(item);
        }
    }

    public void OpenItemContainer(ItemContainer itemContainer)
    {
        openItemContainer = itemContainer;

        Inventory.OnRightClickEvent -= InventoryRightClick;
        Inventory.OnRightClickEvent += TransferToItemContainer;

        itemContainer.OnRightClickEvent += TransferToInventory;

        itemContainer.OnPointerEnterEvent += ShowTooltip;
        itemContainer.OnPointerExitEvent += HideTooltip;
        itemContainer.OnBeginDragEvent += BeginDrag;
        itemContainer.OnEndDragEvent += EndDrag;
        itemContainer.OnDragEvent += Drag;
        itemContainer.OnDropEvent += Drop;
    }

    public void CloseItemContainer(ItemContainer itemContainer)
    {
        openItemContainer = null;

        Inventory.OnRightClickEvent += InventoryRightClick;
        Inventory.OnRightClickEvent -= TransferToItemContainer;

        itemContainer.OnRightClickEvent -= TransferToInventory;

        itemContainer.OnPointerEnterEvent -= ShowTooltip;
        itemContainer.OnPointerExitEvent -= HideTooltip;
        itemContainer.OnBeginDragEvent -= BeginDrag;
        itemContainer.OnEndDragEvent -= EndDrag;
        itemContainer.OnDragEvent -= Drag;
        itemContainer.OnDropEvent -= Drop;
    }

    public void UpdateStatValues()
    {
        statPanel.UpdateStatValues();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Loading"))
        {
            
            dropItemArea.gameObject.SetActive(false);
            ui.SetActive(false);
            game.SetActive(true);       

        }
    }
    IEnumerator openUI()
    {
        yield return new WaitForSeconds(1f);
        ui.SetActive(true);
    }
}

