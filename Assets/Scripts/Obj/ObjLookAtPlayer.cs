using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtPlayer : ObjLookAt
{
    protected override void SetTarget()
    {
        this.targetPos = GameCtrl.Instance.Player.position;
    }
}
