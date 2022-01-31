using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMgr : MonoBehaviour
{
    [SerializeField] Toggle BgmToggle;
    [SerializeField] Toggle SoundToggle;

    public AudioSource Bgm;
    public AudioSource EffectSound;

    void Start()
    {
    }

    public void ToggleBgm(bool audioIn)
    {
        if (audioIn)
        {
            Bgm.volume = 1;
        }
        else 
        {
            Bgm.volume = 0;
        }
    }

    public void ToggleSound(bool audioIn)
    {
        if (audioIn)
        {
            EffectSound.volume = 1;
        }
        else
        {
            EffectSound.volume = 0;
        }
    }

    private void Update()
    {
        if (BgmToggle.isOn)
            Bgm.volume = 1;

        if (SoundToggle.isOn)
            EffectSound.volume = 1;
    }

}
