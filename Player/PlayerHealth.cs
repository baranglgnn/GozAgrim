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
        
        CurrentHealth = MaxHealth;//baþlangýçta full can olmasý için
        anim = GetComponent<Animator>();    
        OlumEkrani.SetActive(false);
    }

    
    void Update()
    {
        if(CurrentHealth >= MaxHealth)//can iksiri aldýðýnda maxý geçmesin diye.
        {
            CurrentHealth = MaxHealth;
        }

        HealthBar.fillAmount = CurrentHealth / 100;
    }

    private void OnTriggerEnter2D(Collider2D collision)//triggerla açtýðýmýz collider baþka bir collidera çarptý olay aslýnda bu.
    {
        if (collision.CompareTag("Enemy") && !IsImmune)
        {
            CurrentHealth -=collision.GetComponent<EnemyStats>().damage;//enemy damage'ini getcomponent ile alýp currenttan çýkarttýk.
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
