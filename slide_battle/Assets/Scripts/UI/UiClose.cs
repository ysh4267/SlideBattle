using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UiClose : MonoBehaviour
{
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject ClearPanel;
    [SerializeField] GameObject FailtPanel;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject SettingPanel;
    [SerializeField] GameObject FadeEffect;


    //시작 패널
    public void ACtiveStartPanel()
    {
        StartPanel.SetActive(true);
    }
    public void closeStartPanel()
    {
        StartPanel.SetActive(false);
    }

    //튜토리얼 패널
    public void ACtiveTutorial()
    {
        TutorialPanel.SetActive(true);
    }
    public void CloseTutorial()
    {
        TutorialPanel.SetActive(false);
    }

    //설정 패널
    public void ACtiveSetting()
    {
        SettingPanel.SetActive(true);
    }
    public void CloseSetting()
    {
        SettingPanel.SetActive(false);
    }

    //클리어 패널
    public void ACtiveClear()
    {
        ClearPanel.SetActive(true);
    }
    public void CloseClear()
    {
        FadeEffect.SetActive(true);
        StartCoroutine("FadeWait");

    }

    //실패 패널
    public void ACtiveFail()
    {
        FailtPanel.SetActive(true);
    }
    public void CloseFail()
    {
        FailtPanel.SetActive(false);
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(0.8f);
        ClearPanel.SetActive(false);
        StartPanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        FadeEffect.SetActive(false);
    }
}