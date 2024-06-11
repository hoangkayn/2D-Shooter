using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public abstract class DamageReceiver : BaseMono
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected int hp;
    public int Hp => hp;
    [SerializeField] protected int maxHp;
    public int MaxHp => maxHp;
    [SerializeField] protected bool isDead = false;
   
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }
    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = transform.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = 0.26f;
    }
    protected override void OnEnable()
    {
        this.Reborn();
    }
    protected override void ResetValue()
    {
        base.ResetValue();
        this.Reborn();
    }
    protected virtual void Reborn()
    {
        this.hp = maxHp;
        isDead = false;
    }
    public virtual void Add(int value)
    {
        if (isDead) return;
        hp += value;
        if (hp > maxHp) hp = maxHp;
    }
    public virtual void Deduct(int value)
    {
        if (isDead) return;
        hp -= value;
        if (hp < 0) hp = 0;
        this.CheckIsDead();
    }
    public virtual bool IsDead()
    {
        return hp <= 0;
    }
    protected virtual void CheckIsDead()
    {
        if (!IsDead()) return;
        isDead = true;
        this.OnDead();
    }
    protected abstract void OnDead();
}
