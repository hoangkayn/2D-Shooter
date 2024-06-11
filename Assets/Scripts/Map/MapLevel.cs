using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLevel : LevelByDistance
{
    protected override void SetTarget()
    {
        this.target = GameCtrl.Instance.Player;
    }
}
