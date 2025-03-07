using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    float attackPower;
    float totalAttackPower;
    public float weaponAttack;

    PlayerControl player;

    public GameObject DamageText;
    void Start()
    {
        //player =GetComponent<PlayerControl>();
        attackPower = PlayerStats.instance.attackPower;
    }

    
    void Update()
    {
        
    }

    public float DamageInput()
    {
        totalAttackPower = attackPower + weaponAttack;
        float finalAttack= Mathf.Round(Random.Range(totalAttackPower-7,totalAttackPower+5));
        GameObject textDam= Instantiate(DamageText, new Vector2(transform.position.x+1,transform.position.y), Quaternion.identity);
        textDam.GetComponent<TextMeshPro>().SetText(finalAttack.ToString());
        if(finalAttack > totalAttackPower+1)
        {
            textDam.GetComponent<TextMeshPro>().SetText("CRITICAL!\n" + finalAttack.ToString());
            finalAttack *= 2;
        }
        return finalAttack;
    }
}
