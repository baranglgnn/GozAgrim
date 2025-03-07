using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveRoom : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameData.instance.DataSave();
            DataManager.instance.LastSavedScene(SceneManager.GetActiveScene().buildIndex);
            GameManagerTwo.Instance.sceneIndex = PlayerPrefs.GetInt("LastSavedScene");
        }
    }
}
