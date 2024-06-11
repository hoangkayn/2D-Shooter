using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItemInvSpawner : Spawner
{
    protected static UIItemInvSpawner instance;
    public static UIItemInvSpawner Instance => instance;
    public static string UIItemInv = "UIItemInv";
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;

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
    protected override void LoadComponents()
    {
        this.LoadUIInventoryCtrl();
        base.LoadComponents();
       
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (this.uIInventoryCtrl != null) return;
        this.uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
        
    }
    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = UIInventoryCtrl.Content;
    }
    public virtual void ClearItem()
    {
        foreach(Transform item in holder)
        {
            this.Despawn(item);
        }
    }
    public virtual void SpawnItem(ItemInventory item)
    {
        Transform uiItem = this.uIInventoryCtrl.UIItemInvSpawner.Spawn(UIItemInvSpawner.UIItemInv, Vector3.zero, Quaternion.identity);
        uiItem.transform.localScale = new Vector3(1, 1, 1);
        UIItemInv uIItemInv = uiItem.GetComponent<UIItemInv>();
        uIItemInv.SetItemInventory(item);
        uIItemInv.Text.text = item.itemCount.ToString();
        uIItemInv.Image.sprite = item.itemProfileSO.sprite;
    }
}
