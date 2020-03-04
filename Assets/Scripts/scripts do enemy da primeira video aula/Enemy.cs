using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour{
    public GameObject damageText;

    public void EnemyHit(string value){
        if(damageText != null){
            var damage = Instantiate(damageText, transform.position, Quaternion.identity);
            damage.SendMessage("SetText", value);
        } 
    }
}
