using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackRocket : MonoBehaviour{

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private AudioSource audio;
    private void Update(){
        if (Input.GetKey("space")){
            animator.enabled = true;
            if(!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else if(Input.GetKeyUp("space"))
        {
            audio.Stop();
        }
        else{
            animator.enabled = false;
            sprite.sprite = null;
        }
    }

}
