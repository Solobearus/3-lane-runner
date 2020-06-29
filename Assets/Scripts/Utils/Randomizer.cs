using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Randomizer
{

    static public GameObject[] lineRandomizer(List<KeyValuePair<GameObject, float>> probabilities)
    {
        GameObject[] randomizedLine = new GameObject[3];

        for (int i = 0; i < randomizedLine.Length; i++)
        {
            randomizedLine[i] = generateItem(probabilities);
        }
        return randomizedLine;
    }

    static GameObject generateItem(List<KeyValuePair<GameObject, float>> probabilities)
    {
        float randomItem = Random.Range(0, 100);
        float currentProbability = 0;

        foreach (KeyValuePair<GameObject, float> entry in probabilities)
        {
            currentProbability += entry.Value;
            
            if (currentProbability > randomItem)
                return entry.Key;
        }

        return null;
    }
}