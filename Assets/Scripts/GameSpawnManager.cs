using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{

    [Range(10f, 100f)]
    private float distanceBetweenObstacles = 20f;
    [Range(5, 100)]
    private int numberOfObstaclesPerSpawn = 10;

    [SerializeReference]
    private GameObject player;
    [SerializeReference]
    private GameObject obstacle;
    [SerializeReference]
    private GameObject coin;
    [SerializeReference]
    private GameObject floor;

    private int bookmark;
    private GameObject currentPlayer;

    List<GameObject> ItemsOnRoadArray = new List<GameObject>();
    List<GameObject> floorsArray = new List<GameObject>();
    private GameStateManager gameStateManager;
    private GameScoreManager gameScoreManager;

    void Start()
    {
        gameStateManager = GetComponent<GameStateManager>();
        gameScoreManager = GetComponent<GameScoreManager>();
        bookmark = 1;
        SpawnInitial();
    }
    private void Update()
    {
        var positionForSpawn = (bookmark - numberOfObstaclesPerSpawn) * distanceBetweenObstacles;

        if (currentPlayer.transform.position.z > positionForSpawn)
        {
            SpawnNext();
        }
    }

    public void Restart()
    {
        foreach (var item in ItemsOnRoadArray)
        {
            Destroy(item);
        }
        foreach (var item in floorsArray)
        {
            Destroy(item);
        }
        Destroy(currentPlayer);

        gameStateManager.gameOver = false;
        gameScoreManager.score = 0;
        Start();
    }

    void SpawnInitial()
    {
        SpawnNext();
        currentPlayer = Instantiate(player, new Vector3(0, 1, 0), Quaternion.identity);
    }

    void SpawnNext()
    {
        int i;
        for (i = bookmark; i < bookmark + numberOfObstaclesPerSpawn; i++)
        {
            int xPosition = Random.Range(-1, 2);

            var random = new Random();
            var randomBool = Random.Range(0, 2) == 1;

            ItemsOnRoadArray.Add(Instantiate(
                randomBool ? obstacle : coin,
                new Vector3(xPosition * 1.75f, 1, i * distanceBetweenObstacles),
                Quaternion.identity
            ));
        }

        floorsArray.Add(Instantiate(floor, new Vector3(0, 0, i * distanceBetweenObstacles), Quaternion.identity));

        bookmark = i;

        if (ItemsOnRoadArray.Count > numberOfObstaclesPerSpawn * 2)
        {
            for (i = 0; i < numberOfObstaclesPerSpawn; i++)
            {
                Destroy(ItemsOnRoadArray[i]);
            }
            ItemsOnRoadArray.RemoveRange(0, numberOfObstaclesPerSpawn);
        }
    }
}
