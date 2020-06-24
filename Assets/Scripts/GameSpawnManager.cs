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

    private int BOOKMARK_START = 1;
    private int bookmark = 0;
    private GameObject currentPlayer;

    List<GameObject> ItemsOnRoadArray = new List<GameObject>();
    List<GameObject> floorsArray = new List<GameObject>();
    private GameStateManager gameStateManager;
    private GameScoreManager gameScoreManager;

    void Start()
    {
        bookmark = BOOKMARK_START;
        gameStateManager = GetComponent<GameStateManager>();
        gameScoreManager = GetComponent<GameScoreManager>();
    }
    private void Update()
    {
        if (gameStateManager.playing)
        {
            var positionForSpawn = (bookmark - numberOfObstaclesPerSpawn) * distanceBetweenObstacles;

            if (currentPlayer.transform.position.z > positionForSpawn && positionForSpawn> numberOfObstaclesPerSpawn)
            {
                Debug.Log("wtf");
                Debug.Log(bookmark);
                SpawnNextBulk();
            }
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

        gameStateManager.playing = true;
        gameScoreManager.score = 0;
        bookmark = BOOKMARK_START;
        SpawnInitial();
    }

    void SpawnInitial()
    {
        currentPlayer = Instantiate(player, new Vector3(0, heightOfSpawn, 1.8f), Quaternion.identity);
        SpawnNextBulk();
    }

    void SpawnNextBulk()
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

        if (ItemsOnRoadArray.Count > numberOfObstaclesPerSpawn * 6)
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
