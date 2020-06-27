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
    // [SerializeReference]
    // GameObject endUIFianlScore;
    // [SerializeReference]
    // GameObject endUIHighScore;
    // [SerializeReference]
    // Slider cameraDistanceZSlider;
    // [SerializeReference]
    // Slider cameraDistanceYSlider;
    // [SerializeReference]
    // Slider cameraXRotationSlider;
    // [SerializeReference]
    // Slider playerInitialSpeedSlider;
    // [SerializeReference]
    // Slider itemsPerSpawnSlider;
    // [SerializeReference]
    // Slider distanceBetweenObstaclesSlider;

    void Start()
    {
        gameSpawnManager = GetComponent<GameSpawnManager>();
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();

        screens = new GameObject[] { startScreen, playingScreen, endScreen, optionsMenuScreen };

        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();

        SwitchScreen(0);
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
        //     cameraDistanceZSlider.value = cameraManager.cameraDistanceZ;
        //     cameraDistanceYSlider.value = cameraManager.cameraDistanceY;
        //     cameraXRotationSlider.value = cameraManager.cameraRotationX;
        //     playerInitialSpeedSlider.value = gameConfigManager.playerInitialSpeed;
        //     itemsPerSpawnSlider.value = gameConfigManager.itemsPerSpawn;
        //     distanceBetweenObstaclesSlider.value = gameConfigManager.distanceBetweenObstacles;
    }
    // public void OnCameraZSliderChange(Slider slider)
    // {
    //     cameraManager.cameraDistanceZ = slider.value;
    // }
    // public void OnCameraYSliderChange(Slider slider)
    // {
    //     cameraManager.cameraDistanceY = slider.value;
    // }
    // public void OnCameraXRotationSliderChange(Slider slider)
    // {
    //     cameraManager.cameraRotationX = slider.value;
    // }
    // public void OnplayerInitialSpeedSliderChange(Slider slider)
    // {
    //     gameConfigManager.playerInitialSpeed = slider.value;
    // }
    // public void OnItemsPerSpawnSliderChange(Slider slider)
    // {
    //     gameConfigManager.itemsPerSpawn = (int)slider.value;
    // }
    // public void OnDistanceBetweenObstaclesSliderChange(Slider slider)
    // {
    //     gameConfigManager.distanceBetweenObstacles = slider.value;
    // }
    // public void Preset1Button() { changeValuesToPreset(4f, 1f, 0f); }
    // public void Preset2Button() { changeValuesToPreset(-11f, 25f, 90f); }
    // public void Preset3Button() { changeValuesToPreset(-0.5f, 0.5f, 0f); }
    // public void Preset4Button() { changeValuesToPreset(10f, 10f, 20f); }

    public void changeValuesToPreset(float z, float y, float x)
    {
        cameraManager.cameraDistanceZ = z;
        cameraManager.cameraDistanceY = y;
        cameraManager.cameraRotationX = x;
        // cameraDistanceZSlider.value = cameraManager.cameraDistanceZ;
        // cameraDistanceYSlider.value = cameraManager.cameraDistanceY;
        // cameraXRotationSlider.value = cameraManager.cameraRotationX;
    }

}
