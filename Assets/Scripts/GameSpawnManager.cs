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
    void Start()
    {
        bookmark = 1;
        SpawnInitial();
    }
    private void Update()
    {
        var positionForSpawn = (bookmark - (numberOfObstaclesPerSpawn / 2)) * distanceBetweenObstacles;

        if (currentPlayer.transform.position.z > positionForSpawn)
        {
            SpawnNext();
        }
    }

    void Restart()
    {
        foreach (var item in ItemsOnRoadArray)
        {
            Destroy(item);
        }
        Destroy(player);

        SpawnInitial();
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
            int xPosition = Random.Range(-1, 1);

            var random = new Random();
            var randomBool = Random.Range(0, 2) == 1;

            ItemsOnRoadArray.Add(Instantiate(
                randomBool ? obstacle : coin,
                new Vector3(xPosition * 1.75f, 1, i * distanceBetweenObstacles),
                Quaternion.identity
            ));
        }

        Instantiate(floor, new Vector3(0, 0, i * distanceBetweenObstacles), Quaternion.identity);

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
