using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTime = 2f;
    protected override bool CanDespawn()
    {
        timer += Time.fixedDeltaTime;
        if (timer < delayTime) return false;
        timer = 0;
        return true;
    }
}
