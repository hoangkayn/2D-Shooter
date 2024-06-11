using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjRotate : JunkAbstract
{
    [SerializeField] protected float speedRot = 1f;
    protected virtual void FixedUpdate()
    {
        this.Rotating();
    }
    protected virtual void Rotating()
    {
        this.junkCtrl.Model.Rotate(Vector3.forward * speedRot);
    }
}
