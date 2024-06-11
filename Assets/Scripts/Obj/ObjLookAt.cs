using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ObjLookAt : MonoBehaviour
{
    [SerializeField] protected float speedRot = 5f;
    [SerializeField] protected Vector3 targetPos;
    protected virtual void Update()
    {
       
    }
    protected virtual void FixedUpdate()
    {
         this.SetTarget();
        this.Looking();
    }
    protected virtual void Looking()
    {
        Vector3 diff = targetPos - transform.parent.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        float timeSpeed = Time.fixedDeltaTime * speedRot;
        Quaternion targetEuler = Quaternion.Euler(0f, 0f, rot_z);
        Quaternion currentEuler = Quaternion.Lerp(transform.parent.rotation, targetEuler, timeSpeed);
        transform.parent.rotation = currentEuler;
    }
    protected abstract void SetTarget();
}
