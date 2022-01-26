using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public struct SpawnerSetting {
    public ENUM_SPAWN_OBJECT SPAWN_OBJECT_TYPE;
    public float spawnTimeInterval;
    public int objectSpawnCountAtSameTime;
    public int totalObjectSpawnCount;
    public List<Transform> spawnPositionList;
    public GameObject objectPrefab;
}
