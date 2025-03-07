using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopNpc : MonoBehaviour
{
    public GameObject[] itemsInStore;

    public GameObject shopPanel;

    Envanter envanter;
    void Start()
    {
        envanter= GetComponent<Envanter>();
        SetUpShop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetUpShop()
    {
        for (int i = 0; i < itemsInStore.Length; i++)
        {
          GameObject itemToSell=  Instantiate(itemsInStore[i], envanter.slots[i].transform.position,Quaternion.identity);
            itemToSell.transform.SetParent(envanter.slots[i].transform,false);
            itemToSell.transform.localPosition= new Vector3(0,0,0);
            itemToSell.name = itemToSell.name.Replace("(Clone)", "");
        }
    }

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopPanel.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            shopPanel.SetActive(false);
        }
    }

   
}
