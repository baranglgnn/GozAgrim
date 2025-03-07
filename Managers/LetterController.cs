using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public GameObject letterPanel; // Mektup UI Paneli
    public GameObject GameElements; // Oyun ekran�nda yer alan nesneler

    public bool isLetterOpen = false; // Mektubun a��k olup olmad���n� takip eder

    void Update()
    {
        // E�er bir tu�a basarak mektubu kapatmak isterseniz
        if (!isLetterOpen && Input.GetKeyDown(KeyCode.K))
        {
            CloseLetter();
        }
    }

    public void OpenLetter()
    {
        letterPanel.SetActive(true); // Mektup panelini a�
        GameElements.SetActive(false); // Oyun nesnelerini gizle
        Debug.Log("Game elements visibility: " + GameElements.activeSelf); // GameElements�in g�r�n�rl���n� kontrol et
        Time.timeScale = 0; // Oyunu durdur
        isLetterOpen = true;
    }

    public void CloseLetter()
    {
        letterPanel.SetActive(false); // Mektup panelini kapat
        GameElements.SetActive(true); // Oyun nesnelerini geri getir
        Debug.Log("Game elements visibility: " + GameElements.activeSelf); // GameElements�in g�r�n�rl���n� kontrol et
        Time.timeScale = 1; // Oyunu yeniden ba�lat
        isLetterOpen = false;

    }
}