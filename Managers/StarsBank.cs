using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarsBank : MonoBehaviour
{
    public int bankStar;
    public Text bankText;

    public static StarsBank instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        bankText.text ="x " + bankStar.ToString();

    }

    
    void Update()
    {
        bankText.text = "x " + bankStar.ToString();

    }

    public void Collect(int starCollected)
    {
        bankStar += starCollected;
        bankText.text = "x "+bankStar.ToString();
        

    }
}
