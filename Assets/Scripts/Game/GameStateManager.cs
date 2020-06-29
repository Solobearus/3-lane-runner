using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    GameConfigManager gameConfigManager;

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
        speed = gameConfigManager.playerInitialSpeed;
    }

    float calculateSpeedRelativeToScore(float value)
    {
        if (value < gameConfigManager.playerInitialSpeed)
        {
            return gameConfigManager.playerInitialSpeed;
        }
        else
        {
            return value;
        }
    }
}