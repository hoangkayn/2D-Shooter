using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Abilities : BaseMono
{
    [Header("Abilities")]
    [SerializeField] protected AbilityObjCtrl abilityObjCtrl;
    public AbilityObjCtrl AbilityObjCtrl => abilityObjCtrl;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadAbilityObjectCtrl();
    }

    protected virtual void LoadAbilityObjectCtrl()
    {
        if (this.abilityObjCtrl != null) return;
        this.abilityObjCtrl = transform.parent.GetComponent<AbilityObjCtrl>();
       
    }
}
