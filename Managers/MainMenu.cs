using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
   public Animator anim;
    [HideInInspector]
    public int Load�ngScene;
    void Start()
    {
        Load�ngScene = PlayerPrefs.GetInt("LastSavedScene");
    }


    void Update()
    {

    }

    public void StartGame()
    {
        PlayerPrefs.DeleteAll();
        GameData.instance.ClearData();
        SceneManager.LoadScene(1);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(Load�ngScene);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowOpt()
    {
        anim.SetBool("Show", true);
    }

    public void HideOpt()
    {
        anim.SetBool("Show", false);
    }
}
