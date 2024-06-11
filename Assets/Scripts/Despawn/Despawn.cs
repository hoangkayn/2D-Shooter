using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Despawn : BaseMono
{
    protected virtual void FixedUpdate()
    {
        this.Despawning();
    }
    protected virtual void Despawning()
    {
        if (!CanDespawn()) return;
        this.DespawnObject();
    }
    public virtual void DespawnObject()
    {

    }
    
    protected abstract bool CanDespawn();
    
}
