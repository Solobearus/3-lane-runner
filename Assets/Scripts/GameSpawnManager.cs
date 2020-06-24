using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{



    [Range(0.6f, 10f)]
    private float heightOfSpawn = 0.6f;
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

        gameStateManager.playing = false;
        gameScoreManager.score = 0;
        Start();
    }

    void SpawnInitial()
    {
        SpawnNext();
        currentPlayer = Instantiate(player, new Vector3(0, heightOfSpawn, 1.8f), Quaternion.identity);
    }

    void SpawnNext()
    {
        int i;
        for (i = bookmark; i < bookmark + numberOfObstaclesPerSpawn; i++)
        {
            List<GameObject> line = lineSpawnRandomizer();

            for (int j = 0; j < line.Count; j++)
            {
                if (line[j] != null)
                {
                    ItemsOnRoadArray.Add(Instantiate(
                        line[j],
                        new Vector3((j - 1) * 1.75f, heightOfSpawn, i * distanceBetweenObstacles),
                        Quaternion.identity
                    ));
                }
            }
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

    List<GameObject> lineSpawnRandomizer()
    {
        List<GameObject> itemsLine = new List<GameObject>();
        int obstacleCount = 0;

        do
        {
            itemsLine.Clear();
            obstacleCount = 0;
            for (int i = 0; i < 3; i++)
            {
                var random = new Random();
                var randomItem = Random.Range(0, 3);
                GameObject item = obstacle;

                switch (randomItem)
                {
                    case 0:
                        item = null;
                        break;
                    case 1:
                        item = obstacle;
                        obstacleCount++;
                        break;
                    case 2:
                        item = coin;
                        break;
                }
                itemsLine.Add(item);
            }
        } while (obstacleCount == 3);

        return itemsLine;
    }
}
