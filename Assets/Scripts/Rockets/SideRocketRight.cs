using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRocketRight : MonoBehaviour{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;

    private void Update(){
        if (Input.GetKey("a")){
            animator.enabled = true;
        }
        else{
            animator.enabled = false;
            sprite.sprite = null;
        }
    }
}
