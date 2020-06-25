using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private CameraManager _cameraManager;
    private GameSpawnManager _gameSpawnManager;
    private GameStateManager _gameStateManager;
    private GameScoreManager _gameScoreManager;

    [SerializeReference]
    private GameObject _startUI;
    [SerializeReference]
    private GameObject _playingUI;
    [SerializeReference]
    private GameObject _endUI;
    [SerializeReference]
    private GameObject _OptionsUI;


    [SerializeReference]
    private GameObject _playingUICurrentScore;
    [SerializeReference]
    private GameObject _endUIFianlScore;
    [SerializeReference]
    private GameObject _endUIHighScore;
    [SerializeReference]
    private Slider _cameraDistanceZSlider;
    [SerializeReference]
    private Slider _cameraDistanceYSlider;
    [SerializeReference]
    private Slider _cameraXRotationSlider;
    [SerializeReference]
    private Slider _playerSpeedSlider;

    private void Start()
    {
        _gameSpawnManager = GetComponent<GameSpawnManager>();
        _gameStateManager = GetComponent<GameStateManager>();
        _gameScoreManager = GetComponent<GameScoreManager>();
        _cameraManager = GameObject.Find("MainCamera").GetComponent<CameraManager>();
        disablePlayingUI();
        GoToMainMenu();
    }

    private void Update()
    {
        if (_gameStateManager.playing)
        {
            _playingUICurrentScore.GetComponent<Text>().text = "Score : " + _gameScoreManager.score;
        }
        else if (_gameStateManager.gameOver)
        {
            GameOver();
            _gameStateManager.gameOver = false;
        }
    }


    public void ResetGame()
    {
        _gameSpawnManager.Restart();
    }
    public void StartGame()
    {
        _gameSpawnManager.Restart();
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
        _gameSpawnManager.Restart();
        enablePlayingUI();
        disableEndUI();
    }

    public void GameOver()
    {
        disablePlayingUI();
        enableEndUI();
        _endUIFianlScore.GetComponent<Text>().text = "Final Score : " + _gameScoreManager.score;
        _endUIHighScore.GetComponent<Text>().text = "High Score : " + _gameScoreManager.highScore;
    }

    void disableStartUI() { _startUI.SetActive(false); }
    void enableStartUI() { _startUI.SetActive(true); }
    void disablePlayingUI() { _playingUI.SetActive(false); }
    void enablePlayingUI() { _playingUI.SetActive(true); }
    void disableEndUI() { _endUI.SetActive(false); }
    void enableEndUI() { _endUI.SetActive(true); }
    void disableOptionsUI() { _OptionsUI.SetActive(false); }
    void enableOptionsUI() { _OptionsUI.SetActive(true); }


    //OPTIONS MENU MANAGER

    public void InitOptions()
    {
        _cameraDistanceZSlider.value = _cameraManager.cameraDistanceZ;
        _cameraDistanceYSlider.value = _cameraManager.cameraDistanceY;
        _cameraXRotationSlider.value = _cameraManager.cameraRotationX;
        _playerSpeedSlider.value = _gameStateManager.playerSpeed;
    }
    public void OnCameraZSliderChange(Slider slider)
    {
        _cameraManager.cameraDistanceZ = slider.value;
    }
    public void OnCameraYSliderChange(Slider slider)
    {
        _cameraManager.cameraDistanceY = slider.value;
    }
    public void OnCameraXRotationSliderChange(Slider slider)
    {
        _cameraManager.cameraRotationX = slider.value;
    }
    public void OnPlayerSpeedSliderChange(Slider slider)
    {
        _gameStateManager.playerSpeed = slider.value;
    }


    public void Preset1Button() { changeValuesToPreset(4f, 1f, 0f); }
    public void Preset2Button() { changeValuesToPreset(-11f, 25f, 90f); }
    public void Preset3Button() { changeValuesToPreset(-0.5f, 0.5f, 0f); }
    public void Preset4Button() { changeValuesToPreset(10f, 10f, 20f); }

    public void changeValuesToPreset(float z, float y, float x)
    {
        _cameraManager.cameraDistanceZ = z;
        _cameraManager.cameraDistanceY = y;
        _cameraManager.cameraRotationX = x;
        _cameraDistanceZSlider.value = _cameraManager.cameraDistanceZ;
        _cameraDistanceYSlider.value = _cameraManager.cameraDistanceY;
        _cameraXRotationSlider.value = _cameraManager.cameraRotationX;
    }

}
