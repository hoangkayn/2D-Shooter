using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnCloseInv : BaseBtn
{
    protected override void OnClick()
    {
        UIInventory.Instance.Close();
    }
}
