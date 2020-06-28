using UnityEngine;

public class CameraManager : MonoBehaviour
{


    private GameObject _player;

    GameConfigManager gameConfigManager;
    GameObject gameManager;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameConfigManager = gameManager.GetComponent<GameConfigManager>();
    }

    public GameObject Player
    {
        get { return _player; }
        set { _player = value; }
    }
    private void Update()
    {
        if (_player != null)
        {
            Vector3 newCameraPosition = new Vector3(
                _player.transform.position.x,
                _player.transform.position.y + gameConfigManager.cameraDistanceY,
                _player.transform.position.z - gameConfigManager.cameraDistanceZ
            );

            transform.position = newCameraPosition;
            transform.rotation = Quaternion.Euler(gameConfigManager.cameraRotationX, 0, 0);
        }
    }
}