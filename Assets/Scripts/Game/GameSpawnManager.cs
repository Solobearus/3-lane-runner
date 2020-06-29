using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    [SerializeReference]
    GameObject player;
    [SerializeReference]
    GameObject obstacle;
    [SerializeReference]
    GameObject coin;
    [SerializeReference]
    GameObject biggerCoin;
    [SerializeReference]
    GameObject lowerSpeedPowerUp;
    [SerializeReference]
    GameObject floor;

    float HEIGHT_OF_SPAWN = 0.6f;
    int BOOKMARK_START = 1;
    int bookmark = 0;
    GameObject currentPlayer;

    List<GameObject> ItemsOnRoadArray = new List<GameObject>();
    List<GameObject> floorsArray = new List<GameObject>();
    GameStateManager gameStateManager;
    GameConfigManager gameConfigManager;
    CameraManager cameraManager;

    List<KeyValuePair<GameObject, float>> probabilities;

    void Start()
    {
        bookmark = BOOKMARK_START;
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();



    }

    void Update()
    {
        if (gameStateManager.playing)
        {
            var positionForSpawn = (bookmark - gameConfigManager.itemsPerSpawn) * gameConfigManager.distanceBetweenObstacles;

            if (currentPlayer.transform.position.z > positionForSpawn && positionForSpawn > gameConfigManager.itemsPerSpawn)
            {
                SpawnNextBulk();
            }
        }
    }

    public void Restart()
    {
        gameStateManager.speed = gameConfigManager.playerInitialSpeed;
        
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
        gameStateManager.score = 0;
        bookmark = BOOKMARK_START;
        SpawnInitial();
    }

    void SpawnInitial()
    {
        currentPlayer = Instantiate(player, new Vector3(0, HEIGHT_OF_SPAWN, 1.8f), Quaternion.identity);
        cameraManager.Player = currentPlayer;
        SpawnNextBulk();
    }

    void SpawnNextBulk()
    {
        probabilities = new List<KeyValuePair<GameObject, float>>();

        probabilities.Add(new KeyValuePair<GameObject, float>(obstacle, gameConfigManager.probabilityObstacle));
        probabilities.Add(new KeyValuePair<GameObject, float>(coin, gameConfigManager.probabilityCoin));
        probabilities.Add(new KeyValuePair<GameObject, float>(biggerCoin, gameConfigManager.probabilityBigCoin));
        probabilities.Add(new KeyValuePair<GameObject, float>(lowerSpeedPowerUp, gameConfigManager.probabilitySlowPowerUp));

        int i;
        for (i = bookmark; i < bookmark + gameConfigManager.itemsPerSpawn; i++)
        {
            GameObject[] line = lineSpawnRandomizer();

            for (int j = 0; j < line.Length; j++)
            {
                if (line[j] != null)
                {
                    ItemsOnRoadArray.Add(Instantiate(
                        line[j],
                        new Vector3((j - 1) * 1.75f, heightOfSpawnCalculator(line[j]), i * gameConfigManager.distanceBetweenObstacles),
                        Quaternion.identity
                    ));
                }
            }
        }

        GameObject newFloor = Instantiate(floor, new Vector3(0, 0, i * gameConfigManager.distanceBetweenObstacles), Quaternion.identity);
        newFloor.transform.localScale = new Vector3(newFloor.transform.localScale.x, newFloor.transform.localScale.y, gameConfigManager.distanceBetweenObstacles * gameConfigManager.itemsPerSpawn);
        floorsArray.Add(newFloor);


        bookmark = i;

        if (ItemsOnRoadArray.Count > gameConfigManager.itemsPerSpawn * 6)
        {
            for (i = 0; i < gameConfigManager.itemsPerSpawn; i++)
            {
                Destroy(ItemsOnRoadArray[i]);
            }
            ItemsOnRoadArray.RemoveRange(0, gameConfigManager.itemsPerSpawn);
        }
    }

    GameObject[] lineSpawnRandomizer()
    {
        GameObject[] itemsLine;
        GameObject[] itemsAvaliable = { null, obstacle, coin, biggerCoin, lowerSpeedPowerUp };

        int obstacleCount = 0;

        do
        {
            obstacleCount = 0;
            itemsLine = Randomizer.lineRandomizer(probabilities);

            for (int i = 0; i < itemsLine.Length; i++)
            {
                if (itemsLine[i] == obstacle)
                    obstacleCount++;
            }

        } while (obstacleCount == 3);


        return itemsLine;
    }

    float heightOfSpawnCalculator(GameObject item)
    {

        float result = GameConsts.HEIGHT_OF_SPAWN;

        if (item == coin)
        {
            result = GameConsts.HEIGHT_OF_SPAWN * 1.1f;
        }
        if (item == biggerCoin)
        {
            result = GameConsts.HEIGHT_OF_SPAWN * 1.4f;
        }
        return result;
    }
}
