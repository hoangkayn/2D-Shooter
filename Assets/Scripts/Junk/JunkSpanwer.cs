using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkSpanwer : Spawner
{

    protected static JunkSpanwer instance;
    public static JunkSpanwer Instance => instance;
   
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
