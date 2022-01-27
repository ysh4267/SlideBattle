using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LifeManager : Singleton<LifeManager> {
    int currentLife;

    public void InitLife() {
        currentLife = StageManager.GetInstance().currentStage.givenPlayerHp;
    }

    public void LoseLife(int amount) {
        currentLife -= amount;
    }

    public void RecoverLife(int amount) {
        currentLife += amount;
    }

    public int GetCurrentLife() {
        return currentLife;
    }
}
