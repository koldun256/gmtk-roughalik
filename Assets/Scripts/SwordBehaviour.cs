using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : MonoBehaviour
{
    public int damage;
    public float range;
    public void SetData(Sword sword) { 
        damage = sword.damage; range = sword.range;
    }

    public void Attack(GameObject target){
        target.health = target.health - damage;
    }
}
