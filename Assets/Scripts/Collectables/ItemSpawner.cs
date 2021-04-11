using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{

    [SerializeField] private GameObject[] collectibles;
    [SerializeField] private float timeLimit;
    [SerializeField] private float spawnRadius;
    [SerializeField] private float spawnVelocity;
    [HideInInspector] public Rigidbody2D spawneeRb;
    private Metaor metaor;
    private float timeHolder = -1.5f;
    private bool canMove;

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
        if (Time.time - timeHolder > timeLimit)
        {
            timeHolder = Time.time;
            RandomSpawner();
        }
    }

    private void RandomSpawner()
    {
        int randomIndex = Random.Range(0, collectibles.Length);

        Vector3 randomPos;
        float randomXPos = Random.Range(-spawnRadius, spawnRadius); //Gets a random X position
        float randomYPos = Mathf.Sqrt(Mathf.Pow(spawnRadius,2) - Mathf.Pow(randomXPos, 2)); //Calculates Y using circle formula.
        randomPos = new Vector3(randomXPos, randomYPos);

        Quaternion randomQuat = new Quaternion(Random.Range(0,360), Random.Range(0,360),0,0);
        
        GameObject spawnee = Instantiate(collectibles[randomIndex], randomPos, randomQuat);
        spawneeRb = spawnee.GetComponent<Rigidbody2D>();
        metaor = spawnee.GetComponent<Metaor>();
        if (metaor != null){
            float x, y;
            x = Random.Range(2.5f, 4.5f);
            y = Random.Range(2.5f, 4.5f);
            spawnee.GetComponent<CapsuleCollider2D>().size = new Vector3(x / 8, y / 8, 1);
            spawnee.transform.transform.localScale = new Vector3(x, y);
            float speed = Random.Range(-spawnVelocity, spawnVelocity);
            if (speed < 0) speed = -speed;
            metaor.SetSpeed(speed);
            metaor.size = x * y / 10f ;
        }
        canMove = true;
    }

    private void FixedUpdate()
    {
        RandomMovement();
    }

    private void RandomMovement()
    {
        if (canMove && spawneeRb != null)
        {
            spawneeRb.velocity = new Vector2(Random.Range(-spawnVelocity, spawnVelocity), Random.Range(-spawnVelocity, spawnVelocity));
            CheckOutliers();
            canMove = false;
        }
    }

    private void CheckOutliers()
    {
        if ( (spawneeRb.position.y > 0 && spawneeRb.velocity.y > 0) 
             || (spawneeRb.position.y < 0 && spawneeRb.velocity.y < 0) )
        {
            spawneeRb.velocity = new Vector2(spawneeRb.velocity.x, -spawneeRb.velocity.y);
        }
        if ( (spawneeRb.position.x < 0 && spawneeRb.velocity.x < 0) 
             || (spawneeRb.position.x > 0 && spawneeRb.velocity.x > 0) )
        {
            spawneeRb.velocity = new Vector2(-spawneeRb.velocity.x, spawneeRb.velocity.y);
        }
    }
}
