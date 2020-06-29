using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToastText : MonoBehaviour
{

    float counter;
    Text newTxtText;
    private float _duration = 1f;
    public float duration
    {
        get { return _duration; }
        set { _duration = value; }
    }


    void Start()
    {
        newTxtText = GetComponent<Text>();

        
        newTxtText.enabled = true;

        counter = 0;
    }


    // Update is called once per frame
    void Update()
    {
        if (counter < duration)
        {
            counter += Time.deltaTime;
        }
        else
        {

            Destroy(gameObject);
        }
    }
}
