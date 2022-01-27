using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float explosionRemainTimeLimit;
    private float time;
    private void Update() {
        time += Time.deltaTime;
        if (time >= explosionRemainTimeLimit) {
            Destroy(gameObject);
        }
    }
}
