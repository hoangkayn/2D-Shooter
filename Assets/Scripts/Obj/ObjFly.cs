using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjFly : BaseMono
{
    [SerializeField] protected Vector3 direction = Vector3.right;
    [SerializeField] protected float speed = 0.7f;
   
    protected virtual void FixedUpdate()
    {
        this.Flying();
    }
    protected virtual void Flying()
    {
        transform.parent.Translate(direction * speed);
    }
}
