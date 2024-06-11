using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : BaseMono
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected DropItemCtrl dropItemCtrl;
    public DropItemCtrl DropItemCtrl => dropItemCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadDropItemCtrl();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.radius = 0.09f;
        sphereCollider.isTrigger = true;
    }
    protected virtual void LoadDropItemCtrl()
    {
        if (dropItemCtrl != null) return;
        dropItemCtrl = transform.parent.GetComponent<DropItemCtrl>();
    }
    public virtual void Picked()
    {
        dropItemCtrl.Despawn.DespawnObject();
    }
}
