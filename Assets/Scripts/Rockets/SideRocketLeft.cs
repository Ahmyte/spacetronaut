using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideRocketLeft : MonoBehaviour{
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    private void Update(){
        if (Input.GetKey("d")){
            animator.enabled = true;
        }
        else{
            animator.enabled = false;
            sprite.sprite = null;
        }
    }
}
