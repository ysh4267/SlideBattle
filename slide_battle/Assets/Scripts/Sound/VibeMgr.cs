using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibeMgr : MonoBehaviour
{
    [SerializeField] Toggle VibeToggle;

    bool VibeOn = true;

    public void ToggleVibe(bool VibeIn)
    {
        if (VibeIn)
        {
            VibeOn = true;
        }
        else
        {
            VibeOn = false;
        }

    }

    void Update()
    {
        if (VibeToggle.isOn)
            VibeOn = true;
    }
}
