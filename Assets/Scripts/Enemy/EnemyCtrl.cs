using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : AbilityObjCtrl
{
    [SerializeField] protected ObjShooting objShooting;
    public ObjShooting ObjShooting => objShooting;
    [SerializeField] protected ObjLookAt objLookAt;
    public ObjLookAt ObjLookAt => objLookAt;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadObjShooting();
        this.LoadObjLookAt();
    }
    protected virtual void LoadObjShooting()
    {
        if (this.objShooting != null) return;
        objShooting = transform.GetComponentInChildren<ObjShooting>();
    }
    protected virtual void LoadObjLookAt()
    {
        if (this.objLookAt != null) return;
        objLookAt = transform.GetComponentInChildren<ObjLookAt>();
    }
    protected override string GetTypeObjToString()
    {
        return ObjType.Enemy.ToString();
    }

  
}
