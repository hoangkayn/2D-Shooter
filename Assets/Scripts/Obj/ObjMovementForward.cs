using UnityEngine;
using System.Collections;

public class ObjMovementForward : ObjMovement

{
    [SerializeField] protected Transform targetForward;
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTargetForward();
    }
    protected virtual void LoadTargetForward()
    {
        if (this.targetForward != null) return;
        this.targetForward = transform.Find("TargetForward");
    }
    protected override void SetTarget()
    {
        this.targetPos = targetForward.position;
    }

   
}

