using UnityEngine;

public class GameConfigManager : MonoBehaviour
{

    [SerializeReference]
    [Range(-50f, 50f)]

    private float _cameraDistanceZ = 6f;

    public const float MIN_CAMERA_DISTANCE_Z = -50f;
    public const float MAX_CAMERA_DISTANCE_Z = 50f;
    public float cameraDistanceZ
    {
        get { return _cameraDistanceZ; }
        set { _cameraDistanceZ = value; }
    }

    [SerializeReference]
    [Range(-50f, 50f)]
    private float _cameraDistanceY = 1f;


    public const float MIN_CAMERA_DISTANCE_Y = -50f;
    public const float MAX_CAMERA_DISTANCE_Y = 50f;
    public float cameraDistanceY
    {
        get { return _cameraDistanceY; }
        set { _cameraDistanceY = value; }
    }


    [SerializeReference]
    [Range(-90f, 90f)]
    private float _cameraRotationX = 0f;

    public const float MIN_CAMERA_ROTATION_X = -90f;
    public const float MAX_CAMERA_ROTATION_X = 90f;
    public float cameraRotationX
    {
        get { return _cameraRotationX; }
        set { _cameraRotationX = value; }
    }

    [SerializeReference]
    [Range(1f, 100f)]
    private float _playerInitialSpeed = 10f;

    public const float MIN_PLAYER_INITIAL_SPEED = 1f;
    public const float MAX_PLAYER_INITIAL_SPEED = 100f;
    public float playerInitialSpeed
    {
        get { return _playerInitialSpeed; }
        set { _playerInitialSpeed = value; }
    }

    [SerializeReference]
    [Range(10, 100f)]
    private float _distanceBetweenObstacles = 20f;

    public const float MIN_DISTANCE_BETWEEN_OBSTACLES = 10;
    public const float MAX_DISTANCE_BETWEEN_OBSTACLES = 100f;
    public float distanceBetweenObstacles
    {
        get { return _distanceBetweenObstacles; }
        set { _distanceBetweenObstacles = value; }
    }

    [SerializeReference]
    [Range(1, 100)]
    int _itemsPerSpawn = 10;

    public const float MIN_ITEMS_PER_SPAWN = 1;
    public const float MAX_ITEMS_PER_SPAWN = 100;
    public int itemsPerSpawn
    {
        get { return _itemsPerSpawn; }
        set { _itemsPerSpawn = value; }
    }

    [SerializeReference]
    [Range(0.1f, 2f)]
    float _speedScoreMultiplier = 0.5f;

    public const float MIN_SPEED_SCORE_MULTIPLIER = 0.1f;
    public const float MAX_SPEED_SCORE_MULTIPLIER = 10;
    public float speedScoreMultiplier
    {
        get { return _speedScoreMultiplier; }
        set { _speedScoreMultiplier = value; }
    }

    [SerializeReference]
    [Range(0.1f, 10f)]
    float _speedSubtractionFromPowerUp = 1f;

    public const float MIN_SPEED_SUBTRACTION_FROM_POWER_UP = 0.1f;
    public const float MAX_SPEED_SUBTRACTION_FROM_POWER_UP = 2f;
    public float speedSubtractionFromPowerUp
    {
        get { return _speedSubtractionFromPowerUp; }
        set { _speedSubtractionFromPowerUp = value; }
    }

    [SerializeReference]
    float _probabilityObstacle = 20f;

    public const float MIN_PROBABILITY_OBSTACLE = 0f;
    public const float MAX_PROBABILITY_OBSTACLE = 100f;
    public float probabilityObstacle
    {
        get { return _probabilityObstacle; }
        set { _probabilityObstacle = value; }
    }

    [SerializeReference]
    [Range(0f, 100f)]
    float _probabilityCoin = 10f;

    public const float MIN_PROBABILITY_COIN = 0f;
    public const float MAX_PROBABILITY_COIN = 100f;
    public float probabilityCoin
    {
        get { return _probabilityCoin; }
        set { _probabilityCoin = value; }
    }

    [SerializeReference]
    [Range(0f, 100f)]
    float _probabilitySlowPowerUp = 1f;

    public const float MIN_PROBABILITY_SLOW_POWER_UP = 0f;
    public const float MAX_PROBABILITY_SLOW_POWER_UP = 100f;
    public float probabilitySlowPowerUp
    {
        get { return _probabilitySlowPowerUp; }
        set { _probabilitySlowPowerUp = value; }
    }

    [SerializeReference]
    [Range(0f, 100f)]
    float _probabilityBigCoin = 0;

    public const float MIN_PROBABILITY_BIG_COIN = 0f;
    public const float MAX_PROBABILITY_BIG_COIN = 100f;
    public float probabilityBigCoin
    {
        get { return _probabilityBigCoin; }
        set { _probabilityBigCoin = value; }
    }

    [SerializeReference]
    [Range(1, 10)]
    int _scoreFromCoin = 1;

    public const float MIN_SCORE_FROM_COIN = 0;
    public const float MAX_SCORE_FROM_COIN = 10;
    public int scoreFromCoin
    {
        get { return _scoreFromCoin; }
        set { _scoreFromCoin = value; }
    }

    [SerializeReference]
    [Range(1, 50)]
    int _scoreFromBiggerCoin = 5;
    
    public const float MIN_SCORE_FROM_BIGGER_COIN = 1;
    public const float MAX_SCORE_FROM_BIGGER_COIN = 50;
    public int scoreFromBiggerCoin { 
        get { return _scoreFromBiggerCoin; }
        set { _scoreFromBiggerCoin = value; }
    }

    [SerializeReference]
    [Range(1, 50)]
    int _lowerSpeedFromPowerUp = 0;
    
    public const float MIN_LOWER_SPEED_FROM_POWER_UP = 1;
    public const float MAX_LOWER_SPEED_FROM_POWER_UP = 50;
    public int lowerSpeedFromPowerUp { 
        get { return _lowerSpeedFromPowerUp; }
        set { _lowerSpeedFromPowerUp = value; }
    }
}