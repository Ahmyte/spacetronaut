using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour{

    [SerializeField] private float restoreAmount;
    private Rigidbody2D m_Rigidbody;

    private void Update(){
        if (CalculateMaxDistance(gameObject.transform.position.x, gameObject.transform.position.y, 450)) Destroy(this.gameObject);
    }
    private bool CalculateMaxDistance(float x, float y, float distance){
        if ((x * x) + (y * y) > distance) return true;
        else return false;
    }
    private void Start(){

        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.freezeRotation = true;
    }
    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "unit"){
            collision.gameObject.GetComponent<PlayerNeedSystems>().hungerSystem.Eat(restoreAmount);
            Destroy(this.gameObject);
        }
    }
}
