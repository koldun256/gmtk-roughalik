using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderWeaponBehaviour : MonoBehaviour
{
    public int damage;
    public float range;
    public void SetData(SpiderWeapon spiderWeapon)
    {
        damage = spiderWeapon.damage; range = spiderWeapon.range;
    }

    public void Attack(GameObject target)
    {
        target.health = target.health - damage;
    }
}
