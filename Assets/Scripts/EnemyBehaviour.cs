using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject room;
    public Player player;
    public int maxHelath;
    public int health;
    private WeaponBehaviour weapon;
    void Start(){
        weapon = GetComponent<WeaponBehaviour>();
    }
    public void Update(){
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) <= weapon.range){

        }
    }
}
