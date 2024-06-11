using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjAppearBigger : ObjAppear
{
    [SerializeField] protected float speedScale = 0.01f;
    [SerializeField] protected float currentScale =0.1f;
    [SerializeField] protected float startScale = 0.1f;
    [SerializeField] protected float maxScale = 1f;
   
    protected override void Apparering()
    {
        if (this.appeared) return;
        currentScale += speedScale;
        transform.parent.localScale = new Vector3(currentScale, currentScale, currentScale);
        if (currentScale >= maxScale) this.Appeared();
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        this.InitScale();
    }
    protected virtual void InitScale()
    {
        appeared = false;
        currentScale = 0.1f;
        transform.parent.localScale = new Vector3(startScale, startScale, startScale);
    }
    protected override void Appeared()
    {
        base.Appeared();
        transform.parent.localScale = new Vector3(maxScale, maxScale, maxScale);
        
    }

}
