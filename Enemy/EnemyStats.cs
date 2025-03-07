using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float maxHealth;
    private float currentHealth;
    public GameObject DeathEffect;
    public GameObject Coin;
    public Transform Player;

    public float timer;
    public float knockBackForceX,knockBackForceY;
    public float damage;

    public GameObject[] lootItems;

    public Rigidbody2D rb;

    hitEffect effect;
    void Start()
    {
        currentHealth = maxHealth;
        effect=GetComponent<hitEffect>();
        rb=GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;
        if(Player.position.x < transform.position.x)    
        {
            rb.AddForce(new Vector2(knockBackForceX, knockBackForceY), ForceMode2D.Force);
            
        }
        else
        {
            rb.AddForce(new Vector2(-knockBackForceX, knockBackForceY), ForceMode2D.Force);
            
        }


        GetComponent<SpriteRenderer>().material = effect.white;
        StartCoroutine(BackToNormal());

        if(currentHealth <= 0)
        {
            currentHealth = 0;
            Instantiate(DeathEffect,transform.position, transform.rotation);
            Instantiate(Coin,transform.position, transform.rotation);

            int lootChance = Random.Range(0, 101);
            int loots = Random.Range(1, lootItems.Length+1);

            if(lootChance > 50)
            {
             Instantiate(lootItems[0],transform.position, Quaternion.identity);
            }
            else
            {
                Instantiate(lootItems[loots - 1], transform.position, Quaternion.identity);
            }

            

            

            Destroy(gameObject);
        }
    }
    IEnumerator BackToNormal()
    {
        yield return new WaitForSeconds(timer);//bekleme s�resi
        GetComponent<SpriteRenderer>().material = effect.original;
    }
}
