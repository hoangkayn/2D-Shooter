using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAlpha : BaseMono
{
    [SerializeField] protected UIHotKey uIHotKey;
    public UIHotKey UIHotKey => UIHotKey;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKey();
    }
    protected virtual void LoadUIHotKey()
    {
        if (this.uIHotKey != null) return;
        this.uIHotKey = transform.parent.GetComponent<UIHotKey>();
    }
    protected virtual void Update()
    {
        this.CheckPressAlpha();
    }protected virtual void CheckPressAlpha()
    {
        if (InputManager.Instance.IsAlpha1) this.Press(1);
        if (InputManager.Instance.IsAlpha2) this.Press(2);
        if (InputManager.Instance.IsAlpha3) this.Press(3);
        if (InputManager.Instance.IsAlpha4) this.Press(4);
        if (InputManager.Instance.IsAlpha5) this.Press(5);
    }
    protected virtual void Press(int alpha)
    {
        SlotItem slotItem = this.uIHotKey.Slots[alpha -1];
        Pressable pressable = slotItem.transform.GetComponentInChildren<Pressable>();
        if (pressable == null) return;
        pressable.Pressed();

    }
}
