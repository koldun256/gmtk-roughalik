using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeWeaponBehaviour : WeaponBehaviour
{
    public float lastAttackTime = 0f;
    public float attackDelay = 0.5f;
    public void SetData(SlimeWeapon slimeWepon)
    {
        damage = slimeWepon.damage; range = slimeWepon.range;
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
