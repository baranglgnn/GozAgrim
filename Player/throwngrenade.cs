using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class throwngrenade : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D rb;

    public PlayerControl player;
    public GameObject GroundEffect;
    public GameObject damageText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerControl>();
        if (player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }


    void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
           
            GameObject textDam= Instantiate(damageText,new Vector2(collision.transform.position.x, collision.transform.position.y+2), Quaternion.identity);
            textDam.GetComponent<TextMeshPro>().SetText(damage.ToString());
            collision.GetComponent<EnemyStats>().takeDamage(damage);
            Destroy(gameObject);

        }
        else if (collision.CompareTag("Ground"))
        {
            Instantiate(GroundEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}

