using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Spawner de plataformas
public class SpawnerPlatform : MonoBehaviour
{
    // Plataformas y lista
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;
    private List<GameObject> gameObjectsList = new List<GameObject>();

    public float minHeight;
    public float maxHeight;
    public float timeToSpawnMin;
    public float timeToSpawnMax;

    // Iniciar la lista con las plataformas y empezar la rutina
    void Start()
    {
        gameObjectsList.Add(platform1);
        gameObjectsList.Add(platform2);
        gameObjectsList.Add(platform3);
        StartCoroutine(SpawnerTimer());
    }

    // Cada cierto tiempo se elige una plataforma y se agrega al juego como obstáculo o ayuda para el jugador
    // Establece la posición inicial en x e y aleatoria y también cada tiempo aleatorio (dependiendo de los inputs)
    IEnumerator SpawnerTimer()
    {
        yield return new WaitForSeconds(Random.Range(timeToSpawnMin, timeToSpawnMax));


        int randomNumber = Random.Range(0, 3);

        Instantiate(gameObjectsList[randomNumber], new Vector3(transform.position.x, transform.position.y +
            Random.Range(minHeight, maxHeight), 0), Quaternion.identity);



        StartCoroutine(SpawnerTimer());


    }
}
