using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ShootableObjCtrl : BaseMono
{
    [SerializeField] protected Transform model;
    public Transform Model => model;
    [SerializeField] protected Despawn despawn;
    public Despawn Despawn => despawn;
    [SerializeField] protected ShootableObjSO shootabeObjSO;
    public ShootableObjSO ShootableObjSO => shootabeObjSO;
    [SerializeField] protected Spawner spawner;
    public Spawner Spawner => spawner;
    [SerializeField] protected DamageReceiver damageReceiver;
    public DamageReceiver DamageReceiver => damageReceiver;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadModel();
        this.LoadDespawn();
        this.LoadShootableObjSO();
        this.LoadSpawner();
        this.LoadDamageReceiver();
    }
    protected virtual void LoadDamageReceiver()
    {
        if (damageReceiver != null) return;
        damageReceiver = transform.GetComponentInChildren<DamageReceiver>();
    }
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent?.parent?.GetComponent<Spawner>();
    }
    protected virtual void LoadModel()
    {
        if (model != null) return;
        model = transform.Find("Model");
    }
    protected virtual void LoadDespawn()
    {
        if (despawn != null) return;
        despawn = transform.GetComponentInChildren<Despawn>();
    }
    protected virtual void LoadShootableObjSO()
    {
        if (shootabeObjSO != null) return;
        string resPath = "ShootableObjSO/" + this.GetTypeObjToString() + "/" + transform.name;
        this.shootabeObjSO = Resources.Load<ShootableObjSO>(resPath);
    }
    protected abstract string GetTypeObjToString();

}
