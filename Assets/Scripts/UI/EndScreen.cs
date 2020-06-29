using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeReference]
    GameObject gameManager;
    GameStateManager gameStateManager;
    [SerializeReference]
    Text finalScore;
    [SerializeReference]
    Text highScore;

    private void OnEnable()
    {
        gameStateManager = gameManager.GetComponent<GameStateManager>();

        finalScore.text = "Final Score : " + gameStateManager.score;
        highScore.text = "High Score : " + gameStateManager.highScore;
    }
}
