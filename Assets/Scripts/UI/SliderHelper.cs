using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHelper : MonoBehaviour
{

    [SerializeReference]
    string text;

    [SerializeReference]
    GameObject RowTitle;

    void Start()
    {
        RowTitle.GetComponent<Text>().text = text;
    }
    
}
