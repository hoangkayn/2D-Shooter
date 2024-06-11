using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDespawn : DespawnByTime
{
    protected override void ResetValue()
    {
        base.ResetValue();
        this.delayTime = 5f;
    }
    public override void DespawnObject()
    {
        DropItemSpawner.Instance.Despawn(transform.parent);
    }
}
