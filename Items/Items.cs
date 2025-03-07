using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ItemType
{
    USABLE,//can potu
    WEAPON,//silahlar
    ARMOR,
    BOOTS,
    HELMET
}
public class Items : MonoBehaviour
{
    public GameObject itemToAdd;
    public int amountToAdd;

    Envanter Envanter;
    GameManagerTwo gameManager;
    void Start()
    {
        gameManager = GameManagerTwo.Instance;
        Envanter = gameManager.GetComponent<Envanter>();
    }

   
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Envanter.CheckSlotsAvailableity(itemToAdd,itemToAdd.name, amountToAdd);
            Destroy(gameObject);
        }
    }
}
