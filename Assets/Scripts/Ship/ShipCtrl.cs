using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipCtrl : AbilityObjCtrl
{
    protected override string GetTypeObjToString()
    {
        return ObjType.Ship.ToString();
    }
}
