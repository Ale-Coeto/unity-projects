using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ending : MonoBehaviour
{
    // Script to play ending sound and enter finish text
    public Text winText;
    public SFXManager sound;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("score") >= PlayerPrefs.GetInt("PointsToWin"))
        {
            winText.text = "Congrats!";
        }

        sound.EndGame();
    }


    void RestartScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
