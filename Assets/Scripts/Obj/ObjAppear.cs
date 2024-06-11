using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAppear : BaseMono
{

    [SerializeField] protected bool appeared = false;
    [SerializeField] protected List<IAppearObserver> observers = new List<IAppearObserver>();
   
  
    protected override void OnEnable()
    {
        this.OnAppearStart();
    }
    protected override void Start()
     {
         base.Start();
         this.OnAppearStart();
     }
    
    protected virtual void FixedUpdate() {
        this.Apparering();
    }
    protected abstract void Apparering();
    protected virtual void Appeared() {
        appeared = true;
        this.OnAppearFinish();
    }
    protected virtual void OnAppearStart()
    {
       
        foreach(IAppearObserver observer in observers)
        {
            observer.OnAppearStart();
        }
    }
    protected virtual void OnAppearFinish()
    {
        foreach (IAppearObserver observer in observers)
        {
            observer.OnAppearFinish();
        }
    }
    public virtual void AddObserver(IAppearObserver observer)
    {
        this.observers.Add(observer);
    }
}
