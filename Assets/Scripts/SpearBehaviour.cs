using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : WeaponBehaviour
{
    public float lastAttackTime = 0f;

    public void SetData(Spear spear)
    {
        attackDelay = spear.attackTime;
        damage = spear.damage;
        range = spear.range;
    }

    public override void Attack(GameObject target)
    {
        Debug.Log("wow vilka is working");
        if (Time.time - lastAttackTime >= attackDelay)
        {
            lastAttackTime = Time.time;
            target.GetComponent<Health>().DoDamage(damage);
        }
    }
}
