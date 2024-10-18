using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    // Script to control audio playing

    public AudioClip coins;
    public AudioClip endSound;

    public void GetPoints()
    {
        AudioSource.PlayClipAtPoint(coins, Camera.main.transform.position, 0.4f);

    }

    public void EndGame()
    {
        AudioSource.PlayClipAtPoint(endSound, Camera.main.transform.position, 0.4f);

    }


}
