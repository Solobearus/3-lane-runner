using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;

public class SliderHelper : MonoBehaviour
{

    GameObject gameManager;
    GameConfigManager gameConfigManager;

    [SerializeReference]
    string affectedVariable;
    [SerializeReference]
    Text rowTitle;
    [SerializeReference]
    Slider slider;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        rowTitle.text = CamelCaseToTitleCase(affectedVariable);
        slider.onValueChanged.AddListener(delegate { OnSliderWasChanged(); });
    }

    string CamelCaseToTitleCase(string str)
    {
        string output = Regex.Replace(str, @"[A-Z]", m => " " + m.Value.ToUpperInvariant());
        return char.ToUpperInvariant(output[0]) + output.Substring(1) + " : ";
    }

    public void OnSliderWasChanged()
    {
        var test = gameConfigManager.GetType().GetProperty(affectedVariable);
        Debug.Log(test);
        test.SetValue(gameConfigManager, slider.value);
    }
}
