using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metal : MonoBehaviour
{
    public ItemObject self;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject); //Destroyed if hits an object.
        if (collision.gameObject.name == "unit")
        {
            //collision.gameObject.GetComponent<PlayerInventory>().inventoryObject.AddItem(self, 1);
            Destroy(this.gameObject);
        }
    }
}
