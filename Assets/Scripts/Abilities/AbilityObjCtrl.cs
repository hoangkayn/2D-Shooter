using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityObjCtrl : ShootableObjCtrl
{
    [SerializeField] protected SpawnPoint spawnPoint;
    public SpawnPoint SpawnPoint => spawnPoint;

    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSpawnPoint();
    }
    protected virtual void LoadSpawnPoint()
    {
        if (spawnPoint != null) return;
        spawnPoint = transform.GetComponentInChildren<SpawnPoint>();
    }

}
