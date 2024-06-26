using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour {
    public int health;
    public int maxHealth = 100;
    public EnemyHealthBar healthBar;
    public void Start(){
        Heal();
    }
    public void DoDamage(int damage) {
        Debug.Log("took " + damage + " damage");
        health -= damage;
        if(!(healthBar is null)) healthBar.SetValue((float)health/(float)maxHealth);
        if(health <= 0) {
            if(gameObject.tag == "Player") {
                SceneManager.LoadScene("GameOverScene");
            }
            Destroy(gameObject);
        }
    }
    public void Heal() {
        if(!(healthBar is null)) healthBar.SetValue(1f);
        health = maxHealth;
    }
}
