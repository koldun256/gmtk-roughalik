using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearBehaviour : WeaponBehaviour
{
    public float lastAttackTime = 0f;
    public float attackDelay = 0.5f;
    public void SetData(Spear spear)
    {
        attackDelay = spear.attackTime;
        damage = spear.damage;
        range = spear.range;
    }

    public override void Attack(GameObject target)
    {
        if (Time.time - lastAttackTime >= attackDelay)
        {
            lastAttackTime = Time.time;
            target.GetComponent<Health>().DoDamage(damage);
        }
    }
}
