using System.Collections;
using System.Collections.Generic;
using UnityEngine;

static public class Randomizer
{
    static int[] probabilities = { 40, 21, 2, 2 };
    static public int[] lineRandomizer()
    {
        int[] randomizedLine = new int[3];
        int obstacleCount = 0;

        do
        {
            obstacleCount = 0;
            for (int i = 0; i < 3; i++)
            {
                int randomItem = Random.Range(1, 101);
                int item = 0;

                if (randomItem < probabilities[0])
                {
                    item = 1;
                    obstacleCount++;
                }
                else if (randomItem < probabilities[0] + probabilities[1])
                {
                    item = 2;
                }
                else if (randomItem < probabilities[0] + probabilities[1] + probabilities[2])
                {
                    item = 3;
                }
                else
                {
                    item = 0;
                }

                randomizedLine[i] = item;
            }
        } while (obstacleCount == 3);

        return randomizedLine;
    }
}