using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInventoryCtrl : BaseMono
{
    [SerializeField] protected Transform content;
    public Transform Content => content;
    [SerializeField] protected UIItemInvSpawner uIItemInvSpawner;
    public UIItemInvSpawner UIItemInvSpawner => uIItemInvSpawner;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
        this.LoadUIItemInvSpawner();
    }
    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        content = transform.Find("Scroll View").Find("Viewport").Find("Content");
    }
    protected virtual void LoadUIItemInvSpawner()
    {
        if (uIItemInvSpawner != null) return;
        uIItemInvSpawner = transform.GetComponentInChildren<UIItemInvSpawner>();
    }
}
