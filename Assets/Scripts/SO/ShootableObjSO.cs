using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ShootableObj", menuName = "SO/ShootableObj")]
public class ShootableObjSO : ScriptableObject
{
    public int maxHp;
    public List<ItemDropRate> items;
}
