using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponBehaviour : MonoBehaviour
{
    public int damage;
    public float range;
    public void Attack(GameObject target){
        target.GetComponent<Health>().DoDamage(damage);
    }
}
