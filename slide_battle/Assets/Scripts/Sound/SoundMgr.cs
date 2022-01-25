using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMgr : MonoBehaviour
{
    public Slider Bgmslider;
    public AudioSource Bgm;

    private float BgmVol = 1f;

    void Start()
    {
        BgmVol = PlayerPrefs.GetFloat("BgmVolKey", 1f);
        Bgmslider.value = BgmVol;
        Bgm.volume = Bgmslider.value;
    }

    // Update is called once per frame
    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        Bgm.volume = Bgmslider.value;

        BgmVol = Bgmslider.value;
        PlayerPrefs.SetFloat("BgmVolKey", BgmVol);
    }
}
