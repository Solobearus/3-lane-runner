using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSpawnManager : MonoBehaviour
{
    [SerializeReference]
    private GameObject player;
    [SerializeReference]
    private GameObject obstacle;
    [SerializeReference]
    private GameObject coin;
    [SerializeReference]
    private GameObject biggerCoin;
    [SerializeReference]
    private GameObject lowerSpeedPowerUp;
    [SerializeReference]
    private GameObject floor;

    private int BOOKMARK_START = 1;
    private int bookmark = 0;
    private GameObject currentPlayer;

    List<GameObject> ItemsOnRoadArray = new List<GameObject>();
    List<GameObject> floorsArray = new List<GameObject>();
    private GameStateManager gameStateManager;
    private GameConfigManager gameConfigManager;
    private CameraManager cameraManager;

    void Start()
    {
        bookmark = BOOKMARK_START;
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
    }
    private void Update()
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
        currentPlayer = Instantiate(player, new Vector3(0, gameConfigManager.heightOfSpawn, 1.8f), Quaternion.identity);
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

        float result = gameConfigManager.heightOfSpawn;

        if (item == coin)
        {
            result = gameConfigManager.heightOfSpawn * 1.1f;
        }
        if (item == biggerCoin)
        {
            result = gameConfigManager.heightOfSpawn * 1.4f;
        }
        return result;
    }
}
