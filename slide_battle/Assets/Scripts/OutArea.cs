using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutArea : MonoBehaviour {
    private void OnTriggerEnter(Collider other) {
        Debug.Log(other);
        switch (other.gameObject.tag) {
            case "Player":
                
                break;
            case "Enemy":
                DataSaver.GetInstance().AddScore(1);
                InGameUI.GetInstance().UpdateScoreUI();
                Destroy(other.gameObject,1);
                break;
        }
    }
}
