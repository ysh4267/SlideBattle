using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    int currentLevel;
    StageSetData currentStage;
    ObjectSpawner[] spawners;

    private void Start() {
        currentLevel = 1;
        currentStage =  GetProperStageSet(currentLevel);
        spawners = GetComponents<ObjectSpawner>();
        SetUpSpawners();
    }
    
    public void LevelUpStage() {
        currentLevel += 1;
        currentStage = GetProperStageSet(currentLevel);
    }

    public void SetUpSpawners() {
        foreach (ObjectSpawner spawner in spawners) {
            switch (spawner.spawnerSetting.SPAWN_OBJECT_TYPE) {
                case ENUM_SPAWN_OBJECT.SPAWN_ENEMY:
                    spawner.spawnerSetting = currentStage.enemySpawnerSetting;
                    break;
                case ENUM_SPAWN_OBJECT.SPAWN_HOLE:
                    spawner.spawnerSetting = currentStage.holeSpawnerSetting;
                    break;
                case ENUM_SPAWN_OBJECT.SPAWN_OIL:
                    spawner.spawnerSetting = currentStage.oilSpawnerSetting;
                    break;
                case ENUM_SPAWN_OBJECT.SPAWN_PILLAR:
                    spawner.spawnerSetting = currentStage.pillarSpawnerSetting;
                    break;
                default:
                    break;
            }

        }
    }

    private StageSetData GetProperStageSet(int currentLevel) {
        List<StageSetData> stageSet = StageSetDataContainer.GetInstance().GetStageSetClone();

        foreach(StageSetData stageSetData in stageSet) {
            if(isStageSetContainsCurrentLevel(currentLevel, stageSetData)) {
                return stageSetData;
            }
        }

        return null;
    }

    private bool isStageSetContainsCurrentLevel(int level, StageSetData stageSet) {
        if (stageSet.stageRange.minStageLevel <= level && stageSet.stageRange.maxStageLevel >= level) {
            return true;
        }
        else {
            return false;
        }
    }
}
