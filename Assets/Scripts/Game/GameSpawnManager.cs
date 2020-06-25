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
    private GameScoreManager gameScoreManager;
    private CameraManager cameraManager;

    void Start()
    {
        bookmark = BOOKMARK_START;
        gameStateManager = GetComponent<GameStateManager>();
        gameScoreManager = GetComponent<GameScoreManager>();
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
    }
    private void Update()
    {
        if (gameStateManager.playing)
        {
            var positionForSpawn = (bookmark - gameStateManager.itemsPerSpawn) * gameStateManager.distanceBetweenObstacles;

            if (currentPlayer.transform.position.z > positionForSpawn && positionForSpawn > gameStateManager.itemsPerSpawn)
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
        gameScoreManager.score = 0;
        bookmark = BOOKMARK_START;
        SpawnInitial();
    }

    void SpawnInitial()
    {
        currentPlayer = Instantiate(player, new Vector3(0, gameStateManager.heightOfSpawn, 1.8f), Quaternion.identity);
        cameraManager.Player = currentPlayer;
        SpawnNextBulk();
    }

    void SpawnNextBulk()
    {
        int i;
        for (i = bookmark; i < bookmark + gameStateManager.itemsPerSpawn; i++)
        {
            List<GameObject> line = lineSpawnRandomizer();

            for (int j = 0; j < line.Count; j++)
            {
                if (line[j] != null)
                {
                    ItemsOnRoadArray.Add(Instantiate(
                        line[j],
                        new Vector3((j - 1) * 1.75f, heightOfSpawnCalculator(line[j]), i * gameStateManager.distanceBetweenObstacles),
                        Quaternion.identity
                    ));
                }
            }
        }

        GameObject newFloor = Instantiate(floor, new Vector3(0, 0, i * gameStateManager.distanceBetweenObstacles), Quaternion.identity);
        newFloor.transform.localScale = new Vector3(newFloor.transform.localScale.x, newFloor.transform.localScale.y, gameStateManager.distanceBetweenObstacles * gameStateManager.itemsPerSpawn);
        floorsArray.Add(newFloor);


        bookmark = i;

        if (ItemsOnRoadArray.Count > gameStateManager.itemsPerSpawn * 6)
        {
            for (i = 0; i < gameStateManager.itemsPerSpawn; i++)
            {
                Destroy(ItemsOnRoadArray[i]);
            }
            ItemsOnRoadArray.RemoveRange(0, gameStateManager.itemsPerSpawn);
        }
    }

    List<GameObject> lineSpawnRandomizer()
    {
        List<GameObject> itemsLine = new List<GameObject>();
        GameObject[] itemsAvaliable = { obstacle, coin, biggerCoin, lowerSpeedPowerUp, null, };

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

        float result = gameStateManager.heightOfSpawn;

        if (item == coin)
        {
            result = gameStateManager.heightOfSpawn * 1.1f;
        }
        if (item == biggerCoin)
        {
            result = gameStateManager.heightOfSpawn * 1.4f;
        }
        return result;
    }
}
