using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragItem : BaseMono, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] protected Transform currentParent;
    [SerializeField] protected Image image;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.GetComponent<Image>();
    }
    public virtual void SetParent(Transform obj)
    {
        this.currentParent = obj;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        this.currentParent = transform.parent;
        this.transform.SetParent(UIHotKey.Instance.transform);
        this.image.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 pos = InputManager.Instance.MousePos;
        pos.z = 0;
        transform.position = pos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.SetParent(currentParent);
        image.raycastTarget = true;
    }
}
