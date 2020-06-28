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
        int i;
        for (i = bookmark; i < bookmark + gameConfigManager.itemsPerSpawn; i++)
        {
            List<GameObject> line = lineSpawnRandomizer();

            for (int j = 0; j < line.Count; j++)
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

    List<GameObject> lineSpawnRandomizer()
    {
        List<GameObject> itemsLine = new List<GameObject>();
        GameObject[] itemsAvaliable = { null, obstacle, coin, biggerCoin, lowerSpeedPowerUp, };

        int[] randomLine = Randomizer.lineRandomizer();

        for (int i = 0; i < randomLine.Length; i++)
        {
            Debug.Log(randomLine[i]);
            itemsLine.Add(itemsAvaliable[randomLine[i]]);
        }

        return itemsLine;
    }

    float heightOfSpawnCalculator(GameObject item)
    {

        float result = HEIGHT_OF_SPAWN;

        if (item == coin)
        {
            result = HEIGHT_OF_SPAWN * 1.1f;
        }
        if (item == biggerCoin)
        {
            result = HEIGHT_OF_SPAWN * 1.4f;
        }
        return result;
    }
}
