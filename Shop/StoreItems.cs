using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StoreItems : MonoBehaviour
{
   //    public string itemName;
    public int itemSellPrice;
    public int itemBuyPrice;

    public GameObject itemToAdd;
    public int amountToAdd;

   

    TextMeshProUGUI buyPriceText;

    GameManagerTwo gameManager;
    Envanter envanter;
    void Start()
    {
        gameManager = GameManagerTwo.Instance;
        envanter = gameManager.GetComponent<Envanter>();

        buyPriceText= gameObject.GetComponentInChildren<TextMeshProUGUI>();
        buyPriceText.text=itemBuyPrice.ToString();

       
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void BuyItems()
    {

       
         if (itemBuyPrice <= CoinBank.instance.Bank)
         {
            CoinBank.instance.Money(-itemBuyPrice);
            envanter.CheckSlotsAvailableity(itemToAdd,itemToAdd.name,amountToAdd);
                buyPriceText.text= itemBuyPrice.ToString();
         }
       
    }

   
}
