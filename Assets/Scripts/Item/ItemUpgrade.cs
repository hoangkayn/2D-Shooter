using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUpgrade : BaseMono
{
    protected override void Start()
    {
        base.Start();
      //  this.Test();
    }
    protected virtual void Test()
    {
        this.UpgradeItem(0);
    }
    public virtual bool UpgradeItem(int itemIndex)
    {
        if (itemIndex >= InventoryManager.Instance.Items.Count) return false;
        ItemInventory itemInventory = InventoryManager.Instance.Items[itemIndex];
        if (!(ItemUpgradeable(itemInventory))) return false;
        if (ItemMaxLevel(itemInventory)) return false;
        if (!(HaveEnoughIngredients(itemInventory))) return false;
        this.DeductIngredients(itemInventory);
        itemInventory.currentLevel++;
        return true;
    }
    protected virtual bool ItemUpgradeable(ItemInventory itemInventory)
    {
        return itemInventory.itemProfileSO.upgradeLevels.Count > 0;
    }
    protected virtual bool ItemMaxLevel(ItemInventory itemInventory)
    {
        int currentLevel = itemInventory.currentLevel;
        if (currentLevel >= itemInventory.itemProfileSO.upgradeLevels.Count) return true;
        return false;
    }
    protected virtual bool HaveEnoughIngredients(ItemInventory itemInventory)
    {
        List<ItemRecipe> upgradeLevels = itemInventory.itemProfileSO.upgradeLevels;
        ItemRecipe itemRecipe = upgradeLevels[itemInventory.currentLevel];
        string itemName;
        int itemCount;
        foreach(ItemRecipeIngredient ingredient in itemRecipe.ingredients)
        {
            itemName = ingredient.itemProfileSO.itemName;
            itemCount = ingredient.itemCount;
            if (!InventoryManager.Instance.CheckItem(itemName, itemCount)) return false;
        }
        return true;
    }
    protected virtual void DeductIngredients(ItemInventory itemInventory)
    {
        List<ItemRecipe> upgradeLevels = itemInventory.itemProfileSO.upgradeLevels;
        ItemRecipe itemRecipe = upgradeLevels[itemInventory.currentLevel];
        string itemName;
        int itemCount;
        foreach (ItemRecipeIngredient ingredient in itemRecipe.ingredients)
        {
            itemName = ingredient.itemProfileSO.itemName;
            itemCount = ingredient.itemCount;
            InventoryManager.Instance.DeductItem(itemName, itemCount);
        }
    }
}
