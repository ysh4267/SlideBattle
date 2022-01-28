using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : Singleton<DataSaver> {
    private int coin = 0;
    private int latestStage = 1;
    private int score = 0;
    private void Start() {
        ResetAllData();
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
    
    public void ResetAllData() {
        if (PlayerPrefs.HasKey("Coin")) {
            PlayerPrefs.SetInt("Coin", 0);
        }
        if (PlayerPrefs.HasKey("Stage")) {
            PlayerPrefs.SetInt("Stage", 1);
        }
        if (PlayerPrefs.HasKey("Score")) {
            PlayerPrefs.SetInt("Score", 0);
        }
    }


    public int GetScore() {
        if (PlayerPrefs.HasKey("Score")) {
            return PlayerPrefs.GetInt("Score");
        }
        else {
            PlayerPrefs.SetInt("Score",0);
            return 0;
        }
    }

    public void AddScore(int scoreAdd) {
        score += scoreAdd;
        PlayerPrefs.SetInt("Score", score);
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
