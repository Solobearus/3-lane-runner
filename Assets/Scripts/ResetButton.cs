using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetButton : MonoBehaviour
{
    [SerializeReference]
    private GameObject _gameManager;

    private GameSpawnManager _gameSpawnManager;

    private void Start()
    {
        _gameSpawnManager = _gameManager.GetComponent<GameSpawnManager>();

    }

    public void onClick(){
        _gameSpawnManager.Restart();
    }
}
