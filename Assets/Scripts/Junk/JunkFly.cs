using UnityEngine;
using System.Collections;

public class JunkFly : ObjFly
{

    protected override void OnEnable()
    {
        SetFlyDirection();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.speed = 0.01f;
    }
    protected virtual void SetFlyDirection()
    {

        Vector3 camPos = GetCamPos();
        camPos.x += Random.Range(-5,5);
        Vector3 objPos = transform.parent.position;
        Vector3 diff = camPos - objPos;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.parent.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, rot_z);
        Debug.DrawLine(objPos, objPos + diff * 7, Color.green, Mathf.Infinity);
    }
    protected virtual Vector3 GetCamPos()
    {
        if (GameCtrl.Instance == null) return Vector3.zero;
        Vector3 camPos = GameCtrl.Instance.MainCamera.transform.position;
        
        return camPos;
    }
}

