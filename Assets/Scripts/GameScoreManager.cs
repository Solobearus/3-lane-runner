using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreManager : MonoBehaviour
{

    [SerializeReference]
    private Text scoreUI;
    private int _score = 0;
    public int score
    {
        get { return _score; }
        set { _score = value; }
    }


    private void Update()
    {
        scoreUI.text = "Score : " + _score;
    }
}
