using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    int currentLevel;
    public StageSetData currentStage;
    ObjectSpawner[] spawners;

    private void Start() { 
        SetUpStage();
    }

    public void LevelUpStage() {
        currentLevel += 1;
        currentStage = GetProperStageSet(currentLevel);
        DataSaver.GetInstance().SaveStage(currentLevel);
        SetUpSpawners();
    }

    private void SetUpStage() {
        DataSaver.GetInstance().LoadStage();
        currentLevel = DataSaver.GetInstance().LoadStage();
        currentStage = GetProperStageSet(currentLevel);
        LifeManager.GetInstance().InitLife();
        InGameUI.GetInstance().UpdateUI();
        spawners = GetComponents<ObjectSpawner>();
        SetUpSpawners();
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
            spawner.InitializeThisSpawner();
        }
    }

    private StageSetData GetProperStageSet(int currentLevel) {
        List<StageSetData> stageSet = StageSetDataContainer.GetInstance().stageSet;
        foreach(StageSetData stageSetData in stageSet) {
            if(isStageSetContainsCurrentLevel(currentLevel, stageSetData)) {
                StageSetData clone = new StageSetData();

                clone.stageSetLevel = stageSetData.stageSetLevel;
                clone.givenPlayerHp = stageSetData.givenPlayerHp;
                clone.stageRange = stageSetData.stageRange;
                clone.enemySpawnerSetting = stageSetData.enemySpawnerSetting;
                clone.oilSpawnerSetting =stageSetData.oilSpawnerSetting;
                clone.pillarSpawnerSetting =stageSetData.pillarSpawnerSetting;
                clone.holeSpawnerSetting = stageSetData.holeSpawnerSetting;
                return clone;
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
