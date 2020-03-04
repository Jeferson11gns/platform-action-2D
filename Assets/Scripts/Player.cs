using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{
    [Header("Variables player")]
    public float speed = 10f;
    public float jumpForce = 200f;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float radius = 0.032f;
    private AudioSource soundFx; 

    public int life;
    public bool vunerable;
    public bool isLiving = true;
    public int extraJumps = 1;
    private bool isOnFloor;
    private bool isJumping;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;

    [Header("Variables emeny")]
    public Transform attackCheck;
    public LayerMask layerEnemy;
    public float radiusAttackCheck;
    private float timeNextAttack;
    
    // Start is called before the first frame update
    void Start(){
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        soundFx = GetComponent<AudioSource>();      
    }

    // Update is called once per frame
    void Update(){
        
         isOnFloor = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);  

        if (Input.GetButtonDown("Jump") && extraJumps > 0){
            isJumping = true;
            extraJumps--;
            soundFx.Play();
        }

        if(isOnFloor)
            extraJumps = 1;

        if(timeNextAttack <= 0){
            if(Input.GetButtonDown("Fire1")){
                anim.SetTrigger("Attack");
                timeNextAttack = 0.1f;
                PlayerAttack();
            }
        } else {
            timeNextAttack -= Time.deltaTime;
        }

        PlayerAnimation();

        
    }

    void FixedUpdate(){

        if(isLiving){


            float move = Input.GetAxis("Horizontal");

            body.velocity = new Vector2(move * speed * Time.deltaTime, body.velocity.y);

            if((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false)){
                Flip();
            }

            if (isJumping){
                body.velocity = new Vector2(body.velocity.x, 0f);
                
                body.AddForce(new Vector2(0f, jumpForce));
                isJumping = false;
            }
        }

        //pulo fraco
            //if(body.velocity.y > 0f && !Input.GetButton("Jump")){
            //  body.velocity += Vector2.up * -0.2f;
            //}
    
    }

    void Flip(){
        sprite.flipX = !sprite.flipX;
        attackCheck.localPosition = new Vector2(-attackCheck.localPosition.x, attackCheck.localPosition.y);
    }


    void PlayerAnimation(){
        anim.SetFloat("velocityX", Mathf.Abs(body.velocity.x));
        anim.SetFloat("velocityY", Mathf.Abs(body.velocity.y));    
    }

    public void PlayerAttack(){
     
        Collider2D[] enemysAttack = Physics2D.OverlapCircleAll(attackCheck.position, radiusAttackCheck, layerEnemy);
        
        for(int i = 0; i < enemysAttack.Length; i++){
            //para pegar referencia do  inimigo e assim coisas prorias do script
            EnemyController enemy = enemysAttack[i].GetComponent<EnemyController> ();
            Skeleto enemySkeleto = enemysAttack[i].GetComponent<Skeleto> ();
           if(enemy != null){
               enemy.DamageEnemy(1);
           }
           
           if(enemySkeleto != null){
               enemySkeleto.DamageSkeleto(1);
           }
           
           
         
           
           
            //enemysAttack[i].SendMessage("EnemyHit","-15"); //aqui vai efeito que o inimigo foi atacado(piscando de vermelho)
            //Debug.Log(enemysAttack[i].name);
        }

    }

    IEnumerator Damage(){
        for(float i = 0; i < 1; i += 0.1f ){
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }

        vunerable = true;
    }

    public void DamagePlayer(){
        if(isLiving){

            vunerable = false;
            life --;
            StartCoroutine(Damage());

            if(life < 1){
                anim.SetTrigger("Death");
                isLiving = false;
                //chama uma funcao em tanto tempo
                Invoke("ReloadScene", 1.5f);
            }
        }
        
    }
    //para recomecar a fase
    void ReloadScene(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //para desenhar o circlo do OverlapCircle
    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
        Gizmos.DrawWireSphere(attackCheck.position, radiusAttackCheck);
    }

}
