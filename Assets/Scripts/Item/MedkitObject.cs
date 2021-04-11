using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New MedKit Object", menuName = "Inventory System/Items/MedKit")]
public class MedkitObject : ItemObject
{
    public float HPrestored;
    public void Awake()
    {
        type = ItemType.MedKit;
    }
    private void UseItem()
    {

    }
}
