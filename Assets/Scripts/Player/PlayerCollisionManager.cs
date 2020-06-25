using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    private GameObject gameManger;
    private GameStateManager gameStateManager;
    private GameScoreManager gameScoreManager;

    int SCORE_FROM_COIN = 1;
    int SCORE_FROM_BIGGER_COIN = 10;
    int LOWER_SPEED_FROM_POWER_UP = 4;
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
            gameStateManager.playing = false;
            gameStateManager.gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            gameScoreManager.score += SCORE_FROM_COIN;
        }
        if (other.gameObject.tag == "BiggerCoin")
        {
            gameScoreManager.score += SCORE_FROM_BIGGER_COIN;
        }
        if (other.gameObject.tag == "lowerSpeedPowerUp")
        {
            gameStateManager.speedSubtractionFromPowerUp += LOWER_SPEED_FROM_POWER_UP;
        }
    }
}
