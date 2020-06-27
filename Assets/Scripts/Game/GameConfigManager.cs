using UnityEngine;

public class GameConfigManager : MonoBehaviour
{
    [SerializeReference]
    [Range(1f, 100f)]
    private float _playerInitialSpeed = 10F;

    [SerializeReference]
    [Range(0.6f, 10f)]
    private float _heightOfSpawn = 0.6f;
    
    [SerializeReference]
    [Range(10f, 100f)]
    private float _distanceBetweenObstacles = 20f;
    [SerializeReference]
    [Range(1, 100)]
    private int _itemsPerSpawn = 10;
    [SerializeReference]
    [Range(0.1f, 2f)]
    private float _speedScoreMultiplier = 0.5f;

    [SerializeReference]
    [Range(0.1f, 2f)]
    private int _speedSubtractionFromPowerUp = 0;

    public float playerInitialSpeed
    {
        get { return _playerInitialSpeed; }
        set { _playerInitialSpeed = value; }
    }

    public float heightOfSpawn
    {
        get { return _heightOfSpawn; }
        set { _heightOfSpawn = value; }
    }
    public float distanceBetweenObstacles
    {
        get { return _distanceBetweenObstacles; }
        set { _distanceBetweenObstacles = value; }
    }
    public int itemsPerSpawn
    {
        get { return _itemsPerSpawn; }
        set { _itemsPerSpawn = value; }
    }

    public float speedScoreMultiplier
    {
        get { return _speedScoreMultiplier; }
        set { _speedScoreMultiplier = value; }
    }
    public int speedSubtractionFromPowerUp
    {
        get { return _speedSubtractionFromPowerUp; }
        set { _speedSubtractionFromPowerUp = value; }
    }
}