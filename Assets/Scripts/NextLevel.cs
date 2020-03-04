using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour{
    
    private AudioSource soundFx;
    // Start is called before the first frame update
    void Start() {
        soundFx = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            soundFx.Play();
        }
    }
}
