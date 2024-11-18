using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinBank : MonoBehaviour
{
    public int Bank;
    public static CoinBank instance;

    public Text BankText;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        BankText.text = "x" + Bank.ToString();
    }

    
    void Update()
    {
        
    }

    public void Money(int coinCollected)
    {
        Bank += coinCollected;
        BankText.text = "x" + Bank.ToString();

    }
}
