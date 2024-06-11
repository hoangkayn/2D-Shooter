using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPBarSpawner : Spawner
{
    protected static HPBarSpawner instance;
    public static HPBarSpawner Instance => instance;
    public static string HPBarEnemy = "HPBarEnemy";
    
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
}
