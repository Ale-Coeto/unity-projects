using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Clase de fin de juego
public class GameOver : MonoBehaviour
{
    public Text resultTxt;
    public GameObject ninaSprite;
    public SFXManager sound;

    // Checar si se perdió o ganó para mostrar el mensaje y audio acorde
    void Start()
    {
        if (PlayerPrefs.GetInt("lives", 3) > 0)
        {
            SetWinAnimation();
            resultTxt.text = "Congratulations!!";
            sound.Winning();
        } else
        {
            SetLosingAnimation();
            resultTxt.text = "Game Over :(";
            sound.Losing();
        }
    }

    // Establecer animacion de ganar
    void SetWinAnimation()
    {
        ninaSprite.GetComponent<Animator>().SetTrigger("isWinning");
    }

    // Establecer animación de perder
    void SetLosingAnimation()
    {
        ninaSprite.GetComponent<Animator>().SetTrigger("isLosing");
    }

    // Ir a la escena de juego
    public void StartToPlay()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Terminar el juego
    public void ExitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false; //Para test en unity
        Application.Quit(); // Para exportar el juego y se pueda salir
    }



}
