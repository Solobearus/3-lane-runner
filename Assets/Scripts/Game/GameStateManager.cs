using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour
{

    GameConfigManager gameConfigManager;
    [SerializeReference]
    GameObject scoreToast;
    [SerializeReference]
    GameObject speedToast;

    private bool _playing = false;
    private bool _gameOver = false;
    private int _score = 0;
    private int _highScore;
    private float _speed = 0;

    public float speed
    {
        get { return _speed; }
        set { _speed = calculateSpeedRelativeToScore(value); }
    }

    public bool playing
    {
        get { return _playing; }
        set { _playing = value; }
    }
    public bool gameOver
    {
        get { return _gameOver; }
        set { _gameOver = value; }
    }
    public int score
    {
        get { return _score; }
        set
        {
            if (value > _highScore)
            {
                _highScore = value;
            }
            scoreToast.GetComponent<Toast>().showToast("Score +" + (value - _score), 1);
            _score = value;
        }
    }
    public int highScore
    {
        get { return _highScore; }
        set { _highScore = value; }
    }

    private void Start()
    {
        gameConfigManager = GetComponent<GameConfigManager>();
    }

    float calculateSpeedRelativeToScore(float value)
    {
        Toast toast = speedToast.GetComponent<Toast>();
        if (value < gameConfigManager.playerInitialSpeed)
        {
            toast.showToast("Speed -" + (speed - gameConfigManager.playerInitialSpeed), 1);
            return gameConfigManager.playerInitialSpeed;
        }
        else
        {
            if (value > speed)
            {
                toast.showToast("Speed +" + (value - speed), 1);
            }
            else
            {
                toast.showToast("Speed -" + (speed - value), 1);
            }
            return value;
        }
    }
}