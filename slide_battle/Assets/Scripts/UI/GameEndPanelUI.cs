using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameEndPanelUI : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public TextMeshProUGUI gold;

    private void OnEnable() {
        UpdateUI();
    }

    public void UpdateUI() {
        UpdateScoreUI();
        UpdateCoinUI();
    }

    public void UpdateScoreUI() {
        score.text = UITextManager.GetScoreText();
    }

    public void UpdateCoinUI() {
        gold.text = UITextManager.GetGoldText();
    }
}
