using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : BaseMono
{
    protected static InventoryManager instance;
    public static InventoryManager Instance => instance;
    [SerializeField] protected int maxSlot = 4;
    [SerializeField] protected List<ItemInventory> items;
     public List<ItemInventory> Items => items;
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    
    public virtual bool AddItem(ItemInventory itemInventory)
    {
        ItemProfileSO itemProfileSO = itemInventory.itemProfileSO;
        ItemType itemType = itemProfileSO.itemType;
        string itemName = itemProfileSO.itemName;
        int itemCount = itemInventory.itemCount;
        if (itemType == ItemType.Equiment) return this.AddItemEquiment(itemInventory);
        return  this.AddItem(itemName, itemCount);
    }
    public virtual bool AddItemEquiment(ItemInventory itemInventory) {
        if (IsInvFullSlot()) return false;
        itemInventory.itemID = ItemInventory.RandomID();
        ItemInventory item = ItemInventory.Clone(itemInventory);

        this.items.Add(item);
;        return true;
    }
    public virtual bool AddItem(string itemName, int itemCount)
    {
        ItemProfileSO itemProfileSO = GetItemProfile(itemName);
        int addMore;
        int maxStack;
        int newCount;
        ItemInventory itemInventory;
        while (true) {
             itemInventory = GetItemInvNotFullStack(itemName);
            if (itemInventory == null)
            {
                if (IsInvFullSlot()) return false;
                itemInventory = CreatEmptyItem(itemProfileSO);
                this.items.Add(itemInventory);
            }
             maxStack = itemInventory.maxStack;
             newCount =  itemInventory.itemCount + itemCount;
            if(newCount > maxStack)
            {
                 addMore = maxStack - itemInventory.itemCount;
              
            }
            else
            {
                 addMore = itemCount;
            }
            itemCount -= addMore;
            itemInventory.itemCount += addMore;
            if (itemCount <= 0) break;
        }
        return true;
    }
    protected virtual ItemInventory GetItemInvNotFullStack(string itemName)
    {
        foreach(ItemInventory itemInventory in items)
        {
            
            if(itemInventory.itemProfileSO.itemName == itemName && itemInventory.itemCount < itemInventory.maxStack)
            {
                return itemInventory;
            }
        }
        return null;
    }
    protected virtual bool IsInvFullSlot()
    {
        return items.Count >= maxSlot;
    }
    protected virtual ItemInventory CreatEmptyItem(ItemProfileSO itemProfileSO)
    {
        ItemInventory itemInventory = new ItemInventory();

        itemInventory.itemProfileSO = itemProfileSO;
        itemInventory.itemID = RandomStringGenerator.Generate(27);
       
        return itemInventory;
    }
    protected virtual ItemProfileSO GetItemProfile(string itemName)
    {
        var profiles = Resources.LoadAll("ItemInvProfileSO", typeof(ItemProfileSO));
        foreach(ItemProfileSO profile in profiles) {
            if (profile.itemName != itemName) continue;
            return profile;
        }
        return null;
    }
    public virtual bool CheckItem(string itemName, int itemCount)
    {
        int count = 0;
        foreach(ItemInventory itemInventory in this.items)
        {
            if (itemInventory.itemProfileSO.itemName != itemName) continue;
            count += itemInventory.itemCount;
        }
        return count >= itemCount;
    }
    public virtual void DeductItem(string itemName, int itemCount)
    {
        ItemInventory itemInventory;
        int deduct;
        for (int i = this.items.Count -1;i>= 0; i--)
        {
            itemInventory = items[i];
           
            if (itemInventory.itemProfileSO.itemName != itemName) continue;
           
            if(itemCount > itemInventory.itemCount)
            {
                deduct = itemInventory.itemCount;  
            }
            else
            {
                deduct = itemCount;
            }
            itemInventory.itemCount -= deduct;
        }
        this.ClearItemSlot();
    }
    protected virtual void ClearItemSlot()
    {
        ItemInventory itemInventory;
        for(int i = 0;i< items.Count; i++)
        {
            itemInventory = items[i];
            if (itemInventory.itemCount != 0) continue;
            this.items.Remove(itemInventory);
        }
    }
}
