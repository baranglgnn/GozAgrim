using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUse : MonoBehaviour
{
    public int ID;
    public float healthToGive;
    public float weaponDamageModifier;

    public ItemType type;   
    public void Use()
    {
        PlayerHealth.Instance.CurrentHealth += healthToGive;

        if(type == ItemType.WEAPON)
        {
            if (transform.GetChild(1).gameObject.activeSelf)
            {   PlayerStats.instance.weaponStat.GetComponent<WeaponStats>().weaponAttack = 0;
                PlayerStats.instance.weaponStat.GetComponent<WeaponStats>().weaponAttack = weaponDamageModifier;
            }
            else
            {
                PlayerStats.instance.weaponStat.GetComponent<WeaponStats>().weaponAttack = 0;
            }
            
        }
    }
}
