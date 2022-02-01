using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LifeManager : Singleton<LifeManager> {
    private int currentLife;

    public void InitLife() {
        currentLife = StageManager.GetInstance().currentStage.givenPlayerHp;
    }

    public void LoseLife(int amount) {
        currentLife -= amount;
        if (currentLife < 0) currentLife = 0;
        if (IsPlayerDead()) {

            NotifyGameOver();
        }
    }
    public void KillPlayer() {
        LoseLife(currentLife);
    }
    public void NotifyGameOver() {
        Debug.Log("Game OVER");
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.GAME_OVER);
        Observers.GetInstance().panelHandler.NotifyObservers();
        StageManager.GetInstance().gameObject.GetComponent<CoinSpawner>().StopEveryCoinSpawn();
    }
    public bool IsPlayerDead() {
        if (currentLife <= 0) {
            return true;
        }
        return false;
    }
    public void RecoverLife(int amount) {
        currentLife += amount;
    }

    public int GetCurrentLife() {
        return currentLife;
    }
}
