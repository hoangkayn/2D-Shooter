using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjLookAtMouse : ObjLookAt
{
    protected override void SetTarget()
    {
        this.targetPos = InputManager.Instance.MousePos;
        this.targetPos.z = 0;
    }

    
}
