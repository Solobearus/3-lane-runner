using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    CameraManager cameraManager;
    GameSpawnManager gameSpawnManager;
    GameStateManager gameStateManager;
    GameConfigManager gameConfigManager;

    [SerializeReference]
    GameObject startScreen;
    [SerializeReference]
    GameObject playingScreen;
    [SerializeReference]
    GameObject endScreen;
    [SerializeReference]
    GameObject optionsMenuScreen;
    [SerializeReference]
    Text scoreText;

    GameObject[] screens;
    void Start()
    {
        gameSpawnManager = GetComponent<GameSpawnManager>();
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();

        screens = new GameObject[] { startScreen, playingScreen, endScreen, optionsMenuScreen };

        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();

        SwitchScreen(3);
    }

    void Update()
    {
        if (gameStateManager.playing)
        {
            scoreText.GetComponent<Text>().text = "Score : " + gameStateManager.score;
        }
        else if (gameStateManager.gameOver)
        {
            SwitchScreen(2);
            gameStateManager.gameOver = false;
        }
    }

    public void SwitchScreen(int screenId)
    {
        for (int i = 0; i < screens.Length; i++)
        {
            if (i == screenId)
            {
                screens[i].SetActive(true);
            }
            else
            {
                screens[i].SetActive(false);
            }
        }
    }

    public void ResetGame()
    {
        gameSpawnManager.Restart();
    }
    public void StartGame()
    {
        gameSpawnManager.Restart();
        SwitchScreen(0);
    }





    //OPTIONS MENU MANAGER

    public void InitOptions()
    {
    }
 
    public void changeValuesToPreset(int presetId)
    {

        // gameConfigManager.cameraDistanceZ = z;
        // gameConfigManager.cameraDistanceY = y;
        // gameConfigManager.cameraRotationX = x;
    }
}
