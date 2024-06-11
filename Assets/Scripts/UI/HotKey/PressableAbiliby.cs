using UnityEngine;
using System.Collections;

public class PressableAbiliby : Pressable
{
    [SerializeField] protected AbilityCode abilityCode;
    public override void Pressed()
    {
        Debug.Log("AbilityCode: "+ abilityCode.ToString() );
    }
}

