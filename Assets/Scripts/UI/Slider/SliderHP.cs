using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderHP : BaseSlider
{
  
    [SerializeField] private float hp;
    public float Hp => hp;
    [SerializeField] private float maxHp;
    public float MaxHp => maxHp;
   
    protected virtual void FixedUpdate()
    {
        this.HPShowing();
    }
    protected override void OnValueChanged(float value)
    {
       // Debug.Log("value:" + value);
    }
    protected virtual void HPShowing()
    {
        float hpPercent = hp / maxHp;
        slider.value = hpPercent;
    }
    public virtual void SetHP(int value)
    {
        this.hp = value;
    }
    public virtual void SetMaxHP(int value)
    {
        this.maxHp = value;
    }

}
