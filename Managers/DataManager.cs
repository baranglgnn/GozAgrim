using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
   
  public static DataManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance != null)
        {
         Destroy(instance.gameObject);
            instance = this;
        
        }
    }

    public void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void SetMusicData(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
    }

    public void FXData(float value)
    {
        PlayerPrefs.SetFloat("FXVolume", value);
    }

    public void CurrentGrenade(int value) 
    {
        PlayerPrefs.SetInt("StarAmount", value);    
    }

    public void CurrentCoin(int value)
    {
        PlayerPrefs.SetInt("CoinsAmount", value);
    }

    public void LastSavedScene(int value)
    {
        PlayerPrefs.SetInt("LastSavedScene", value);
    }

}
