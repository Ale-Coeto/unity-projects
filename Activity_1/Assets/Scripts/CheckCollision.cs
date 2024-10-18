using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckCollision : MonoBehaviour
   
{

    int count = 0;
    public GameObject arrivedTxt;
    public GameObject counterTxt;

    // Check if object collides with floor object
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.GetComponent<ChangeColor>().UpdateColor();
        count += collision.gameObject.GetComponent<ChangeColor>().ToggleArrive();
        Debug.Log(count);
        
        

    }

    // Init text as not visible
    void Start()
    {
        arrivedTxt.SetActive(false);

    }

    // Checks if all objects arrived to the floor to show a text
    void Update()
    {

        if (count == 5)
        {
            Debug.Log("All have arrived");

            arrivedTxt.SetActive(true);
        }
    }

}
