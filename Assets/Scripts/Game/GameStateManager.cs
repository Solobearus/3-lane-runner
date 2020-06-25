using UnityEngine;

public class GameStateManager : MonoBehaviour
{

    private bool _playing = false;
    private bool _gameOver = false;

    [SerializeReference]
    [Range(1f, 100f)] private float _playerSpeed = 10F;
    
    [Range(0.6f, 10f)]
    private float _heightOfSpawn = 0.6f;
    [SerializeReference]
    [Range(10f, 100f)]
    private float _distanceBetweenObstacles = 20f;
    [SerializeReference]
    [Range(1, 100)]
    private int _itemsPerSpawn = 10;


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

    public float heightOfSpawn
    {
        get { return _heightOfSpawn; }
        set { _heightOfSpawn = value; }
    }public float distanceBetweenObstacles
    {
        get { return _distanceBetweenObstacles; }
        set { _distanceBetweenObstacles = value; }
    }public int itemsPerSpawn
    {
        get { return _itemsPerSpawn; }
        set { _itemsPerSpawn = value; }
    }

}