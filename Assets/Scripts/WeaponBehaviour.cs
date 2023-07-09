using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class WeaponBehaviour : MonoBehaviour
{
    public int damage;
    public float range;
    public abstract void Attack(GameObject target);
}
