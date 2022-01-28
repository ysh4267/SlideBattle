using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : Singleton<StageManager>
{
    int currentLevel;
    int currentStageScore;
    public StageSetData currentStage;
    ObjectSpawner[] spawners;

    private void Start() {
        SetUpStage();
    }

    public void StageClear() {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.GAME_CLEAR);
        Observers.GetInstance().panelHandler.NotifyObservers();
        LevelUpStage();
    }

    public bool IsStageCleared() {
        if(currentStage.enemySpawnerSetting.totalObjectSpawnCount <= currentStageScore+(currentStage.givenPlayerHp-LifeManager.GetInstance().GetCurrentLife())) {
            return true;
        }
        return false;
    }

    public void AddCurrentStageScore(int amount) {
        currentStageScore += amount;
    }
    public void LevelUpStage() {
        currentLevel += 1;
        currentStage = GetProperStageSet(currentLevel);
        DataSaver.GetInstance().SaveStage(currentLevel);
        SetUpStage();
    }

    private void DebugCurrentStageInfo() {
        Debug.Log($"current stage Level : {currentLevel}");
        Debug.Log($"current stage set Level : {currentStage.stageSetLevel}");
        Debug.Log($"spawn enemy count: {currentStage.enemySpawnerSetting.totalObjectSpawnCount}");
        Debug.Log($"current total Score : {DataSaver.GetInstance().GetScore()}");
        Debug.Log($"current stage Score : {currentStageScore}");
    }

    private void SetUpStage() {
        DataSaver.GetInstance().LoadStage();
        currentLevel = DataSaver.GetInstance().LoadStage();
        currentStage = GetProperStageSet(currentLevel);
        LifeManager.GetInstance().InitLife();
        currentStageScore = 0;
        spawners = GetComponents<ObjectSpawner>();
        SetUpSpawners();
        DebugCurrentStageInfo();
    }

    public void StartStage() {

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
