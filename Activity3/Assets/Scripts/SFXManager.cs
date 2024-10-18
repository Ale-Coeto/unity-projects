using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controlador de sonidos
public class SFXManager : MonoBehaviour
{
    public AudioClip coins;
    public AudioClip win;
    public AudioClip lose;

    // Moneda
    public void Coin()
    {
        AudioSource.PlayClipAtPoint(coins, Camera.main.transform.position, 0.3f);
    }

    // Ganar
    public void Winning()
    {
        AudioSource.PlayClipAtPoint(win, Camera.main.transform.position, 0.3f);
    }

    // Perder 
    public void Losing()
    {
        AudioSource.PlayClipAtPoint(lose, Camera.main.transform.position, 0.3f);
    }

}
