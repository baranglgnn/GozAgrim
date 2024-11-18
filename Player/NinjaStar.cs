using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NinjaStar : MonoBehaviour
{
    public float speed;
    public float damage;
    Rigidbody2D rb;

    public PlayerControl player;
    public GameObject GroundEffect;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player=FindObjectOfType<PlayerControl>();
        if(player.transform.localScale.x  < 0)
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
            collision.GetComponent<EnemyStats>().takeDamage(damage);
            Destroy(gameObject);

        }else if (collision.CompareTag("Ground"))
        {
            Instantiate(GroundEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
