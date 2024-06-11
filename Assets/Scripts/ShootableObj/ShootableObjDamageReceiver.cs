using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootableObjDamageReceiver : DamageReceiver
{
    [SerializeField] protected ShootableObjCtrl shootableObjCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadShootableObjCtrl();
    }

    protected virtual void LoadShootableObjCtrl()
    {
        if (shootableObjCtrl != null) return;
        shootableObjCtrl = transform.parent.GetComponent<ShootableObjCtrl>();
    }
    protected override void OnDead()
    {
        this.OnDeadFX();
        shootableObjCtrl.Despawn.DespawnObject();
        this.OnDeadDrop();

    }
    protected virtual void OnDeadDrop()
    {
        DropItemSpawner.Instance.Drop(shootableObjCtrl.ShootableObjSO.items, transform.position, transform.rotation);
    }
    protected override void Reborn()
    {
        this.maxHp = shootableObjCtrl.ShootableObjSO.maxHp;
        base.Reborn();
    }
    protected virtual void OnDeadFX()
    {
        Vector3 pos = transform.parent.position;

        FXSpawner.Instance.Spawn(FXSpawner.Smoke_1, pos, Quaternion.identity);

    }

}
