using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal.Profiling.Memory.Experimental;
using UnityEngine;

public class UIInventory : BaseMono
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;
    [SerializeField] protected InventorySort inventorySort;
    protected bool isOpen = true;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (uIInventoryCtrl != null) return;
        uIInventoryCtrl = transform.GetComponent<UIInventoryCtrl>();
    }
    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();

        InvokeRepeating(nameof(this.ShowItem), 1, 1);
    }

   

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }

    protected virtual void ShowItem()
    {
        if (!this.isOpen) return;

        this.ClearItems();
        List<ItemInventory> items = InventoryManager.Instance.Items;
       foreach(ItemInventory item in items)
        {
            UIInventoryCtrl.UIItemInvSpawner.SpawnItem(item);
        }
        this.SortItem();
    }

    protected virtual void ClearItems()
    {
        this.uIInventoryCtrl.UIItemInvSpawner.ClearItem();
    }
    protected virtual void SortItem()
    {
        switch (inventorySort)
        {
          
            case InventorySort.ByCount:
                SortByCount();
                break;
            default:
                Debug.Log("NO sort");
                break;
        }
    }
    protected virtual void SortByCount()
    {
        int itemCount = uIInventoryCtrl.Content.childCount;
        Transform currentItem, nextItem;
        UIItemInv currentUIItemInv, nextUIItemInv;
        ItemInventory currentItemInv, nextItemInv;
        int currentCountItem, nextCountItem;
        bool isSorting = false;
        for (int i = 0;i< itemCount - 1; i++)
        {
            currentItem = uIInventoryCtrl.Content.GetChild(i);
            nextItem = uIInventoryCtrl.Content.GetChild(i + 1);
            currentUIItemInv = currentItem.GetComponent<UIItemInv>();
            nextUIItemInv = nextItem.GetComponent<UIItemInv>();
            currentItemInv = currentUIItemInv.ItemInventory;
            nextItemInv = nextUIItemInv.ItemInventory;
            currentCountItem = currentItemInv.itemCount;
            nextCountItem = nextItemInv.itemCount;
            if(currentCountItem > nextCountItem)
            {
                this.SwapItem(currentItem, nextItem);
                isSorting = true;
            }
        }
        if (isSorting == true) this.SortByCount();
    }

    protected virtual void SwapItem(Transform currentItem,Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();
        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
