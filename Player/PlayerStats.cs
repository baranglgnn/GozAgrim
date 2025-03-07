using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
   public static PlayerStats instance;

    public float runSpeed;
    public float attackPower;
    public float agility;

    public GameObject weaponStat;
    private void Awake()
    {
        if(instance != null)
        {
            Destroy(instance.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        
    }

   
    void Update()
    {
        
    }
}
