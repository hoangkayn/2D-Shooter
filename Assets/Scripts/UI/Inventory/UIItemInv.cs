using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInv : BaseMono
{
   
    [SerializeField] protected Image image;
    public Image Image => image;
    [SerializeField] protected TextMeshProUGUI text;
    public TextMeshProUGUI Text => text;
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadImage();
        this.LoadText();
    }
    protected virtual void LoadImage()
    {
        if (image != null) return;
        image = transform.Find("ImgItem").GetComponent<Image>();
    }
    protected virtual void LoadText()
    {
        if (text != null) return;
        text = transform.Find("TextNumber").GetComponent<TextMeshProUGUI>();
    }
    public virtual void SetItemInventory(ItemInventory itemInventory)
    {
        this.itemInventory = itemInventory;
    }
} 
