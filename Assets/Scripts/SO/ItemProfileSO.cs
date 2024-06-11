using UnityEngine;
using System.Collections.Generic;
using static UnityEngine.RuleTile.TilingRuleOutput;

[CreateAssetMenu(fileName = "ItemProfile", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
	public string itemName = "";
	public ItemType itemType;
	public Sprite sprite;
	public List<ItemRecipe> upgradeLevels;
	public static ItemProfileSO FindItemProfileSOByName(string itemName)
	{
        string resPath = "ItemInvProfileSO/" + itemName;
        return Resources.Load<ItemProfileSO>(resPath);
    }
}

