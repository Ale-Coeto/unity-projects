using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Efecto parallax 
public class Parallax : MonoBehaviour
{
    private float length;
    private float startpos;
    public float parallaxEffect;

    // Establecer la posicion inicial y el largo de la pantalla
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }


    // Actualizar el movimiento del fondo
    private void LateUpdate()
    {
        float temp = Camera.main.transform.position.x * (1 - parallaxEffect);
        float dist = Camera.main.transform.position.x * parallaxEffect;
        transform.position = new Vector3(startpos + dist, transform.position.y, transform.position.z);

        if (temp > startpos + length)
        {
            startpos += length;
        }
        else if (temp < startpos - length)
        {
            startpos -= length;
        }
    }
}
