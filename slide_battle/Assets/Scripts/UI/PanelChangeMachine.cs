using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PanelChangeMachine : ObserverContainer<PanelStatus>
{
    [SerializeField] GameObject StartPanel;
    [SerializeField] GameObject InGamePanel;
    [SerializeField] GameObject ClearPanel;
    [SerializeField] GameObject FailPanel;
    [SerializeField] GameObject TutorialPanel;
    [SerializeField] GameObject FadeEffect;

    private void Start() {
        Observers.GetInstance().panelHandler.Subscribe(this);
    }

    public void CloseAllPanel() {
        CloseStartPanel();
        CloseTutorial();
        CloseClear();
        CloseFail();
        CloseInGamePanel();
    }

    //시작 패널
    public void ActiveStartPanel()
    {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.MAIN_MENU);
        StartPanel.SetActive(true);
    }
    public void CloseStartPanel()
    {
        StartPanel.SetActive(false);
    }

    //인게임 패널
    public void ActiveInGamePanel() {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.IN_GAME);
        InGamePanel.SetActive(true);
    }

    public void CloseInGamePanel() {
        InGamePanel.SetActive(false);
    }

    //튜토리얼 패널
    public void ActiveTutorial()
    {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.TUTORIAL);
        TutorialPanel.SetActive(true);
    }
    public void CloseTutorial()
    {
        TutorialPanel.SetActive(false);
    }
    //클리어 패널
    public void ActiveClear()
    {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.GAME_CLEAR);
        ClearPanel.SetActive(true);
    }
    public void CloseClear()
    {
        FadeEffect.SetActive(true);
        StartCoroutine("FadeWait");
    }

    //실패 패널
    public void ActiveFail()
    {
        Observers.GetInstance().panelHandler.SetPanelStatus(ENUM_PANEL_STATUS.GAME_OVER);
        FailPanel.SetActive(true);
    }
    public void CloseFail()
    {
        FailPanel.SetActive(false);
    }

    IEnumerator FadeWait()
    {
        yield return new WaitForSeconds(0.8f);
        ClearPanel.SetActive(false);
        StartPanel.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        FadeEffect.SetActive(false);
    }

    public override void OnNext(PanelStatus value) {

        ENUM_PANEL_STATUS currentStatus =Observers.GetInstance().panelHandler.GetCurrentPanelStatus();
        switch (currentStatus) {
            case ENUM_PANEL_STATUS.IN_GAME:
                CloseStartPanel();
                ActiveStartPanel();
                break;
            case ENUM_PANEL_STATUS.GAME_CLEAR:
                CloseInGamePanel();
                ActiveClear();
                break;
            case ENUM_PANEL_STATUS.GAME_OVER:
                CloseInGamePanel();
                ActiveFail();
                break;
            case ENUM_PANEL_STATUS.MAIN_MENU:
                CloseAllPanel();
                ActiveStartPanel();
                break;
        }
    }
}