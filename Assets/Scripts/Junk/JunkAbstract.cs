using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JunkAbstract : BaseMono
{
    [SerializeField] protected ShootableObjCtrl junkCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkCtrl != null) return;
        junkCtrl = transform.parent.GetComponent<ShootableObjCtrl>();   
    }
}
