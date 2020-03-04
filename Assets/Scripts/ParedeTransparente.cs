using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeTransparente : MonoBehaviour {
    SpriteRenderer sprite;
    float alfaOriginal;
    float redOriginal;
    float greenOriginal;
    float betaOriginal;
    // Start is called before the first frame update
    void Start() {
        sprite = GetComponent<SpriteRenderer>();
        alfaOriginal = sprite.color.a;
        redOriginal = sprite.color.r;
        greenOriginal = sprite.color.g;
        betaOriginal = sprite.color.b;
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            sprite.color = new Color(redOriginal, greenOriginal, betaOriginal , 0.5f);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            sprite.color = new Color(redOriginal, greenOriginal, betaOriginal,alfaOriginal);
        }
    }

}
