using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjWithoutShoot : BaseMono,IAppearObserver
{
    [SerializeField] protected ObjAppear objAppear;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
        this.LoadObjAppear();
    }
    protected override void Awake()
    {
        this.EventRegistration();
    }
    protected virtual void LoadObjAppear()
    {
        if (objAppear != null) return;
        objAppear = transform.GetComponent<ObjAppear>();
    }
    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
    }
    public void OnAppearStart()
    {
       
        enemyCtrl.ObjShooting.gameObject.SetActive(false);
        enemyCtrl.ObjLookAt.gameObject.SetActive(false);
        
    }

    public void OnAppearFinish()
    {
        enemyCtrl.ObjShooting.gameObject.SetActive(true);
        enemyCtrl.ObjLookAt.gameObject.SetActive(true);
        enemyCtrl.Spawner.Holder(transform.parent);
    }
    protected virtual void EventRegistration()
    {
        this.objAppear.AddObserver(this);
    }
}
