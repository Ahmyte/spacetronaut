using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftMaterial : MonoBehaviour{

    public enum itemType{
        Stone,
        Coal,
        Iron,
        Steel,
        Carbon,
        Torch,
        Wood,
        Can,
        MoonStone
    }

    public itemType type;
    private Rigidbody2D m_Rigidbody;
    public AudioSource audioData;

    private void Update(){
        if (CalculateMaxDistance(gameObject.transform.position.x, gameObject.transform.position.y, 450)) Destroy(this.gameObject);
    }
    private bool CalculateMaxDistance(float x, float y, float distance){
        if ((x * x) + (y * y) > distance) return true;
        else return false;
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.name == "unit"){
            collision.gameObject.GetComponent<PlayerInventory>().Add(this);
            Destroy(this.gameObject.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject.GetComponent<CapsuleCollider2D>());
            if (!audioData.isPlaying)
                audioData.Play();
            Destroy(this.gameObject, audioData.clip.length);
        }
    }

    private void Start(){
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_Rigidbody.freezeRotation = true;
        if(this.type == itemType.MoonStone){
            if(Random.Range(0, 3) != 1) Destroy(this.gameObject);
        }
    }

}
