using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class ItemInventory
{
    public string itemID;
    public int maxStack = 7;
    public ItemProfileSO itemProfileSO;
    public int itemCount = 0;
    public int currentLevel;
 public static ItemInventory Clone(ItemInventory itemInventory)
    {
        ItemInventory item = new ItemInventory();
      
        item.itemID = itemInventory.itemID;
        item.maxStack = itemInventory.maxStack;
        item.itemCount = itemInventory.itemCount;
        item.itemProfileSO = itemInventory.itemProfileSO;
        item.currentLevel = itemInventory.currentLevel;
        return item;
    }
    public static string RandomID()
    {
       return RandomStringGenerator.Generate(27);
    }
}
