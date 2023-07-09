using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBehaviour : WeaponBehaviour
{
    public int damage;
    public float range;
    public void SetData(Sword sword) { 
        damage = sword.damage; range = sword.range;
    }

    public void Attack(GameObject target){
        target.GetComponent<Health>().DoDamage(damage);
    }
}
