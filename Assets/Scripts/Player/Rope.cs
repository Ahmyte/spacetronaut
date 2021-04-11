using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour{

    [SerializeField] private Rigidbody2D rb;
    private Vector3 targetPosition;
    [SerializeField] private LineRenderer line;
    private float ropeL = 50;
    void Start(){
        targetPosition = new Vector3(0, 0, 0);
    }

    void Update(){
        if (CalculateMaxDistance(rb.gameObject.transform.position.x, rb.gameObject.transform.position.y, ropeL)){
            line.startColor = Color.yellow;
            line.endColor = Color.red;
            rb.AddForce((targetPosition - rb.gameObject.transform.position)/4, ForceMode2D.Force);
        }
        else if (CalculateMaxDistance(rb.gameObject.transform.position.x, rb.gameObject.transform.position.y, 3 * ropeL / 5)){
            line.startColor = Color.white;
            line.endColor = Color.yellow;
        }
        else if (CalculateMaxDistance(rb.gameObject.transform.position.x, rb.gameObject.transform.position.y, 0)){
            line.startColor = Color.white;
            line.endColor = Color.white;
        }
        line.SetPosition(1, new Vector3(rb.gameObject.transform.position.x+7, rb.gameObject.transform.position.y-3, 0));
    }

    private bool CalculateMaxDistance(float x, float y, float distance){
        if ((x * x) + (y * y) > distance) return true;
        else return false;
    }

}
