using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeaponBehaviour : WeaponBehaviour
{
    public float lastAttackTime = 0f;
    public void SetData(SpiderWeapon spiderWeapon)
    {
        attackDelay = 1f;
        damage = spiderWeapon.damage; range = spiderWeapon.range;
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
