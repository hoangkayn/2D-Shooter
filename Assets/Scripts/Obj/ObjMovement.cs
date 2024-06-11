using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : BaseMono
{
    [SerializeField] protected float speed = 0.1f;
    [SerializeField] protected Vector3 targetPos;
    protected virtual void Update()
    {
        this.SetTarget();
    }
    protected virtual void FixedUpdate()
    {
        this.Moving();
    }
    protected virtual void Moving()
    {
       
        Vector3 newPos = Vector3.Lerp(transform.position,targetPos,speed);
        transform.parent.position = newPos;
    }
    protected abstract void SetTarget();
}
