using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct LevelStruct
{
    public int[] levels;
    public int[] costs;
}

public class UpgradeCosts
{
    LevelStruct levStruct;

    public void GetDefaultStruct()
    {
        levStruct = new LevelStruct()
        {
            levels = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11 },
            costs = new int[] { 100, 250, 400, 750, 1000, 1500, 2000, 3000, 5000, 10000, 0 }
        };
    }

    public void SetCustomStrcut(int levelCount, int costInterval)
    {
        levStruct = new LevelStruct() { levels = new int[levelCount], costs = new int[levelCount] };

        for(int i = 0; i < levelCount; i++)
        {
            levStruct.levels[i] = 1 + i;
            levStruct.costs[i] = (1 + i) * costInterval;
        }
    }

    public string SetUpgradeCost()
    {
        return JsonUtility.ToJson(levStruct);
    }

    public void SetNewUpgrade(string jsonFile, LevelStruct newLev)
    {
        JsonUtility.FromJsonOverwrite(jsonFile, newLev);
    }

    public LevelStruct GetUpgrades(string jsonFile)
    {
        return JsonUtility.FromJson<LevelStruct>(jsonFile);
    }
}
