using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoMovel : MonoBehaviour {
    
    private Rigidbody2D body;
    private float massaOriginal;

    //private Transform;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        massaOriginal = body.mass;
    }

   void OnCollisionStay2D(Collision2D other){
        if(other.transform.tag == "Player"){   
            if(Input.GetKey(KeyCode.X)){   
                body.mass = 10f;
            }else{
                body.mass = massaOriginal;    
            }
        }
    }


    void OnCollisionExit2D(Collision2D other){
        if(other.transform.tag == "Player"){
            body.mass = massaOriginal;
        }
    }

}
