using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public int damage;
    public float range;
    public void SetData(SlimeWeapon slimeWepon)
    {
        damage = slimeWepon.damage; range = slimeWepon.range;
    }

    public void Attack(GameObject target)
    {
        target.GetComponent<Health>().DoDamage(damage);
    }
}
