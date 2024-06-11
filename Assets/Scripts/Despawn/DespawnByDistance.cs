using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float distance;
    [SerializeField] protected float disLimit = 30f;
    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.parent.position, GameCtrl.Instance.Player.position);
        if (distance < disLimit) return false;
        return true;
    }
}
