using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryAbstract : BaseMono
{
    [SerializeField] protected UIInventoryCtrl uIInventoryCtrl;
    public UIInventoryCtrl UIInventoryCtrl => uIInventoryCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIInventoryCtrl();
    }
    protected virtual void LoadUIInventoryCtrl()
    {
        if (uIInventoryCtrl != null) return;
        uIInventoryCtrl = transform.parent.GetComponent<UIInventoryCtrl>();
    }
}
