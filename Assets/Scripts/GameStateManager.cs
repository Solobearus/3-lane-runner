using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private bool _playing = false;
    private bool _gameOver = false;
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

}