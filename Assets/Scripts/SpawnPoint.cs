using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnPoint : BaseMono
{
    [SerializeField] protected List<Transform> points;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPoint();
    }
    protected virtual void LoadPoint()
    {
        if (points.Count > 0) return;
        foreach (Transform child in transform)
        {
           ObjMovementPlayer objMovementPlayer = child.GetComponent<ObjMovementPlayer>();
            if (objMovementPlayer != null) continue; 
            this.points.Add(child);
        }
    }
    public virtual Transform RandomPoint()
    {
        int ran = Random.Range(0, points.Count);
        return points[ran];
    }
}

