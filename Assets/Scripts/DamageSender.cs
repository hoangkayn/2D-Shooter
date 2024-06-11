using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageSender : BaseMono
{
  
    [SerializeField] protected int damage = 1;
  
    public virtual void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }
    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
        this.FXImpact();

    }
    protected virtual void FXImpact()
    {
        Vector3 pos = transform.parent.position;
        Quaternion rot = transform.parent.rotation;
        FXSpawner.Instance.Spawn(FXSpawner.Impact_1, pos, rot);
    }
}
