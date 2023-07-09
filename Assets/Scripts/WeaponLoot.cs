using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoot : LootBehaviour
{
    public WeaponBehaviour weapon;
    public void OnPickUp(Player player){
        player.ChangeWeapon(weapon);
        Destroy(gameObject);
    } 
}
