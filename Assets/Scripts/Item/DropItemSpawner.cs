using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemSpawner : Spawner
{
    private static DropItemSpawner instance;
    public static DropItemSpawner Instance => instance;

    [SerializeField] protected float gameDropRate = 1;

    protected override void Awake()
    {
        base.Awake();
        if (DropItemSpawner.instance != null) Debug.LogError("Only 1 ItemDropSpawner allow to exist");
        DropItemSpawner.instance = this;
    }

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList, Vector3 pos, Quaternion rot)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return dropItems;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            string itemName = itemDropRate.itemSO.itemName;
            Transform itemDrop = this.Spawn(itemName, pos, rot);
            if (itemDrop == null) continue;
          
        }

        return dropItems;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        int itemDropMore;
        foreach (ItemDropRate item in items)
        {
            rate = Random.Range(0, 1f);
            itemRate = item.dropRate / 100000f * this.GameDropRate();
            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }

          

            if (rate <= itemRate)
            {
                //Debug.Log("DROPED");
                droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    protected virtual float GameDropRate()
    {
        float dropRateFromItems = 0f;

        return this.gameDropRate + dropRateFromItems;
    }

    public virtual Transform Drop(ItemInventory itemInventory, Vector3 pos, Quaternion rot)
    {
        string itemName = itemInventory.itemProfileSO.itemName;
        Transform itemDrop = this.Spawn(itemName, pos, rot);
        if (itemDrop == null) return null;
        itemDrop.gameObject.SetActive(true);
        DropItemCtrl itemCtrl = itemDrop.GetComponent<DropItemCtrl>();
        itemCtrl.SetItemInv(itemInventory);
        return itemDrop;
    }
}
