using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : ItemContainer
{
    [SerializeField] Item item;
    [SerializeField] public int itemAmount =1 ;
    [SerializeField] Character c;
    [SerializeField] SpriteRenderer image ;
    private void OnValidate()
    {
        image = GetComponent<SpriteRenderer>();
        image.sprite = item.Icon;
        
    }
    private void Update()
    {
        c = FindObjectOfType<Character>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PickUp();
        }
    }
    public void PickUp()
    {
        if (c.Inventory.CanAddItem(item))
        {
            if (item is EquippableItem)
            {
                c.Inventory.AddItem(item.GetCopy(), 1);
                Destroy(this.gameObject);
            }
            else if (item is GoldItem)
            {
                c.numGold += itemAmount;
                Destroy(this.gameObject);
            }
            else
            {
                c.Inventory.AddItem(item.GetCopy(), itemAmount);
                Destroy(this.gameObject);
            }
        }
        
    }
}
