using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMgr : Singleton<SoundMgr>
{
    [SerializeField] public Toggle BgmToggle;
    [SerializeField] public Toggle SoundToggle;

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

    public void PlayHitSound()
    {
        EffectSound.clip = Resources.Load<AudioClip>("EffectSound/HitNormal");
        EffectSound.Play();
    }
    public void PlayHitMaxSound()
    {
        EffectSound.clip = Resources.Load<AudioClip>("EffectSound/HitMax");
        EffectSound.Play();
    }
    public void PlayHitPillarSound()
    {
        EffectSound.clip = Resources.Load<AudioClip>("EffectSound/HitPillar");
        EffectSound.Play();
    }
    public void PlayCoinSound()
    {
        EffectSound.clip = Resources.Load<AudioClip>("EffectSound/CoinSound");
        EffectSound.Play();
    } 
    private void Update()
    {
        if (BgmToggle.isOn)
            Bgm.volume = 1;

        if (SoundToggle.isOn)
            EffectSound.volume = 1;
    }

}
