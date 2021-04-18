using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour{

    [SerializeField] private float speed;
    private Vector3 moveDir;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private PlayerNeedSystems playerNeedSystems;
    private ItemObject itemObject;

    void Start(){
        moveDir = new Vector3(0, 0, 0);
    }

    void Update(){

        if (Input.GetKey("space")){
            rb.AddRelativeForce(new Vector3(0, 1f, 0) * speed);
        }
        if (Input.GetKey("a")){
            transform.Rotate(0.0f, 0.0f, rotateSpeed, Space.Self);
            rb.AddTorque(0.2f, ForceMode2D.Force);
        }
        if (Input.GetKey("d")){
            transform.Rotate(0.0f, 0.0f, -rotateSpeed, Space.Self);
            rb.AddTorque(-0.2f,ForceMode2D.Force);
        }
    }

    public void SetHard(){
        playerNeedSystems.healthSystem.SetMaxHealth(50);
        rotateSpeed = rotateSpeed / 2;
    }
    public void SetEasy(){
        speed = speed + speed;
        playerNeedSystems.healthSystem.SetMaxHealth(200);
        playerNeedSystems.O2reduceSpeed = 0.004f;
    }
    public void SetMedium(){

    }
}
