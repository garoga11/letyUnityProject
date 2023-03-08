using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectsSpawning : MonoBehaviour
{
    public GameObject fungoPrefab;
    public GameObject applePrefab;
    public GameObject ratPrefab;
    public GameObject lizardPrefab;
    public Collider floorCollider;
    public int fungoSpawnLimit = 10;
    public int appleSpawnLimit = 15;
    public int ratSpawnLimit = 5;
    public int lizardSpawnLimit = 3;
    
    private List<GameObject> spawnedObjects = new List<GameObject>();

    void Start(){

         // Spawn the initial objects
        for (int i = 0; i < fungoSpawnLimit; i++)
        {
            SpawnObject(fungoPrefab, 5);
        }
        for (int i = 0; i < appleSpawnLimit; i++)
        {
            SpawnObject(applePrefab, 1);
        }
        for (int i = 0; i < ratSpawnLimit; i++)
        {
            SpawnObject(ratPrefab, 1);
        }
        for (int i = 0; i < lizardSpawnLimit; i++)
        {
            SpawnObject(lizardPrefab, 1);
        }
    }

    void SpawnObject(GameObject objectPreFab, int y){
        // Get the bounds of the floor collider
        Vector3 floorSize = floorCollider.bounds.size;
        Vector3 floorCenter = floorCollider.bounds.center;

        // Generate a random position on the floor
        float x = Random.Range(floorCenter.x - floorSize.x / 2, floorCenter.x + floorSize.x / 2);
        float z = Random.Range(floorCenter.z - floorSize.z / 2, floorCenter.z + floorSize.z / 2);
                
        Vector3 spawnPosition = new Vector3(x, y, z);

        // Spawn the object at the random position
        GameObject newObject = Instantiate(objectPreFab, spawnPosition, Quaternion.identity);
        spawnedObjects.Add(newObject);
    }

    // Detect collision between the player and spawned objects
    void OnTriggerEnter(Collider other)
    {
        // Get the tag of the current game object that is using this script
        string currentObjectTag = transform.gameObject.tag;

        //Adding points to the score depending on the object
        if (gameObject.CompareTag("Fungo")){
            SpawnObject(fungoPrefab, 5);
            
        } else if (gameObject.CompareTag("Apple")){
            SpawnObject(applePrefab, 1);

        }else if (gameObject.CompareTag("Rat")){
            SpawnObject(ratPrefab, 1);

        }else if (gameObject.CompareTag("Lizard")){
            SpawnObject(lizardPrefab, 1);

        }
    
    }

    // Update is called once per frame
    void Update(){
        // Check if we have less than the desired number of objects, spawn a new one
        if (spawnedObjects.Count < fungoSpawnLimit)
        {
            SpawnObject(fungoPrefab, 5);
        }

        if (spawnedObjects.Count < appleSpawnLimit)
        {
            SpawnObject(applePrefab, 1);
        }

        if (spawnedObjects.Count < ratSpawnLimit)
        {
            SpawnObject(ratPrefab, 1);
        }

        if (spawnedObjects.Count < lizardSpawnLimit)
        {
            SpawnObject(lizardPrefab, 1);
        }
        
    }

   
}
