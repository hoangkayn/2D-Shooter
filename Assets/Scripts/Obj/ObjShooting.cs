using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjShooting : BaseMono
{
    [SerializeField] protected float timer;
    [SerializeField] protected float delayTimer = 0.25f;
    [SerializeField] protected bool isShooting = false;
    protected virtual void Update()
    {
        IsShooting();
    }
    protected virtual void FixedUpdate()
    {
        this.Shooting();
    }
    protected virtual void Shooting()
    {
        if (!this.IsShooting()) return;
        timer += Time.fixedDeltaTime;
        if (timer < delayTimer) return;
        timer = 0;
       Transform bullet = BulletSpanwer.Instance.Spawn(BulletSpanwer.Bullet_1, transform.parent.position, transform.parent.rotation);
        BulletCtrl bulletCtrl = bullet.GetComponent<BulletCtrl>();
        bulletCtrl.SetShooter(transform.parent);
    }
    protected abstract bool IsShooting();
}
