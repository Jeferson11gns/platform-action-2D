using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleto : MonoBehaviour{
    
    private SpriteRenderer sprite;
    private Rigidbody2D body;
    public Transform groundCheck;
    public LayerMask whatIsGround;

    private bool isOnfloor;
    public float radius;
    
    public float speed;
    private int life = 2;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();  
    }

    // Update is called once per frame
    void Update(){
        isOnfloor = Physics2D.OverlapCircle(groundCheck.position, radius, whatIsGround);  
         
    }

    void FixedUpdate(){
        if(isOnfloor){
            body.velocity = new Vector2(speed, body.velocity.y);     
        }else{
            Flip();  
        }
    }
    
    void Flip(){
        sprite.flipX = !sprite.flipX;
        speed *= -1;
        groundCheck.localPosition = new Vector2(-groundCheck.localPosition.x, groundCheck.localPosition.y);
    }

    public void DamageSkeleto(int damage){
        life -= damage;

        StartCoroutine(Damage());
        
        if(life < 1){
            Destroy(gameObject);
        }
    }

    IEnumerator Damage(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }

    void OnDrawGizmosSelected(){
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }
}
