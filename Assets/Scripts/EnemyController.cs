using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    
    public float speed;
    protected int life;
    protected bool isMoving = false;
    
    public float distanceAttack;

    protected Rigidbody2D body;
    protected Animator anim;
    protected Transform player;
    protected SpriteRenderer sprite;     
    

    void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent <Animator>();
        sprite = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<Transform>();
    }

    protected float DistancePlayer() {
        return Vector2.Distance(player.position, transform.position);
    }

    protected void Flip() {
        sprite.flipX = !sprite.flipX;

        speed *= -1;
    }

    public void DamageEnemy(int damage){
        life -= damage;
        //para poder chamar a corotina
        StartCoroutine(Damage());

        if(life < 1){
            Destroy(gameObject);
        }
    }

    //uma subrotina que serve para tocar a cor da esprite para darefeito de dano
    IEnumerator Damage(){
        sprite.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;

    }

}
