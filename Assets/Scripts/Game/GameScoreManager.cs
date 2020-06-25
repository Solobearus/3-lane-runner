using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScoreManager : MonoBehaviour
{

    private int _score = 0;
    public int score
    {
        get { return _score; }
        set
        {
            if (value > _highScore)
            {
                _highScore = value;
            }
            _score = value;
        }
    }

    private int _highScore;
    public int highScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }


}
