using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private GameSpawnManager _gameSpawnManager;
    private GameStateManager _gameStateManager;
    private GameScoreManager _gameScoreManager;
    [SerializeReference]
    private GameObject[] _startUI;
    [SerializeReference]
    private GameObject[] _playingUI;
    [SerializeReference]
    private GameObject[] _endUI;

    [SerializeReference]
    private GameObject _playingUICurrentScore;
    [SerializeReference]
    private GameObject _endUIFianlScore;
    [SerializeReference]
    private GameObject _endUIHighScore;


    private void Start()
    {
        _gameSpawnManager = GetComponent<GameSpawnManager>();
        _gameStateManager = GetComponent<GameStateManager>();
        _gameScoreManager = GetComponent<GameScoreManager>();
        disablePlayingUI();
        disableEndUI();
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

    void disableStartUI() { foreach (var item in _startUI) { item.SetActive(false); } }
    void enableStartUI() { foreach (var item in _startUI) { item.SetActive(true); } }
    void disablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(false); } }
    void enablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(true); } }
    void disableEndUI() { foreach (var item in _endUI) { item.SetActive(false); } }
    void enableEndUI() { foreach (var item in _endUI) { item.SetActive(true); } }
}
