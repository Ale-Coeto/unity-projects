using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script para controlar los eventos relacionados a los pájaros

public class BirdBehaviour : MonoBehaviour
{
    public float velocity;

    // Se agrega componente en x para que se mueva a la izq
    void Update()
    {
        this.transform.position += Vector3.left * Time.deltaTime * velocity;

        if (transform.position.x < -50)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    // En colisión, se resta una vida, suena y se destruye el objeto
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameControl.Instance.SpendLives();
            GameControl.Instance.sfxManager.Coin();
            GameObject.Destroy(this.gameObject);
            
        }
    }
}
