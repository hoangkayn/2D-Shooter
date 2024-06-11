using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDespawn : DespawnByDistance
{
    public override void DespawnObject()
    {
        BulletSpanwer.Instance.Despawn(transform.parent);
    }
}
