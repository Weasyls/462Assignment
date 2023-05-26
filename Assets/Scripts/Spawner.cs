using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject prefab; // Oluşturulacak prefab
    public Transform spawnPosition; // Prefab'ın oluşturulacağı konum
    // Update is called once per frame
    void Start()
    {
        StartCoroutine(SpawnPrefab());
    }
    private IEnumerator SpawnPrefab()
    {
        while (true)
        {
            Instantiate(prefab, new Vector3(spawnPosition.position.x, spawnPosition.position.y, spawnPosition.position.z), prefab.transform.rotation);

            yield return new WaitForSeconds(1.5f);
        }
    }


}
