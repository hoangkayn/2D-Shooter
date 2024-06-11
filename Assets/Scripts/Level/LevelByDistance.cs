using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class LevelByDistance : Level
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float distance;
    [SerializeField] protected float distancePerLevel = 10f;
    protected virtual void FixedUpdate()
    {
        this.SetTarget();
        this.Leveling();
    }
    protected virtual void Leveling()
    {
        if (target == null) return;
        distance = Vector3.Distance(target.position, transform.parent.position);
        int level = GetLevelByDis(distance);
        this.SetLevel(level);
    }
    protected virtual int GetLevelByDis(float distance)
    {
        return Mathf.FloorToInt(distance/distancePerLevel);
    }
    protected abstract void SetTarget();
}
