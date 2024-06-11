using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextHPPlayer : BaseText
{
   protected virtual void FixedUpdate()
    {
        this.UpdatePlayerHp();
    }
    protected virtual void UpdatePlayerHp()
    {
        ShipCtrl shipCtrl = GameCtrl.Instance.Player.GetComponent<ShipCtrl>();

        int hp = shipCtrl.DamageReceiver.Hp;
        int maxHp = shipCtrl.DamageReceiver.MaxHp;
        this.text.SetText(hp + "/" + maxHp);
    }
}
