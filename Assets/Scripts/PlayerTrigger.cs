using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTrigger : MonoBehaviour {
    Player player;
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update() {
        
    }

    void OnTriggerEnter2D(Collider2D other){
        
        if(player.vunerable){
            if(other.CompareTag("Enemy")){
                player.DamagePlayer();
            }
        }

        if(other.CompareTag("Portal")){
            Invoke("NextLevel", 0.5f);
        }

    }

    void NextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
