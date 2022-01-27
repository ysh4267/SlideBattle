using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option : MonoBehaviour
{
    bool isSoundOn;
    bool isMusicOn;
    bool isVibeOn;

    public void SwitchSound() { 
        if(isSoundOn == true) {
            isSoundOn = false;
        }
        else {
            isSoundOn = true;
        }
    }

    public void SwitchMusic() {
        if (isMusicOn == true) {
            isMusicOn = false;
        }
        else {
            isMusicOn = true;
        }
    }

    public void SwitchVibe() {
        if (isVibeOn == true) {
            isVibeOn = false;
        }
        else {
            isVibeOn = true;
        }
    }
}
