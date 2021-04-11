using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingPanel : MonoBehaviour
{
    [SerializeField] private float moveLeft;
    private bool isOpen = false;
    void Update()
    {
        if(!isOpen && Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.transform.Translate(-moveLeft,0,0);
            isOpen = true;
        }
        else if(isOpen && Input.GetKeyDown(KeyCode.Tab))
        {
            gameObject.transform.Translate(moveLeft, 0, 0);
            isOpen = false;
        }
    }
}
