using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeBar : MonoBehaviour {
    
    public Sprite[] bar;
    public Image lifeBarUI;

    private Player player;
    
    // Start is called before the first frame update
    void Start() {
        player = GameObject.Find("Player").GetComponent<Player>();        
    }

    // Update is called once per frame
    void Update() {
        lifeBarUI.sprite = bar[player.life];
    }
}
