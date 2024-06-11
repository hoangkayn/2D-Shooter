using UnityEngine;
using System.Collections;

public class ObjMovementPlayer : ObjMovement
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 1f;
    }
    protected override void SetTarget()
    {
       this.targetPos = GameCtrl.Instance.Player.position;

    }
   
}

