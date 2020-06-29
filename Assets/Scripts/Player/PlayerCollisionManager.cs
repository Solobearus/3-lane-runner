using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCollisionManager : MonoBehaviour
{
    GameObject gameManager;
    GameStateManager gameStateManager;
    GameConfigManager gameConfigManager;


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
            gameStateManager.score += gameConfigManager.scoreFromCoin;
            gameStateManager.speed += gameConfigManager.scoreFromCoin * gameConfigManager.speedScoreMultiplier;

        }
        if (other.gameObject.tag == "BiggerCoin")
        {
            gameStateManager.score += gameConfigManager.scoreFromBiggerCoin;
            gameStateManager.speed += gameConfigManager.scoreFromBiggerCoin * gameConfigManager.speedScoreMultiplier;
        }
        if (other.gameObject.tag == "lowerSpeedPowerUp")
        {
            gameStateManager.speed -= gameConfigManager.lowerSpeedFromPowerUp;
        }
    }



    
}
