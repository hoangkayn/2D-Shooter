using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SlotItem : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount > 0) return;
        GameObject objDrag = eventData.pointerDrag;
        DragItem dragItem = objDrag.GetComponent<DragItem>();
        dragItem.SetParent(transform);
    }

    
}
