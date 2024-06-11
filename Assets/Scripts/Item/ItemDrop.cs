using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : BaseMono
{
    protected override void Start()
    {
        base.Start();
       // Invoke(nameof(Test), 5);
    }
    protected virtual void Test()
    {
        Drop(0);
    }
    public virtual void Drop(int itemIndex)
    {
        ItemInventory itemInventory = InventoryManager.Instance.Items[itemIndex];
        Vector3 pos = transform.parent.position + new Vector3(1,0,0);
        Quaternion rot = transform.parent.rotation;
        DropItemSpawner.Instance.Drop(itemInventory,pos,rot);
        InventoryManager.Instance.Items.Remove(itemInventory);

    }
}
    