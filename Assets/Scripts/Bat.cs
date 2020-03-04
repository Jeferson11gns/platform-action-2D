﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : EnemyController {
    // Start is called before the first frame update
    void Start(){
        life = 2;
    }

    // Update is called once per frame
    void Update(){
        float distance = DistancePlayer();

        isMoving = (distance <= distanceAttack);

        if(isMoving){
            if((player.position.x > transform.position.x && sprite.flipX) ||
                (player.position.x < transform.position.x && !sprite.flipX)) {
                    Flip();
            }
        }

        if(isMoving) {
            transform.position = Vector3.MoveTowards(transform.position, player.position, Mathf.Abs(speed) * Time.deltaTime);
        }

    }

}
