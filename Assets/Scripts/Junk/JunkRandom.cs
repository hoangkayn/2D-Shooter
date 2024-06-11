using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkRandom : BaseMono
{
    [SerializeField] protected JunkSpawnerCtrl junkSpawnerCtrl;
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTimer = 3f;
    [SerializeField] protected int randomLimit = 6;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadJunkCtrl();
    }
    protected virtual void LoadJunkCtrl()
    {
        if (junkSpawnerCtrl != null) return;
        junkSpawnerCtrl = transform.GetComponent<JunkSpawnerCtrl>();
    }
    protected virtual void FixedUpdate()
    {
        this.JunkSpawning();
    }
    protected virtual void JunkSpawning()
    {
        if (RandomReachLimit()) return;
        timer += Time.fixedDeltaTime;
        if (timer < delayTimer) return;
        timer = 0;
        Vector3 pos = junkSpawnerCtrl.SpawnPoint.RandomPoint().position;
        Transform junkPrefab = junkSpawnerCtrl.JunkSpawner.RandomPrefab();
         this.junkSpawnerCtrl.JunkSpawner.Spawn(junkPrefab.name,pos,transform.rotation);
    }
    protected virtual bool RandomReachLimit()
    {
        if (randomLimit <= junkSpawnerCtrl.JunkSpawner.SpawnedCount) return true;
        return false;
    }
}