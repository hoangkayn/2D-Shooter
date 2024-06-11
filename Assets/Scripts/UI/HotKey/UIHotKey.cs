using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIHotKey : BaseMono
{
    protected static UIHotKey instance;
    public static UIHotKey Instance => instance;
    [SerializeField] protected List<SlotItem> slots;
    public List<SlotItem> Slots => slots;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSlots();
    }
    protected virtual void LoadSlots()
    {
        if (slots.Count > 0) return;
        SlotItem[] array = GetComponentsInChildren<SlotItem>();
        this.slots.AddRange(array);
    }

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
