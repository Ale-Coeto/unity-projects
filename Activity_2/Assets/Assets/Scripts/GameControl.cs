using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    // Script tp control scenes and awake 

    static public GameControl Instance;
    public GameObject birdBehaviour;
    public PlayerControl playerControl;
    public UIController uiController;
    public SFXManager sfxManager;

    public int pointsToWin = 30;

    private void Awake()
    {
        PlayerPrefs.SetInt("PointsToWin", pointsToWin);
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void checkGameOver(int _currentScore)
    {
        PlayerPrefs.SetInt("score", _currentScore);

        if (_currentScore >= pointsToWin)
        {
            ActiveEndScene();
        }
    }

    public void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void ActiveEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
}
