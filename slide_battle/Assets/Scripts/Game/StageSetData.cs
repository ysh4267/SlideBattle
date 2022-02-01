using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class StageSetData
{
    public int stageSetLevel;
    public int givenPlayerHp;
    public StageRange stageRange;
    public SpawnerSetting enemySpawnerSetting;
    public SpawnerSetting oilSpawnerSetting;
    public SpawnerSetting pillarSpawnerSetting;
    public SpawnerSetting holeSpawnerSetting;
    public float feverTimeProbability;
}
