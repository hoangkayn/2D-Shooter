using UnityEngine;
using System.Collections;

public class InputManager : BaseMono
{
	protected static InputManager instance;
	public static InputManager Instance => instance;
    [SerializeField] protected Vector3 mousePos;
    public Vector3 MousePos => mousePos;
    [SerializeField] protected float isFire1;
    public float IsFire1 => isFire1;
    [SerializeField] protected Vector4 direction;
    public Vector4 Direction => direction;
    [SerializeField] protected bool isAlpha1;
    [SerializeField] protected bool isAlpha2;
    [SerializeField] protected bool isAlpha3;
    [SerializeField] protected bool isAlpha4;
    [SerializeField] protected bool isAlpha5;
    public bool IsAlpha1 => isAlpha1;
    public bool IsAlpha2 => isAlpha2;
    public bool IsAlpha3 => isAlpha3;
    public bool IsAlpha4 => isAlpha4;
    public bool IsAlpha5 => isAlpha5;

    protected override void Awake()
    {
        base.Awake();
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    protected virtual void Update()
    {
        this.GetMousePos();
        this.GetDirectionByKeyDown();
        this.GetFire1();
        this.GetAlpha();
    }
    protected virtual void GetAlpha()
    {
        this.isAlpha1 = Input.GetKeyDown(KeyCode.Alpha1);
        this.isAlpha2 = Input.GetKeyDown(KeyCode.Alpha2);
        this.isAlpha3 = Input.GetKeyDown(KeyCode.Alpha3);
        this.isAlpha4 = Input.GetKeyDown(KeyCode.Alpha4);
        this.isAlpha5 = Input.GetKeyDown(KeyCode.Alpha5);
       
    }
    protected virtual void GetDirectionByKeyDown()
    {
        this.direction.x = Input.GetKeyDown(KeyCode.A) ? 1 : 0;
        if (this.direction.x == 0) this.direction.x = Input.GetKeyDown(KeyCode.LeftArrow) ? 1 : 0;

        this.direction.y = Input.GetKeyDown(KeyCode.D) ? 1 : 0;
        if (this.direction.y == 0) this.direction.y = Input.GetKeyDown(KeyCode.RightArrow) ? 1 : 0;

        this.direction.z = Input.GetKeyDown(KeyCode.W) ? 1 : 0;
        if (this.direction.z == 0) this.direction.z = Input.GetKeyDown(KeyCode.UpArrow) ? 1 : 0;

        this.direction.w = Input.GetKeyDown(KeyCode.S) ? 1 : 0;
        if (this.direction.w == 0) this.direction.w = Input.GetKeyDown(KeyCode.DownArrow) ? 1 : 0;
    }
    protected virtual void GetMousePos()
    {
        this.mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
    }
    protected virtual void GetFire1()
    {
        this.isFire1 = Input.GetAxis("Fire1");

    }
}

