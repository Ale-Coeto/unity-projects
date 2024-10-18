using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    // Colores (publico para poder cambiarlo desde Unity)
    public Color32 PrincipalColor;
    public Color32 SecondaryColor;

    public Color32 PrincipalColorCollision;
    public Color32 SecondaryColorCollision;

    bool isActivePrincipalColor = false;
    bool hasArrived = false;

 
    // Update is called once per frame
    void Update()
    {
        // Change to Primary color when pressing P
        if (Input.GetKeyDown(KeyCode.P))
        {
            GetComponent<Renderer>().material.color = PrincipalColor;
        }

        // Change to Secondary Color when pressing S
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<Renderer>().material.color = SecondaryColor;
        }


    }


    // Toggles color to either primary or secondary collision colors
    public void UpdateColor()
    {
        if (isActivePrincipalColor)
        {
            isActivePrincipalColor = false;
            GetComponent<Renderer>().material.color = SecondaryColorCollision;
        } else
        {
            isActivePrincipalColor = true;
            GetComponent<Renderer>().material.color = PrincipalColorCollision;
        }
    }

    // Checks if the object has collided and return bool
    public int ToggleArrive()
    {
        if (hasArrived == false)
        {
            hasArrived = true;
            return 1;
        }

        
        return 0;
        
    }
}
