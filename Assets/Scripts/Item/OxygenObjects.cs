using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Oxygen Object", menuName = "Inventory System/Items/Oxygen")]
public class OxygenObjects : ItemObject
{
    public void Awake()
    {
        type = ItemType.Oxygen;
    }
}
