using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    // Script tp control UI
    public Text ammountPoints;
    string ammountText = "Points: ";
    int currentScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        ActivateScore();
    }

    public void ActivateScore()
    {
        ammountPoints.text = ammountText + "--";
        
    }

    public void AddPoints(int _points)
    {
        currentScore += _points;
        PrintScore();
    }

    public void PrintScore()
    {
        ammountPoints.text = ammountText + currentScore.ToString();
        GameControl.Instance.checkGameOver(currentScore);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
