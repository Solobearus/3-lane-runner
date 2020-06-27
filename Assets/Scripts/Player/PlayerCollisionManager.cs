using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionManager : MonoBehaviour
{
    GameObject gameManager;
    GameStateManager gameStateManager;
    GameConfigManager gameConfigManager;

    //TODO move everything to config manager
    int SCORE_FROM_COIN = 1;
    int SCORE_FROM_BIGGER_COIN = 10;
    int LOWER_SPEED_FROM_POWER_UP = 4;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameStateManager = gameManager.GetComponent<GameStateManager>();
        gameConfigManager = gameManager.GetComponent<GameConfigManager>();
    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            gameStateManager.playing = false;
            gameStateManager.gameOver = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            gameStateManager.score += SCORE_FROM_COIN;
        }
        if (other.gameObject.tag == "BiggerCoin")
        {
            gameStateManager.score += SCORE_FROM_BIGGER_COIN;
        }
        if (other.gameObject.tag == "lowerSpeedPowerUp")
        {
            gameConfigManager.speedSubtractionFromPowerUp += LOWER_SPEED_FROM_POWER_UP;
        }
    }
}
