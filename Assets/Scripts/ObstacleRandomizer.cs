using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRandomizer : MonoBehaviour
{
    // Start is called before the first frame update
    private float _size = 0f;
    public float size
    {
        get { return _size; }
        set { _size = value; }
    }

    void Start()
    {
        int probabilityGroupId = Random.Range(0, 100);

        if (probabilityGroupId > 25)
        {
            GameObject group = transform.GetChild(0).gameObject;

            int randomId = Random.Range(0, group.transform.childCount);

            group.transform.GetChild(randomId).gameObject.SetActive(true);
        }
        else
        {
            GameObject group = transform.GetChild(1).gameObject;

            int randomId = Random.Range(0, group.transform.childCount);

            group.transform.GetChild(randomId).gameObject.SetActive(true);
        }

    }

}
