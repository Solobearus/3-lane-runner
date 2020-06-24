using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private GameObject gameManger;
    private GameStateManager gameStateManager;
    private GameScoreManager gameScoreManager;
    private void Start()
    {
        gameManger = GameObject.Find("GameManager");
        gameStateManager = gameManger.GetComponent<GameStateManager>();
        gameScoreManager = gameManger.GetComponent<GameScoreManager>();
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameStateManager.playing = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            gameScoreManager.score += 1;
        }
    }
}
