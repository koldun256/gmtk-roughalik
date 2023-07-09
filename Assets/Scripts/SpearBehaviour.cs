using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : MonoBehaviour
{
    public int damage;
    public float range;
    public void SetData(Spear spear)
    {
        damage = spear.damage; range = spear.range;
    }

    public void Attack(GameObject target)
    {
        target.GetComponent<Health>().DoDamage(damage);
    }
}
