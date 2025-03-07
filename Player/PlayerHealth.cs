using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    public Image HealthBar;
    public GameObject OlumEkrani;

    Animator anim;

    bool IsImmune;
    public float ImmunityTime;


    public static PlayerHealth Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        
        CurrentHealth = MaxHealth;//ba�lang��ta full can olmas� i�in
        anim = GetComponent<Animator>();    
        OlumEkrani.SetActive(false);
    }

    
    void Update()
    {
        if(CurrentHealth >= MaxHealth)//can iksiri ald���nda max� ge�mesin diye.
        {
            CurrentHealth = MaxHealth;
        }

        HealthBar.fillAmount = CurrentHealth / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)//triggerla a�t���m�z collider ba�ka bir collidera �arpt� olay asl�nda bu.
    {
        if (collision.CompareTag("Enemy") && !IsImmune)
        {
            CurrentHealth -=collision.GetComponent<EnemyStats>().damage;//enemy damage'ini getcomponent ile al�p currenttan ��kartt�k.
            StartCoroutine(Immunity());
            anim.SetTrigger("Hit");

            if(CurrentHealth <= 0) 
            {
                CurrentHealth = 0;
                Destroy(gameObject);
                OlumEkrani.SetActive(true);
            }
        }
    }
    IEnumerator Immunity()
    {
        IsImmune = true;
        yield return new WaitForSeconds(ImmunityTime);
        IsImmune = false;
    }
}
