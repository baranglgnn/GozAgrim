using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LetterBank : MonoBehaviour
{
    public int BankLetter;
    public Text LetterText;

    public static LetterBank instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        LetterText.text= "x "  + BankLetter.ToString();

    }


    void Update()
    {
        

    }

    public void Collect(int letterCollected)
    {
        BankLetter += letterCollected;
        LetterText.text = "x " + BankLetter.ToString();
    }
}
