using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {
    public int health;
    public int maxHealth = 100;
    public void Start(){
        health = maxHealth;
    }
    public void DoDamage(int damage) {
        Debug.Log("took " + damage + " damage");
        health -= damage;
        if(health < 0) {
            Destroy(gameObject);
        }
    }
    public void Heal() {
        health = maxHealth;
    }
}
