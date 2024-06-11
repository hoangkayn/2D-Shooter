using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAbility : BaseMono
{
    [SerializeField] protected Abilities abilities;
    [SerializeField] protected float timer;
    [SerializeField] protected float timeDelay = 3f;
    [SerializeField] protected bool isReady = false;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilities();
    }
    protected virtual void LoadAbilities()
    {
        if (abilities != null) return;
        abilities = transform.parent.GetComponent<Abilities>();
    }
    protected virtual void FixedUpdate()
    {
        this.Timing();

    }
    protected virtual void Timing()
    {
        if (isReady) return;
        timer += Time.fixedDeltaTime;
        if (timer < timeDelay) return;
        timer = 0;
        this.isReady = true;
    }
    protected virtual void Active()
    {
        isReady = false;
    }
}
