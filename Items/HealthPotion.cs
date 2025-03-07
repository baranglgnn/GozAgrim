using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    public float healthToGive;

    GameManagerTwo gameManager;
    Envanter envanter;
   

    public GameObject itemToAdd;
    public int itemAmount;

   
    void Start()
    {
        gameManager = GameManagerTwo.Instance;
        envanter = gameManager.GetComponent<Envanter>();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("TriggerZone"))
        {
            envanter.CheckSlotsAvailableity(itemToAdd, itemToAdd.name, itemAmount);
           // collision.GetComponent<PlayerHealth>().CurrentHealth += healthToGive;
            Destroy(gameObject);
        }
    }
}
