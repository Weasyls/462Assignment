using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; // The prefab to be instantiated
    public Transform spawnPosition; // The position where the prefab will be spawned

    void Start()
    {
        StartCoroutine(SpawnPrefab()); // Start spawning the prefab
    }

    private IEnumerator SpawnPrefab()
    {
        while (true) // Infinite loop to continuously spawn the prefab
        {
            // Instantiate the prefab at the specified spawn position
            Instantiate(prefab, new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), prefab.transform.rotation);

            yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds before spawning the next prefab
        }
    }
}

