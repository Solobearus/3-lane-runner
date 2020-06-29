using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    private float _size = 0f;
    public float size { 
        get { return _size; }
        set { _size = value; }
    }
    
    void Start()
    {
        int randomId = Random.Range(0, transform.childCount);
        transform.GetChild(randomId).gameObject.SetActive(true);

    }

}
