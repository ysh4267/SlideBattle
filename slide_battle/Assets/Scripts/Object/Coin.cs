using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] AudioClip coinGetSound;
    AudioSource audioSource;
    public float rotateSpeed;
    private void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = coinGetSound;
    }
    private void FixedUpdate() {
        Vector3 rotation = gameObject.transform.eulerAngles;

        rotation.y += rotateSpeed;

        gameObject.transform.eulerAngles = rotation;
    }

    public void PlayCoinSound() {
        if(SoundMgr.GetInstance().SoundToggle.isOn)
        audioSource.Play();
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player") {
            DataSaver.GetInstance().CollectCoin();
            InGameUI.GetInstance().UpdateCoinUI();
            SoundMgr.GetInstance().PlayCoinSound();
            Destroy(gameObject);
        }
    }
}
