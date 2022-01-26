using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    public SpawnerSetting spawnerSetting;
    float timeChecker;
    int spawnedObjectCount;

    private void Start() {
        timeChecker = 0.0f;
        spawnedObjectCount = 0;
    }

    private void Update() {
        if (spawnedObjectCount >= spawnerSetting.totalObjectSpawnCount) return;

        timeChecker += Time.deltaTime;
        if (timeChecker >= spawnerSetting.spawnTimeInterval) {
            timeChecker = 0.0f;
            SpawnEnemy(spawnerSetting.objectSpawnCountAtSameTime);
        }
    }

    public void InitializeThisSpawner() {
        
    }

    private List<Vector3> GetSpawnPositionList() {
        List<int> positionList = new List<int>();
        while (!(positionList.Count == spawnerSetting.objectSpawnCountAtSameTime)) {
            int randomNumber = Random.Range(0, spawnerSetting.spawnPositionList.Count);
            if (!positionList.Contains(randomNumber)) {
                positionList.Add(randomNumber);
            }
        }
        List<Vector3> resultList = new List<Vector3>();
        foreach(int posIndex in positionList) {

            resultList.Add(spawnerSetting.spawnPositionList[posIndex].position);
        }
        return resultList;
    }


    private void SpawnEnemy(int count) {
        List<Vector3> spawnPositionList = GetSpawnPositionList();
        for (int i = 0; i < count; i++) {
            if (spawnedObjectCount >= spawnerSetting.totalObjectSpawnCount) { return; }

            GameObject enemy = Instantiate<GameObject>(spawnerSetting.objectPrefab, spawnPositionList[i], Quaternion.identity);
            enemy.transform.position = spawnPositionList[i];
            spawnedObjectCount++;
        }
    }
}
