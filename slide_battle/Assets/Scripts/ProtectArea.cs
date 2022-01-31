using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProtectArea : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.tag == "Enemy") {
            LifeManager.GetInstance().LoseLife(1);
            InGameUI.GetInstance().UpdateLifeUI();
            Destroy(collision.gameObject);
            if (StageManager.GetInstance().IsStageCleared())
            {
                StageManager.GetInstance().StageClear();
            }
        }
    }
}
