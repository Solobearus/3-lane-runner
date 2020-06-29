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
    }
    public void showToast(string text, float duration)
    {
        GameObject newTxt = Instantiate(txt, new Vector3( transform.position.x, transform.position.y - 500f, transform.position.z), transform.rotation);
        newTxt.transform.SetParent(canvas.transform);

        newTxt.GetComponent<Text>().text = text;
        newTxt.GetComponent<ToastText>().duration = duration;
    }
}
