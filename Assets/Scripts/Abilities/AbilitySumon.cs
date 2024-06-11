using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySumon : BaseAbility
{
    [SerializeField] protected Spawner spawner;
    [SerializeField] protected List<Transform> minions;
    [SerializeField] protected int minionLimit = 2;
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        this.Sumoning();
        this.ClearMinionDead();
    }

    
    protected virtual void ClearMinionDead()
    {
        foreach(Transform minion in minions)
        {
           if(minion.gameObject.activeSelf == false)
            {
                this.minions.Remove(minion);
                return;
            }
        }
    }
    protected virtual void Sumoning()
    {
        if (!this.isReady) return;
        if (minions.Count >= minionLimit) return;
        this.Sumon();
        this.Active();
    }
    protected virtual Transform Sumon()
    {
        Transform spawnPos = this.abilities.AbilityObjCtrl.SpawnPoint.RandomPoint();
        Transform minionPrefab = spawner.RandomPrefab();
        Transform minion = spawner.Spawn(minionPrefab.name, spawnPos.position, spawnPos.rotation);
        this.minions.Add(minion);
        return minion;
    }
}
