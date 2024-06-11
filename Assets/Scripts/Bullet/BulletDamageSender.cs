using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamageSender : DamageSender
{
    [SerializeField] protected BulletCtrl bulletCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBulletCtrl();
    }
    protected virtual void LoadBulletCtrl()
    {
        if (bulletCtrl != null) return;
        bulletCtrl = transform.parent.GetComponent<BulletCtrl>();
    }

    protected override void Send(DamageReceiver damageReceiver)
    {
        base.Send(damageReceiver);
        this.DestroyObj();
    }
    protected virtual void DestroyObj()
    {
        this.bulletCtrl.BulletDespawn.DespawnObject();
    }
}
