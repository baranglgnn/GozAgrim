using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Serialization;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Tilemaps;
using UnityEngine;


public class PlayerControl : MonoBehaviour
{
    private float movementDirection;//hareket yönü
    public float Speed;//hareket hýzý inspectorda görünebilecek(public)
    public float JumpPower;//zýplama gücü(public)
    public float GroundCheckRadius;//dairenin yarýçapý(public)
    public float AttackRate = 2f;//saldýrý hýzý
    float nextAttack = 0;//bir sonraki atak zamaný
    public float attackRadius;
    public float damage;
    
    private bool isFacingRight = true;//karakterin yüzü saða dönük mü?
    private bool isGrounded;//karakterin ayaðý zeminde mi?

    public GameObject GroundCheck;//oyun objesine eriþim saðladýk
    public Transform AttackPoint;
    public GameObject NinjaStar;
    public Transform FirePoint;
    

    public LayerMask groundLayer;//yüzeyin layerý
    public LayerMask enemyLayer;

    
    

    Rigidbody2D rb;//Rigitbody2D componenetinden bir deðiþken=rb

    Animator anim;
    void Start()//oyun baþlatýldýðý an çalýþacak kodlar.
    {
        //rb'ile Rigitbody2D componentini manipüle edebliceðiz.
        rb= GetComponent<Rigidbody2D >();
        anim= GetComponent<Animator>();//anim'ile animatorü manipüle edeceðiz
        
    }

    // Update is called once per frame
    void Update()//her frame için çalýþýr
    {
        CheckRotation();
        CheckSurface();
        CheckAnimations();
        Jump();
        AttackInput();
        Shoot();
       

    }

    private void FixedUpdate()//fiziksel iþlemler için daha doðru bir kullaným.
    {
        Movement();
    }

    void Movement()//Hareket metodu.
    {
        //GetAxixRaw=eksende bir hareket yapacaðýmýz için.
        movementDirection = Input.GetAxisRaw("Horizontal");
        rb.velocity=new Vector2(movementDirection*Speed,rb.velocity.y);//rigitbody nin hýzý x yönünde hareket ederken,y ekseninde sabit kalacak.
        anim.SetFloat("runSpeed",math.abs(movementDirection*Speed));//runSpeed'e hýzýmýzý atýyoruz.
    }

    void CheckRotation()
    {
        if (isFacingRight && movementDirection < 0)//yüzümüz saða dönükse ve sola doðru gidiyor isek.
        {
            Flip();
        }
        else if(!isFacingRight && movementDirection > 0)//yüzümüz saða dönük deðil ve saða doðru gidiyor isek.
        {
            Flip();
        }
    }

    void Flip()//döndürme fonksiyonu(swap mantýðý)
    {
        isFacingRight = !isFacingRight;//aç kapa mantýðý true olunca flip bitminde false a dönecek.Bu sayede sürekli true dönmesi engellenecek.
        Vector3 theScale = transform.localScale;//theScale deðiþkeni o anki localScale deðiþkeninin x ine eþit olacak.
        theScale.x *= -1;//-1 ile çarparak deðeri bir pozitif bir negatif yaparak aç kapa mantýðý uygulayacaðýz.
        transform.localScale = theScale;//localScale deðiþkeni iþlem sonundaki theScale deðiþkenine eþit olacak.
    }

    void Jump()//Zýplama fonksiyonu
    {
        if(isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space)){  //kullanýcý space kuþuna basarsa(GetKeyDown)
                rb.velocity = new Vector2(rb.velocity.x, JumpPower);//rb nin velocity si yeni vectora eþit olur.(x yönünde deðerini korur).
            }
        }
        
    }

    void CheckSurface()//yüzeyalaný kontrol metodu
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.transform.position, GroundCheckRadius, groundLayer);//isGrounded deðiþkenini kontrol için daire ürettik.(GroundCheck objesinin o anki konumu, yarýçap, ve ground un layerý)
    }

    private void OnDrawGizmos()//iþaret üretmemizi saðlýyor
    {
        Gizmos.DrawWireSphere(GroundCheck.transform.position, GroundCheckRadius);//bir saire iþareti çizdik.
        Gizmos.DrawWireSphere(AttackPoint.position, attackRadius);
    }

  

    void CheckAnimations()//animasyonu kontrol edecek düþüþ/yükseliþ
    {
        anim.SetBool("isGrounded", isGrounded);//anima ile beraber animasyonu manipüle ediyoruz
        anim.SetFloat("yVelocity", rb.velocity.y);
    }

    void Attack()//Atak metodu
    {
        float randomValue = UnityEngine.Random.Range(0, 2);//random sayý üretmek için kullandým(Gpt verdi)
        if(randomValue == 0)
        {
          anim.SetTrigger("Attack1");
          AudioManager.instance.PlayAudio(AudioManager.instance.swordAS);
        }else if(randomValue == 1)
        {
            anim.SetTrigger("Attack2");
            AudioManager.instance.PlayAudio (AudioManager.instance.swordAS);
        }

        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(AttackPoint.position, attackRadius, enemyLayer);

        foreach(Collider2D enemy in  hitEnemys)
        {
            enemy.GetComponent<EnemyStats>().takeDamage(damage);
        }
       
    }

   void AttackInput()
    {
        if(Time.time > nextAttack)
        {
         if (Input.GetKeyDown(KeyCode.LeftControl))
         {
            Attack();
                nextAttack = Time.time + 1f / AttackRate;
         }

        }
        
    }
    public void Shoot()
    {
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            if(StarsBank.instance.bankStar>0)
            {
             Instantiate(NinjaStar, FirePoint.position, FirePoint.rotation);
                StarsBank.instance.bankStar -=1;
            }
           

        }
    }

}
