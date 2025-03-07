using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Envanter : MonoBehaviour
{
    public GameObject[] slots;
    bool isInstantiated;

    public ItemList itemList;

    TextMeshProUGUI amountText;

    public Dictionary<string,int> inventoryItems=new Dictionary<string,int>();


    void Start()
    {
        GameData.instance.Load();
        Debug.Log("Game data loaded.");
        DataToInventory();
        Debug.Log("Inventory data loaded to slots.");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckSlotsAvailableity(GameObject itemToAdd,string itemName,int itemAmount)

    {
        isInstantiated = false;
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].transform.childCount>0)
            {
                slots[i].GetComponent<Slotlar>().isUsed = true;
            }
            else if(!isInstantiated && !slots[i].GetComponent<Slotlar>().isUsed)
            {
                if (!inventoryItems.ContainsKey(itemName))
                {
                  GameObject item =  Instantiate(itemToAdd, slots[i].transform.position,Quaternion.identity);
                    item.transform.SetParent(slots[i].transform,false);
                    item.transform.localPosition= new Vector3(0,0,0);
                    item.name = item.name.Replace("(Clone)", "");
                    isInstantiated=true;
                    slots[i].GetComponent<Slotlar>().isUsed=true;
                    inventoryItems.Add(itemName, itemAmount);
                    amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                    amountText.text = itemAmount.ToString();
                    break;
                }
                else
                {
                    for (int j = 0; j < slots.Length; j++)
                    {
                        if (slots[j].transform.GetChild(0).gameObject.name == itemName)
                        {
                            inventoryItems[itemName] += itemAmount;
                            amountText = slots[j].GetComponentInChildren<TextMeshProUGUI>();
                            amountText.text= inventoryItems[itemName].ToString();
                            break;
                        }
                        
                    }
                    break;
                }
            }
        }
        
    }


    public void UseInventoryItems(string itemName)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetComponent<Slotlar>().isUsed)
            {
                continue;
            }

             if (slots[i].transform.GetChild(0).gameObject.name == itemName)
             {
                inventoryItems[itemName]--;
                amountText = slots[i].GetComponentInChildren<TextMeshProUGUI>();
                amountText.text = inventoryItems[itemName].ToString();

                if (inventoryItems[itemName] <= 0)
                {
                    Destroy(slots[i].transform.GetChild(0).gameObject);
                    slots[i].GetComponent<Slotlar>().isUsed = false;
                    inventoryItems.Remove(itemName);
                    ReorganizdeInventory();
                }
                break;
             }
        }
    }

    public void ReorganizdeInventory() 
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (!slots[i].GetComponent<Slotlar>().isUsed)
            {
                for (int j = i+1; j < slots.Length; j++)
                {
                    if (slots[j].GetComponent<Slotlar>().isUsed)
                    {
                        Transform itemToMove = slots[j].transform.GetChild(0).transform;
                        itemToMove.transform.SetParent(slots[i].transform,false);
                        itemToMove.transform.localPosition = new Vector3(0,0,0);
                        slots[i].GetComponent <Slotlar>().isUsed = true;
                        slots[j].GetComponent<Slotlar>().isUsed = false;
                        break;
                    }
                }
            }
        }

    }

    public void DataToInventory()
    {
        for (int i = 0; i < GameData.instance.saveData.addID.Count; i++)
        {
            for (int j = 0; j < itemList.items.Count; j++)
            {
                if (itemList.items[j].ID == GameData.instance.saveData.addID[i])
                {
                    CheckSlotsAvailableity(itemList.items[j].gameObject, GameData.instance.saveData.inventoryItemsName[i], GameData.instance.saveData.inventoryItemsAmount[i]);
                }
            }
        }
    }

    public void InventoryToData()
    {
        GameData.instance.saveData.addID.Clear();
        GameData.instance.saveData.inventoryItemsName.Clear();
        GameData.instance.saveData.inventoryItemsAmount.Clear();

        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<Slotlar>().isUsed)
            {
                var itemComponent = slots[i].GetComponentInChildren<ItemUse>();
                if (itemComponent != null)
                {
                    string itemName = itemComponent.name;
                    int itemID = itemComponent.ID;

                    // Eþya kayýtlý deðilse veya yeni bir miktar eklemek gerekiyorsa
                    if (!GameData.instance.saveData.addID.Contains(itemID))
                    {
                        GameData.instance.saveData.addID.Add(itemID);
                        GameData.instance.saveData.inventoryItemsName.Add(itemName);

                        // Eþya miktarýný doðru þekilde kaydet
                        if (inventoryItems.ContainsKey(itemName))
                        {
                            GameData.instance.saveData.inventoryItemsAmount.Add(inventoryItems[itemName]);
                        }
                        else
                        {
                            GameData.instance.saveData.inventoryItemsAmount.Add(1); // Varsayýlan olarak 1 adet ekleyin
                        }
                    }
                }
            }
        }
    }

    public void EquipmentInInventory(ItemType type)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<Slotlar>().isUsed)
            {
                if (slots[i].transform.GetComponentInChildren<ItemUse>().type != ItemType.USABLE)
                {
                    if (slots[i].transform.GetComponentInChildren<ItemUse>().type == type)
                    {
                        if (slots[i].transform.GetChild(0).GetChild(1).gameObject.activeSelf)
                        {
                            slots[i].transform.GetChild(0).GetChild(1).gameObject.SetActive(false);
                        }
                    }
                }
            }
        }
    }

}
