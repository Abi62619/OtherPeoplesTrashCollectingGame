using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawn : MonoBehaviour
{
    public float spawnDelay = 1.0f;
    public GameObject BombPrefab;

    public GameObject[] bombObjects; //list for the objects 

    void Start()
    {
        StartCoroutine(SpawnPrefabs());
    }

    IEnumerator SpawnPrefabs()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, bombObjects.Length); //picks a random object of the list 
            Vector3 randomSpawnPoint = new Vector3(Random.Range(15f, -15f), Random.Range(9f, 10f), Random.Range(-10f, 10f));
            Instantiate(bombObjects[randomIndex], randomSpawnPoint, Quaternion.identity); //instantiates the random object
            yield return new WaitForSeconds(spawnDelay);
        }
    }
    // Using the three axis xyz to make it so the bomb prefab spawns in a random point
}