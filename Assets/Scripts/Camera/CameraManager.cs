using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeReference]
    [Range(-50f, 50f)]
    private float _cameraDistanceZ = 6.0F;
    [SerializeReference]
    [Range(-50f, 50f)]
    private float _cameraDistanceY = 1.0F;
    [SerializeReference]
    [Range(-90f, 90f)]
    private float _cameraRotationX;
    public float cameraDistanceZ
    {
        get { return _cameraDistanceZ; }
        set { _cameraDistanceZ = value; }
    }
    public float cameraDistanceY
    {
        get { return _cameraDistanceY; }
        set { _cameraDistanceY = value; }
    }
    public float cameraRotationX { 
        get { return _cameraRotationX; }
        set { _cameraRotationX = value; }
    }
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
            transform.rotation = Quaternion.Euler(_cameraRotationX, 0, 0);
        }
    }
}