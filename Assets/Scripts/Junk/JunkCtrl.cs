using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JunkCtrl : ShootableObjCtrl
{
    protected override string GetTypeObjToString()
    {
        return ObjType.Junk.ToString();
    }
}
