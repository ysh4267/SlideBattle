using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelHandler : ObserableHandler<PanelStatus> {
    public PanelHandler() {
        Information = new PanelStatus();
    }
    public void SetPanelStatus(ENUM_PANEL_STATUS status) {
        Information.currentPanelStatus = status;
    }

    public ENUM_PANEL_STATUS GetCurrentPanelStatus() {
        return Information.currentPanelStatus;
    }
}
