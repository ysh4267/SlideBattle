using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : Singleton<DataSaver> {
    private int coin = 0;
    private int latestStage = 1;
    private void Start() {
        InitializeCoinStatus();
    }

    void InitializeCoinStatus() {
        if (PlayerPrefs.HasKey("Coin")) {
            coin = PlayerPrefs.GetInt("Coin");
        }
        else {
            PlayerPrefs.SetInt("Coin", 0);
            coin = 0;
        }
    }

    public void SaveStage(int stage) {
        PlayerPrefs.SetInt("Stage", stage);
    }

    public int LoadStage() {
        if (PlayerPrefs.HasKey("Stage")) {
            latestStage = PlayerPrefs.GetInt("Stage");
        }
        else {
            latestStage = 1;
        }
        return latestStage;
    }

    public void CollectCoin() {
        coin += 1;
        PlayerPrefs.SetInt("Coin", coin);
        PlayerPrefs.Save();
    }

    public int GetCurrentCoin() {
        return PlayerPrefs.GetInt("Coin");
    }
}
