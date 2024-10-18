using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Controlador de UI durante el juego
public class UIController : MonoBehaviour
{
    public Text timeText;
    public Sprite spentLives;
    public Image[] livesImage;
    int lives = 3;
    int time;

    // Obtener el tiempo para ganar y las vidas
    void Start()
    {
        time = GameControl.Instance.timeToWin;
        lives = PlayerPrefs.GetInt("lives", 3);
        ActiveText();
    }

    // Actualizar el tiempo
    public void ActiveText()
    {
        timeText.text = "Remaining time: " + time;
    }

    // Iniciar timer
    public void StartTimer()
    {
        StartCoroutine(MatchTime());
    }

    // Cada segundo, restar uno del tiempo y actualizar la UI. Si el tiempo es 0, ir a la escena final
    IEnumerator MatchTime() {
        yield return new WaitForSeconds(1);
        time -= 1;
        ActiveText();
        if (time == 0)
        {
            GameControl.Instance.ActiveEndScene();
        }
        else
        {
            StartCoroutine(MatchTime());
        }
    }

    // Actualizar vidas en la UI -> cambiar el sprite a uno gris
    public void UpdateLives()
    {
        lives = GameControl.Instance.GetCurrentLives();
        if (lives >= 0)
        {
            livesImage[lives].sprite = spentLives;
        }

        GameControl.Instance.checkGameOver();
    }

    // Ir al menu principal
    public void ReturnToMenu()
    {
        GameControl.Instance.GoToMenu();
    }
}
