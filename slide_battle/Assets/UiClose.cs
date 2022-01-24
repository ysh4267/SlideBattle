using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiClose : MonoBehaviour
{
    [SerializeField] GameObject startPanel;
    [SerializeField] GameObject ClearPanel;
    [SerializeField] GameObject FailtPanel;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject SettingPanel;

    public void closeStartPanel()
    {
        startPanel.SetActive(false);
    }

    public void ACtiveTutorial()
    {
        TutorialPanel.SetActive(true);
    }

    public void CloseTutorial()
    {
        TutorialPanel.SetActive(false);
    }

    public void ACtiveSetting()
    {
        SettingPanel.SetActive(true);
    }

    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }
}