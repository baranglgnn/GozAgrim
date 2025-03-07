using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if(LetterBank.instance.BankLetter == 4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                

            }

        }
    }
}
