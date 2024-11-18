using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    public AudioMixer musicMixer, effectMixer;
    public AudioSource swordAS, enemyHitAS, backGroundMusicAS, deadAS, jumpAS, takeDamageAS, enemyDeadAS;


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
        
    }

    
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
