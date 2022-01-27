using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UITextManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI stageNumberingText;
    [SerializeField] TextMeshProUGUI goldText;
    private void Start() {
        SetStageText();
        SetGoldText();
    }

    void SetGoldText() {
        goldText.text = $"{DataSaver.GetInstance().GetCurrentCoin()}";
    }

    void SetStageText() {
        stageNumberingText.text = $"STAGE {DataSaver.GetInstance().LoadStage()}";
    }
}
