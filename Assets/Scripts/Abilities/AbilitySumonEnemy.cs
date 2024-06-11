using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySumonEnemy : AbilitySumon
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemySpawner();
    }
    protected virtual void LoadEnemySpawner()
    {
        if (spawner != null) return;
        spawner = GameObject.FindAnyObjectByType<EnemySpawner>();
    }
    protected override Transform Sumon()
    {
        Transform minion = base.Sumon();
        minion.parent = this.abilities.AbilityObjCtrl.transform;
        return minion;
        
    }
}
