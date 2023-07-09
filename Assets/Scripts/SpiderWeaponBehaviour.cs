using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeaponBehaviour : WeaponBehaviour
{
    public int damage;
    public float range;
    public void SetData(SpiderWeapon spiderWeapon)
    {
        damage = spiderWeapon.damage; range = spiderWeapon.range;
    }

    public void Attack(GameObject target)
    {
        target.GetComponent<Health>().DoDamage(damage);
    }
}
