using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectMixer;
    public AudioSource swordAS, enemyHitAS, backGroundMusicAS, deadAS, jumpAS, takeDamageAS, enemyDeadAS;

    [Range(-80,20)]
    public float EffectVol, MasterVol;

    public Slider MasterSldr, EffectSldr;

     public static AudioManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        PlayAudio(backGroundMusicAS);
        //MasterSldr.value = MasterVol;
        //EffectSldr.value = EffectVol;

        MasterSldr.minValue = -80;
        MasterSldr.maxValue = 20;

        EffectSldr.minValue = -80;
        EffectSldr.maxValue = 20;

        MasterSldr.value = PlayerPrefs.GetFloat("MusicVolume", 0f);
        EffectSldr.value = PlayerPrefs.GetFloat("FXVolume", 0f);
    }

    
    void Update()
    {
       // MasterVolume();
        // EffectVolume();
    }

    public void MasterVolume()
    {
        DataManager.instance.SetMusicData(MasterSldr.value);
        musicMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
    }

    public void EffectVolume()
    {
        DataManager.instance.FXData(EffectSldr.value);
        effectMixer.SetFloat("EffectVolume", PlayerPrefs.GetFloat("FXVolume"));
    }
    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
