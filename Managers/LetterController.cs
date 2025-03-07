using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterController : MonoBehaviour
{
    public GameObject letterPanel; // Mektup UI Paneli
    public GameObject GameElements; // Oyun ekranýnda yer alan nesneler

    public bool isLetterOpen = false; // Mektubun açýk olup olmadýðýný takip eder

    void Update()
    {
        // Eðer bir tuþa basarak mektubu kapatmak isterseniz
        if (!isLetterOpen && Input.GetKeyDown(KeyCode.K))
        {
            CloseLetter();
        }
    }

    public void OpenLetter()
    {
        letterPanel.SetActive(true); // Mektup panelini aç
        GameElements.SetActive(false); // Oyun nesnelerini gizle
        Debug.Log("Game elements visibility: " + GameElements.activeSelf); // GameElements’in görünürlüðünü kontrol et
        Time.timeScale = 0; // Oyunu durdur
        isLetterOpen = true;
    }

    public void CloseLetter()
    {
        letterPanel.SetActive(false); // Mektup panelini kapat
        GameElements.SetActive(true); // Oyun nesnelerini geri getir
        Debug.Log("Game elements visibility: " + GameElements.activeSelf); // GameElements’in görünürlüðünü kontrol et
        Time.timeScale = 1; // Oyunu yeniden baþlat
        isLetterOpen = false;

    }
}