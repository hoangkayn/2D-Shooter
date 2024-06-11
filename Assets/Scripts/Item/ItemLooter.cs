using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : BaseMono
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rb;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.radius = 0.26f;
        sphereCollider.isTrigger = true;
    }
    protected virtual void LoadRigidbody()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }
    
    protected virtual void OnTriggerEnter(Collider other)
    {
        ItemPickupable itemPickupable = other.GetComponent<ItemPickupable>();
       
        if (itemPickupable == null) return;
        ItemInventory itemInventory = itemPickupable.DropItemCtrl.ItemInventory;

        if (InventoryManager.Instance.AddItem(itemInventory))
        {
            itemPickupable.Picked();
        }
    }
}
