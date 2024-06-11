using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;
    public static string Enemy_1 = "Enemy_1";
    protected override void Awake()
    {
        base.Awake();
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    public override Transform Spawn(string namePrefab, Vector3 pos, Quaternion rot)
    {
        Transform enemy =  base.Spawn(namePrefab, pos, rot);
         AddHPBar(enemy);
        return enemy;
    }
    protected virtual void AddHPBar(Transform enemy)
    {
       Transform prefabHpBar = HPBarSpawner.Instance.Spawn(HPBarSpawner.HPBarEnemy,transform.parent.position,Quaternion.identity);
        HPBarEnemy hPBarEnemy = prefabHpBar.GetComponent<HPBarEnemy>();
        hPBarEnemy.SetTarget(enemy);
        ShootableObjCtrl shootableEnemy = enemy.GetComponent<ShootableObjCtrl>();
        hPBarEnemy.SetShootableObjCtrl(shootableEnemy);



    }
}
