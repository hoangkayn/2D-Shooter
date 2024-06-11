using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpanwer : Spawner
{
    protected static BulletSpanwer instance;
    public static BulletSpanwer Instance => instance;
    public static string Bullet_1 = "Bullet_1";
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
