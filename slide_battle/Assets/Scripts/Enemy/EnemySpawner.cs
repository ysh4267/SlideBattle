using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float spawnTimeInterval;
    float time = 0.0f;
    [SerializeField]GameObject prefab;

    private void Start() {
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= spawnTimeInterval) {
            time = 0.0f;
            Instantiate(prefab, new Vector3(0,3,-39),prefab.transform.rotation);
        }
    }
}
