using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemCtrl : BaseMono
{
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawn();
        this.LoadItemInventory();
    }
    protected override void OnEnable()
    {
        itemInventory.currentLevel = 0;
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<Despawn>();
    }
    protected virtual void LoadItemInventory()
    {
        if (itemInventory.itemProfileSO != null) return;
        
        itemInventory.maxStack = 7;
        itemInventory.itemProfileSO = ItemProfileSO.FindItemProfileSOByName(transform.name);
        itemInventory.itemCount = 1;
    }
    public virtual void SetItemInv(ItemInventory itemInventory)
    {
        this.itemInventory = ItemInventory.Clone(itemInventory);
    }
}
