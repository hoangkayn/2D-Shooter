using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnOpenInv : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Toggle();
    }
    
}
