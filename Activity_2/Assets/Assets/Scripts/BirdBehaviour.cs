using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehaviour : MonoBehaviour
{
    // Script to manage events related to birds


    // Start is called before the first frame update
    public BirdName nameBird = BirdName.blue;

    public enum BirdName
    {
        blue, chicken, chick, eagle, owl
    }

    [Range(0, 10)] public int points = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // On collision with bird
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy bird and add points
            GameObject.Destroy(this.gameObject);
            GameControl.Instance.uiController.AddPoints(points);
            GameControl.Instance.sfxManager.GetPoints();
            
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
