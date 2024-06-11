using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : BaseMono
{
    [SerializeField] protected BulletDespawn bulletDespawn;
    public BulletDespawn BulletDespawn => bulletDespawn;
    [SerializeField] protected BulletDamageSender bulletDamageSender;
    public BulletDamageSender BulletDamageSender => bulletDamageSender;
    [SerializeField] protected Transform shooter;
    public Transform Shooter => shooter;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletDespawn();
        this.LoadBulletDamageSender();
    }
    protected virtual void LoadBulletDespawn()
    {
        if (bulletDespawn != null) return;
        bulletDespawn = transform.GetComponentInChildren<BulletDespawn>();
    }
    protected virtual void LoadBulletDamageSender()
    {
        if (bulletDamageSender != null) return;
        bulletDamageSender = transform.GetComponentInChildren<BulletDamageSender>();
    }
    public virtual void SetShooter(Transform obj)
    {
        this.shooter = obj;
    }
}
