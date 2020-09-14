using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public float speed;
    public GameObject player;
    public float maxSpawnTime;
    private float spawnTime;
    public Rigidbody2D enemyPrefab;
    private Vector2 spawnPos;
    
    void Start()
    {
        spawnTime = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnTimer())
        {
            Spawn();
        }
    }

    bool spawnTimer()
    {
        spawnTime -= Time.deltaTime;
        if (spawnTime < 0)
        {
            spawnTime = Random.Range(1, maxSpawnTime);
            return true;
        }
        else
        {
            return false;
        }
    }
        

    //function to instantiate enemies at random locations within the bounds of the game object the script is attached to
    void Spawn()
    {
        Rigidbody2D clone;
        //gets the size of the object based of the SpriteRenderer size and then multiplies it by its local scale
        Vector2 objectSize = Vector2.Scale(GetComponent<MeshRenderer>().bounds.size, transform.localScale);

        //Picks a random spawn point within the bounds of the gameobject
        spawnPos = new Vector2(transform.position.x, transform.position.y) + new Vector2(Random.Range(-objectSize.x / 2, objectSize.x / 2), Random.Range(-objectSize.y / 2, objectSize.y / 2));

        clone = Instantiate(enemyPrefab, spawnPos, GetComponent<Transform>().rotation);

        Vector3 normalized = Vector3.Normalize(player.transform.position - clone.gameObject.transform.position);

        clone.velocity = normalized * speed;
    }
}
