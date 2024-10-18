using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawner de pájaros
public class Spawner : MonoBehaviour
{
    public GameObject birdGameObject;

    public float minHeight;
    public float maxHeight;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    // Iniciar la corutina
    void Start()
    {
        StartCoroutine(SpawnerTimer());
    }

    // Cada cierto tiempo, se instacía un nuevo objeto del pájaro, teniendo como valores aleatorios
    // el tiempo de espera para spawnear uno nuevo y la altura a la que comenzará (componente y)
    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax));

        Instantiate(birdGameObject, new Vector3(transform.position.x + Random.Range(-1, 1),
            transform.position.y + Random.Range(minHeight, maxHeight),
            0), Quaternion.identity);

        StartCoroutine(SpawnerTimer());

    }
}
