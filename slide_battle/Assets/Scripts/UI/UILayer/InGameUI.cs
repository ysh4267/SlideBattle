using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameUI :Singleton<InGameUI>
{
    [SerializeField] public TextMeshProUGUI score;
    [SerializeField] public TextMeshProUGUI gold;
    [SerializeField] public TextMeshPro life;

    private void OnEnable() {
        UpdateUI();
    }

    public void UpdateUI() {
        UpdateScoreUI();
        UpdateCoinUI();
        UpdateLifeUI();
    }

    public void UpdateScoreUI() {
        score.text = UITextManager.GetScoreText();
    }

    public void UpdateCoinUI() {
        gold.text = UITextManager.GetGoldText();
    }
    
    public void UpdateLifeUI() {
        life.text = UITextManager.GetLifeText();
    }

}
