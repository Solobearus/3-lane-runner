using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeReference]
    private GameObject _gameManager;

    private GameSpawnManager _gameSpawnManager;
    private GameStateManager _gameStateManager;
    private GameObject[] _startUI;
    private GameObject[] _playingUI;
    private GameObject[] _endUI;

    private void Start()
    {
        _gameSpawnManager = _gameManager.GetComponent<GameSpawnManager>();
        _gameStateManager = _gameManager.GetComponent<GameStateManager>();
        _startUI = GameObject.FindGameObjectsWithTag("StartUI");
        _playingUI = GameObject.FindGameObjectsWithTag("PlayingUI");
        _endUI = GameObject.FindGameObjectsWithTag("EndUI");

        disablePlayingUI();
    }



    public void ResetGame()
    {
        _gameSpawnManager.Restart();
    }
    public void StartGame()
    {
        _gameSpawnManager.Restart();
        disableStartUI();
        enablePlayingUI();
    }

    void disableStartUI() { foreach (var item in _startUI) { item.SetActive(false); } }
    void enableStartUI() { foreach (var item in _startUI) { item.SetActive(true); } }
    void disablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(false); } }
    void enablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(true); } }
    void disableEndUI() { foreach (var item in _endUI) { item.SetActive(false); } }
    void enableEndUI() { foreach (var item in _endUI) { item.SetActive(true); } }
}
