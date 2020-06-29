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
    [SerializeReference]
    Text speedText;
    [SerializeReference]
    Slider cameraDistanseZSlider;
    [SerializeReference]
    Slider cameraDistanseYSlider;
    [SerializeReference]
    Slider cameraRotationXSlider;

    GameObject[] screens;
    void Start()
    {
        gameSpawnManager = GetComponent<GameSpawnManager>();
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();

        screens = new GameObject[] {
            startScreen,
            playingScreen,
            endScreen,
            optionsMenuScreen
        };

        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();

        SwitchScreen(0);
    }

    void Update()
    {
        if (gameStateManager.playing)
        {
            scoreText.text = "Score : " + gameStateManager.score;
            speedText.text = "Speed : " + gameStateManager.speed;
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
        SwitchScreen(1);
    }

    public void changeValuesToPreset(int presetId)
    {
        gameConfigManager.cameraDistanceZ = GameConsts.CAMERA_PRESETS[presetId, 0];
        gameConfigManager.cameraDistanceY = GameConsts.CAMERA_PRESETS[presetId, 1];
        gameConfigManager.cameraRotationX = GameConsts.CAMERA_PRESETS[presetId, 2];
        cameraDistanseZSlider.value = GameConsts.CAMERA_PRESETS[presetId, 0];
        cameraDistanseYSlider.value = GameConsts.CAMERA_PRESETS[presetId, 1];
        cameraRotationXSlider.value = GameConsts.CAMERA_PRESETS[presetId, 2];
    }
}
