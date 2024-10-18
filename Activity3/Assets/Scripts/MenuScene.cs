using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

// Controlador de la UI del menu principal
public class MenuScene : MonoBehaviour
{
    // Instrucciones
    public GameObject panelObject;

    // Al inicio, no mostrar instrucciones
    void Start()
    {
        panelObject.SetActive(false);
    }

    // Ir a la escena de juego
    public void StartToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Terminar el juego
    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    // Mostrar instrucciones
    public void OpenInstructions()
    {
        panelObject.SetActive(true);
    }

    // Cerrar instrucciones
    public void CloseInstructions()
    {
        panelObject.SetActive(false);
    }
}


