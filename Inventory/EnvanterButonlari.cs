using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnvanterButonlari : MonoBehaviour
{
    GameManagerTwo gameManager;
    Envanter envanter;

    void Start()
    {
        gameManager = GameManagerTwo.Instance;
        envanter = gameManager.GetComponent<Envanter>();
    }


    public void Use›tem()
    {
        

        envanter.EquipmentInInventory(GetComponent<ItemUse>().type);
        if(GetComponent<ItemUse>().type != ItemType.USABLE)
        {
                if(transform.GetChild(1).gameObject.activeSelf)
                {
                    transform.GetChild(1).gameObject.SetActive(false);
                }
                else
                {
                    transform.GetChild(1).gameObject.SetActive(true);
                    EquipmentController.instance.UpdateImage(GetComponent<Image>().sprite.texture);
                }
        }
        else
        {
          envanter.UseInventoryItems(gameObject.name);
        }
        
    }
}
