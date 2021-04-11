using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour{

    [SerializeField] private float timeLimit;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject rope;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float timeHolder = 0f;
    private float timeHolder2 = 1f;

    public bool win = false;

    void Update(){
        if (!win){
            if (Time.time - timeHolder > timeLimit){
                timeHolder = Time.time;
                transform.position = transform.position + new Vector3(0, 0.2f, 0);
            }
            if (Time.time - timeHolder2 > timeLimit){
                timeHolder2 = Time.time;
                transform.position = transform.position + new Vector3(0, -0.2f, 0);
            }
        }
        else {
            rb.AddForce(new Vector2(2,0), ForceMode2D.Force);
            
        }
    }



}
