using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropManager : MonoBehaviour
{
    //Singleton
    public BossDrop bossDrop;
    public Transform dropPosition;
    public float randNum;
    public int amountDrop;


    private void Start()
    {
        //Drop(bossDrop.dropList,bossDrop.amountDropItems);
        //dropPosition = this.gameObject.transform;
    }

    public void Drop(List<DropRate> dropRates, int amountDrop)
    {
        int count = amountDrop;
        for (int i = 0; i < dropRates.Count; i++)
        {
            randNum = Random.value;
            amountDrop = (int)Random.Range(dropRates[i].minDrop, dropRates[i].maxDrop);

            if (dropRates[i].dropRate >= randNum)
            {
                if (count >= 1)
                {
                    GameObject dropItem = Instantiate(dropRates[i].item, new Vector3(dropPosition.position.x + Random.Range(-2, 2), dropPosition.position.y), Quaternion.identity);
                    dropItem.GetComponent<ItemPickup>().itemAmount = amountDrop;
                    count--;
                }
            }
        }
    }
}