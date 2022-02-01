using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataSaver : Singleton<DataSaver> {
    private int coin = 0;
    private int latestStage = 1;
    private int score = 0;
    private void Start() {
        InitializeCoinStatus();
        InitializeScoreStatus();
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
    void InitializeScoreStatus()
    {
        if (PlayerPrefs.HasKey("Score"))
        {
            score = PlayerPrefs.GetInt("Score");
        }
        else
        {
            score = 0;
            PlayerPrefs.SetInt("Score",score);
        }
    }

    public void ResetAllData() {
        ResetCoinData();
        ResetStageData();
        ResetScoreData();
        SaveData();
    }

    public void ResetCoinData()
    {
        coin = 0;
    }


    public void ResetScoreData()
    {
        score = 0;
    }

    public void ResetStageData()
    {
        latestStage = 1;
    }

    public int GetScore() {
        return score;
    }

    public void AddScore(int scoreAdd) {
        score += scoreAdd;
    }

    public void SetStage(int stage) {
        latestStage = stage;
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Score",score);
        PlayerPrefs.SetInt("Coin",coin);
        PlayerPrefs.SetInt("Stage",latestStage);
        PlayerPrefs.Save();
    }
    public void LoadData()
    {
        score = PlayerPrefs.GetInt("Score");
        coin = PlayerPrefs.GetInt("Coin");
        latestStage = PlayerPrefs.GetInt("Stage");
    }
    public int GetStage() {
        return latestStage;
    }

    public void CollectCoin() {
        coin += 1;
    }

    public int GetCurrentCoin() {
        return coin;
    }
}
