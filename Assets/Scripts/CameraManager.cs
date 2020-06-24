using UnityEngine;

public class CameraManager : MonoBehaviour
{

    [Range(1f, 10f)] private float cameraDistanceZ = 3.0F;
    [Range(1f, 10f)] private float cameraDistanceY = 1.0F;

    private GameObject _player;

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
                _player.transform.position.y + cameraDistanceY,
                _player.transform.position.z - cameraDistanceZ
            );

            transform.position = newCameraPosition;
        }
    }
}