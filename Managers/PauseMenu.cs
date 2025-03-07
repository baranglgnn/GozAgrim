using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    bool isPaused;
    private void Awake()
    {
        pauseMenu.SetActive(false);
        isPaused = false;
    }


    void Update()
    {
        Pause();
    }

    public void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape)&& !isPaused)
        {
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
            isPaused = true;
        }else if(Input.GetKeyDown(KeyCode.Escape) && isPaused)
        {
            Time.timeScale=1;
            pauseMenu.SetActive(false);
            isPaused = false;
        }
    }
}
