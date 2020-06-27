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
    GameObject startUI;
    [SerializeReference]
    GameObject playingUI;
    [SerializeReference]
    GameObject endUI;
    [SerializeReference]
    GameObject OptionsUI;


    [SerializeReference]
    GameObject playingUICurrentScore;
    [SerializeReference]
    GameObject endUIFianlScore;
    [SerializeReference]
    GameObject endUIHighScore;
    [SerializeReference]
    Slider cameraDistanceZSlider;
    [SerializeReference]
    Slider cameraDistanceYSlider;
    [SerializeReference]
    Slider cameraXRotationSlider;
    [SerializeReference]
    Slider playerInitialSpeedSlider;
    [SerializeReference]
    Slider itemsPerSpawnSlider;
    [SerializeReference]
    Slider distanceBetweenObstaclesSlider;

    void Start()
    {
        gameSpawnManager = GetComponent<GameSpawnManager>();
        gameStateManager = GetComponent<GameStateManager>();
        gameConfigManager = GetComponent<GameConfigManager>();
        cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
        disablePlayingUI();
        GoToMainMenu();
    }

    void Update()
    {
        if (gameStateManager.playing)
        {
            playingUICurrentScore.GetComponent<Text>().text = "Score : " + gameStateManager.score;
        }
        else if (gameStateManager.gameOver)
        {
            GameOver();
            gameStateManager.gameOver = false;
        }
    }


    public void ResetGame()
    {
        gameSpawnManager.Restart();
    }
    public void StartGame()
    {
        gameSpawnManager.Restart();
        enablePlayingUI();
        disableStartUI();
    }
    public void GoToOptions()
    {
        disableStartUI();
        enableOptionsUI();
        InitOptions();
    }
    public void GoToMainMenu()
    {
        disableOptionsUI();
        disableEndUI();
        enableStartUI();
    }

    public void PlayAgain()
    {
        gameSpawnManager.Restart();
        enablePlayingUI();
        disableEndUI();
    }

    public void GameOver()
    {
        disablePlayingUI();
        enableEndUI();
        endUIFianlScore.GetComponent<Text>().text = "Final Score : " + gameStateManager.score;
        endUIHighScore.GetComponent<Text>().text = "High Score : " + gameStateManager.highScore;
    }

    void disableStartUI() { startUI.SetActive(false); }
    void enableStartUI() { startUI.SetActive(true); }
    void disablePlayingUI() { playingUI.SetActive(false); }
    void enablePlayingUI() { playingUI.SetActive(true); }
    void disableEndUI() { endUI.SetActive(false); }
    void enableEndUI() { endUI.SetActive(true); }
    void disableOptionsUI() { OptionsUI.SetActive(false); }
    void enableOptionsUI() { OptionsUI.SetActive(true); }


    //OPTIONS MENU MANAGER

    public void InitOptions()
    {
        cameraDistanceZSlider.value = cameraManager.cameraDistanceZ;
        cameraDistanceYSlider.value = cameraManager.cameraDistanceY;
        cameraXRotationSlider.value = cameraManager.cameraRotationX;
        playerInitialSpeedSlider.value = gameConfigManager.playerInitialSpeed;
        itemsPerSpawnSlider.value = gameConfigManager.itemsPerSpawn;
        distanceBetweenObstaclesSlider.value = gameConfigManager.distanceBetweenObstacles;
    }
    public void OnCameraZSliderChange(Slider slider)
    {
        cameraManager.cameraDistanceZ = slider.value;
    }
    public void OnCameraYSliderChange(Slider slider)
    {
        cameraManager.cameraDistanceY = slider.value;
    }
    public void OnCameraXRotationSliderChange(Slider slider)
    {
        cameraManager.cameraRotationX = slider.value;
    }
    public void OnplayerInitialSpeedSliderChange(Slider slider)
    {
        gameConfigManager.playerInitialSpeed = slider.value;
    }
    public void OnItemsPerSpawnSliderChange(Slider slider)
    {
        gameConfigManager.itemsPerSpawn = (int)slider.value;
    }
    public void OnDistanceBetweenObstaclesSliderChange(Slider slider)
    {
        gameConfigManager.distanceBetweenObstacles = slider.value;
    }
    public void Preset1Button() { changeValuesToPreset(4f, 1f, 0f); }
    public void Preset2Button() { changeValuesToPreset(-11f, 25f, 90f); }
    public void Preset3Button() { changeValuesToPreset(-0.5f, 0.5f, 0f); }
    public void Preset4Button() { changeValuesToPreset(10f, 10f, 20f); }

    public void changeValuesToPreset(float z, float y, float x)
    {
        cameraManager.cameraDistanceZ = z;
        cameraManager.cameraDistanceY = y;
        cameraManager.cameraRotationX = x;
        cameraDistanceZSlider.value = cameraManager.cameraDistanceZ;
        cameraDistanceYSlider.value = cameraManager.cameraDistanceY;
        cameraXRotationSlider.value = cameraManager.cameraRotationX;
    }

}
