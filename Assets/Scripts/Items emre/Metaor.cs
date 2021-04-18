using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Metaor : MonoBehaviour{
    [SerializeField] private Animator boomanimate;
    [SerializeField] private float damageAmount;
    private float speed;
    public float size;
    private Rigidbody2D m_Rigidbody;
    public AudioSource audioData;
    private void Update(){
        if (CalculateMaxDistance(gameObject.transform.position.x, gameObject.transform.position.y,450)) Destroy(this.gameObject);
    }
    private void Start(){
        boomanimate.enabled = false;
        audioData = GetComponent<AudioSource>();
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.freezeRotation = true;
    }
    public void SetSpeed(float speed){
        this.speed = speed;
    }

    public float GetSpeed(){
        return this.speed;
    }

    private bool CalculateMaxDistance(float x, float y, float distance){
        if ((x * x) + (y * y) > distance) return true;
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "unit" && collision.relativeVelocity.magnitude > 3){
            boomanimate.enabled = true;
            if(!audioData.isPlaying)
            {
                audioData.Play();
            }
            Debug.Log(collision.relativeVelocity.magnitude +" "+ size);
            collision.gameObject.GetComponent<PlayerNeedSystems>().healthSystem.TakeDamage(damageAmount + (collision.relativeVelocity.magnitude*2)+(size*4));
            GetComponent<CapsuleCollider2D>().enabled = false;
            Destroy(this.gameObject, audioData.clip.length);
        }
        else
        {
            boomanimate.enabled = false;
        }
    }

}
