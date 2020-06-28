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

    bool _isInt = false;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        gameConfigManager = gameManager.GetComponent<GameConfigManager>();

        var valueFromConfig = gameConfigManager.GetType().GetProperty(affectedVariable).GetValue(gameConfigManager, null);

        if (valueFromConfig is int)
        {
            slider.value = (int)valueFromConfig;
            slider.wholeNumbers = true;
            _isInt = true;
            rowTitle.text = CamelCaseToTitleCase(affectedVariable) + " : " + slider.value;
        }
        else
        {
            slider.value = (float)valueFromConfig;
            rowTitle.text = CamelCaseToTitleCase(affectedVariable) + " : " + slider.value.ToString("0.00");
        }

        string constCase = CamelCaseToConstCase(affectedVariable);

        slider.onValueChanged.AddListener(delegate { OnSliderWasChanged(); });

        float minValue = (float)gameConfigManager.GetType().GetField("MIN_" + constCase).GetValue(gameConfigManager);
        float maxValue = (float)gameConfigManager.GetType().GetField("MAX_" + constCase).GetValue(gameConfigManager);

        slider.minValue = minValue;
        slider.maxValue = maxValue;
    }

    public void OnSliderWasChanged()
    {
        if (_isInt)
        {
            gameConfigManager.GetType().GetProperty(affectedVariable).SetValue(gameConfigManager, (int)slider.value);
            rowTitle.text = CamelCaseToTitleCase(affectedVariable) + " : " + slider.value;
        }
        else
        {
            gameConfigManager.GetType().GetProperty(affectedVariable).SetValue(gameConfigManager, slider.value);
            rowTitle.text = CamelCaseToTitleCase(affectedVariable) + " : " + slider.value.ToString("0.00");
        }

    }


    string CamelCaseToTitleCase(string str)
    {
        string output = Regex.Replace(str, @"[A-Z]", m => " " + m.Value.ToUpper());
        output = char.ToUpper(output[0]) + output.Substring(1);

        return output;
    }

    string CamelCaseToConstCase(string str)
    {
        string output = Regex.Replace(str, @"[A-Z]", m => "_" + m.Value.ToUpper());
        output = Regex.Replace(output, @"[a-z]", m => m.Value.ToUpper());
        return output;
    }
}
