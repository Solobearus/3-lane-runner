using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonsManager : MonoBehaviour
{
    [SerializeReference]
    private GameObject _gameManager;

    private GameSpawnManager _gameSpawnManager;
    private GameStateManager _gameStateManager;
    [SerializeReference]
    private GameObject[] _startUI;
    [SerializeReference]
    private GameObject[] _playingUI;
    [SerializeReference]
    private GameObject[] _endUI;

    private void Start()
    {
        _gameSpawnManager = _gameManager.GetComponent<GameSpawnManager>();
        _gameStateManager = _gameManager.GetComponent<GameStateManager>();
        disablePlayingUI();
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

    void disableStartUI() { foreach (var item in _startUI) { item.SetActive(false); } }
    void enableStartUI() { foreach (var item in _startUI) { item.SetActive(true); } }
    void disablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(false); } }
    void enablePlayingUI() { foreach (var item in _playingUI) { item.SetActive(true); } }
    void disableEndUI() { foreach (var item in _endUI) { item.SetActive(false); } }
    void enableEndUI() { foreach (var item in _endUI) { item.SetActive(true); } }
}
