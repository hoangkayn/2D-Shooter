using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHPPlayer : SliderHP
{
    protected override void HPShowing()
    {
        ShipCtrl shipCtrl = GameCtrl.Instance.Player.GetComponent<ShipCtrl>();
        if (shipCtrl == null) return;
        SetHP(shipCtrl.DamageReceiver.Hp);
        SetMaxHP(shipCtrl.DamageReceiver.MaxHp);
        base.HPShowing();
    }
}
