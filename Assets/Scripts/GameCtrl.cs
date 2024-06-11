using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCtrl : BaseMono
{
    protected static GameCtrl instance;
    public static GameCtrl Instance => instance;
    [SerializeField] protected Camera mainCamera;
    public Camera MainCamera => mainCamera;
    [SerializeField] protected Transform player;
    public Transform Player => player;
   
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
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMainCamera();
        this.LoadPlayer();
    }
    protected virtual void LoadMainCamera()
    {
        if (mainCamera != null) return;
        this.mainCamera = GameObject.FindAnyObjectByType<Camera>();
    }
    protected virtual void LoadPlayer()
    {
        if (this.player != null) return;
        this.player = GameObject.Find("Player").transform;
    }
}
