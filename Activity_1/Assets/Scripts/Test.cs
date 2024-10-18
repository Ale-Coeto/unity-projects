using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    public int int_num = 10;
    double dec_num = 3.1415;
    char letter = 'C';
    string text = "Hello world!";
    bool bol = true;
    public int edad = 20;

    // Start is called before the first frame update
    void Start() {
        //Prints
        Debug.Log("The integer is: " + int_num);
        Debug.Log("The decimal is: " + dec_num);
        Debug.Log("The letter is: " + letter);
        Debug.Log("The text is: " + text);
        Debug.Log("The bol is: " + bol);

    }

    // Update is called once per frame
    void Update() {

        if (edad >= 21)
        {
            Debug.Log("Mayor");
        } else
        {
            Debug.Log("Menor");

        }
        
    }
}
