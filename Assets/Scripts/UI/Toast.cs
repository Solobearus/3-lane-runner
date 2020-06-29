using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toast : MonoBehaviour
{
    [SerializeReference]
    GameObject txt;
    GameObject canvas;


    Color initialColor;
    private void Start()
    {
        canvas = GameObject.Find("Canvas");
        Debug.Log(canvas);
    }
    public void showToast(string text, float duration)
    {
        GameObject newTxt = Instantiate(txt, transform.position, transform.rotation);
        canvas = GameObject.Find("Canvas");

        newTxt.transform.SetParent(canvas.transform);

        newTxt.GetComponent<Text>().text = text;
        newTxt.GetComponent<ToastText>().duration = duration;
    }
}
