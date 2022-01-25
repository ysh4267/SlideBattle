using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour {
    [SerializeField] float spawnTimeInterval;
    [SerializeField] int objectSpawnCountAtSameTime;//스폰 타이밍에 동시에 소환 가능한 오브젝트 수
    [SerializeField] int totalObjectSpawnCount;//해당 스테이지에서 소환할 해당 오브젝트 수
    [SerializeField] List<Transform> spawnPositionList;
    [SerializeField] GameObject objectPrefab;

    float timeChecker;
    int spawnedObjectCount;

    private void Start() {
        timeChecker = 0.0f;
    }

    private void Update() {
        if (spawnedObjectCount >= totalObjectSpawnCount) return;

        timeChecker += Time.deltaTime;
        if (timeChecker >= spawnTimeInterval) {
            timeChecker = 0.0f;
            SpawnEnemy(objectSpawnCountAtSameTime);
        }
    }

    private List<Vector3> GetSpawnPositionList() {
        List<int> positionList = new List<int>();
        while (!(positionList.Count == objectSpawnCountAtSameTime)) {
            int randomNumber = Random.Range(0, spawnPositionList.Count);
            if (!positionList.Contains(randomNumber)) {
                positionList.Add(randomNumber);
            }
        }
        List<Vector3> resultList = new List<Vector3>();
        foreach(int posIndex in positionList) {

            resultList.Add(spawnPositionList[posIndex].position);
        }
        return resultList;
    }


    private void SpawnEnemy(int count) {
        List<Vector3> spawnPositionList = GetSpawnPositionList();
        for (int i = 0; i < count; i++) {
            if (spawnedObjectCount >= totalObjectSpawnCount) { return; }

            GameObject enemy = Instantiate<GameObject>(objectPrefab, spawnPositionList[i], objectPrefab.transform.rotation);
            enemy.transform.position = spawnPositionList[i];
            spawnedObjectCount++;
        }
    }
}
