using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public float rotateSpeed;
    private void FixedUpdate() {
        Vector3 rotation = gameObject.transform.eulerAngles;

        rotation.y += rotateSpeed;

        gameObject.transform.eulerAngles = rotation;
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            DataSaver.GetInstance().CollectCoin();
            InGameUI.GetInstance().UpdateCoinUI();
            Destroy(gameObject);
        }
    }
}
