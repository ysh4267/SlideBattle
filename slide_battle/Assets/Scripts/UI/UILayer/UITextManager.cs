using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public static class UITextManager
{
    static public string GetScoreText() {
        return $"{DataSaver.GetInstance().GetScore()}";
    }

    static public string GetGoldText() {
        return $"{DataSaver.GetInstance().GetCurrentCoin()}";
    }

    static public string GetStageText() {
        return $"STAGE {DataSaver.GetInstance().GetStage()}";
    }

    static public string GetLifeText() {
        return $"{LifeManager.GetInstance().GetCurrentLife()}";
    }
}
