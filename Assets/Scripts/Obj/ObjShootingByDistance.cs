using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjShootingByDistance : ObjShooting
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float minDistance = 2f;
    protected override bool IsShooting()
    {
        this.distance = Vector3.Distance(target.position, transform.parent.position);
        if (distance <= minDistance) return isShooting = true;
        return isShooting = false;
    }

    
}
