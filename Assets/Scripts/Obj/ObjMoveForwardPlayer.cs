using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjMoveForwardPlayer : ObjMovementForward
{
   
    [SerializeField] protected float distancePlayer;
    [SerializeField] protected float distancePlayerLimit = 1.5f;
    
    protected override void FixedUpdate()
    {
        this.distancePlayer = Vector3.Distance(transform.parent.position,GameCtrl.Instance.Player.position);
        if (distancePlayer <= distancePlayerLimit) return;
        base.FixedUpdate();
    }
}
