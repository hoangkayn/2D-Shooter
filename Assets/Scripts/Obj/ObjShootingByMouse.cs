using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShootingByMouse : ObjShooting
{
    protected override bool IsShooting()
    {
        this.isShooting = InputManager.Instance.IsFire1 == 1;
        return isShooting;
    }

}
