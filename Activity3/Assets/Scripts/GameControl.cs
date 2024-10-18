using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que controla varios aspectos del juego
public class GameControl : MonoBehaviour
{

    // Clases requeridas
    static public GameControl Instance;
    public UIController uiController;
    public SFXManager sfxManager;

    // Variable de tiempo
    public int timeToWin;

    // Al comenzar, se establecen las variables iniciales y se hace la instancia del controlador
    private void Awake()
    {
        StopAllCoroutines();
        PlayerPrefs.SetInt("lives", 3);
        PlayerPrefs.SetInt("timeToWin", PlayerPrefs.GetInt("timeToWin", timeToWin));
        Instance = this;
        Instance.SetReferences();
        DontDestroyOnLoad(this.gameObject);

    }

    // Se establecen las referencias a las demas clases
    void SetReferences()
    {
        if (uiController == null)
        {
            uiController = FindObjectOfType<UIController>();
        }
        if (sfxManager == null)
        {
            sfxManager = FindObjectOfType<SFXManager>();
        }
        timeToWin = PlayerPrefs.GetInt("timeToWin", 15);
        init();
    }

    // Iniciar el timer
    private void init()
    {
        if (uiController != null)
        {
            uiController.StartTimer();
        }
    }

    // Obtener el número de vidas actuales
    public int GetCurrentLives()
    {
        return PlayerPrefs.GetInt("lives", 3);
    }

    // Restar una vida
    public void SpendLives()
    {
        int newLives = GetCurrentLives() - 1;
        PlayerPrefs.SetInt("lives", newLives);
        uiController.UpdateLives();
    }

    // Checar si las vidas son 0 -> estado de perder
    public void checkGameOver()
    {
        PlayerPrefs.GetInt("lives", 3);
        if (PlayerPrefs.GetInt("lives", 3) == 0)
        {
            ActiveEndScene();
        }
    }

    // Ir a la escena final
    public void ActiveEndScene() {
        SceneManager.LoadScene("ExitScene"); 
    }

    // Reiniciar la escena (juego)
    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Ir al menu principal
    public void GoToMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    
}
