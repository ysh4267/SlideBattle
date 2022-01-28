using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Hole : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Player") {
            LifeManager.GetInstance().KillPlayer();
            Destroy(collision.gameObject);
        }
    }
}
