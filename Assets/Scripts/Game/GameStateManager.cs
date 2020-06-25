using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private bool _playing = false;
    private bool _gameOver = false;

    [SerializeReference]
    [Range(1f, 100f)] private float _playerSpeed = 10F;

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
    public float playerSpeed
    {
        get { return _playerSpeed; }
        set { _playerSpeed = value; }
    }

}