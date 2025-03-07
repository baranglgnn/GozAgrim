using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{

    public int LetterAmount;
    public GameObject letterPanel;
    public GameObject GameElements;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LetterBank.instance.Collect(LetterAmount);
            letterPanel.SetActive(true);
            GameElements.SetActive(false);
            Time.timeScale = 0;
            Destroy(gameObject);

        }
    }
}