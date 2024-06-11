using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarEnemy : BaseMono
{
    [SerializeField] protected ShootableObjCtrl shootableObjCtrl;
    [SerializeField] protected SliderHP sliderHP;
    [SerializeField] protected FollowTarget followTarget;
    [SerializeField] protected Spawner spawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSliderHP();
        this.LoadFollowTarget();
        this.LoadSpawner();
    }
    protected virtual void LoadSpawner()
    {
        if (spawner != null) return;
        spawner = transform.parent.parent.GetComponent<Spawner>();
    }
    protected virtual void LoadFollowTarget()
    {
        if (followTarget != null) return;
        followTarget = transform.GetComponent<FollowTarget>();
    }
    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected virtual void LoadSliderHP()
    {
       if (sliderHP != null) return;
        sliderHP = transform.GetComponentInChildren<SliderHP>();
    }
    public virtual void SetShootableObjCtrl(ShootableObjCtrl shootableObjCtrl)
    {
        this.shootableObjCtrl = shootableObjCtrl;
    }
    
   protected virtual void HPShowing()
    {
        bool isDead = shootableObjCtrl.DamageReceiver.IsDead();
        if (isDead) spawner.Despawn(transform);
       if (shootableObjCtrl == null) return;
        int hp = shootableObjCtrl.DamageReceiver.Hp;
        int maxHp = shootableObjCtrl.DamageReceiver.MaxHp;
        this.sliderHP.SetHP(hp);
        this.sliderHP.SetMaxHP(maxHp);
    }
    public virtual void SetTarget(Transform obj)
    {
        this.followTarget.SetTarget(obj);
    }
}
