using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]

public class BulletImpact : BulletAbstract
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rb;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigibody();
    }
    protected virtual void LoadSphereCollider()
    {
        if (sphereCollider != null) return;
        sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.06f;

    }
    protected virtual void LoadRigibody()
    {
        if (rb != null) return;
        rb = transform.GetComponent<Rigidbody>();
        rb.isKinematic = true;
        

    }
    protected virtual void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent == bulletCtrl.Shooter) return;
        this.bulletCtrl.BulletDamageSender.Send(other.transform);
       
    }
    
}
