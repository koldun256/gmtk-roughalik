using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLoot : LootBehaviour
{
    public Weapon weapon;
    public override void OnPickUp(Player player) {
        WeaponBehaviour weaponBehaviour = null;
        if(weapon is Spear) {
            var spearBehaviour = player.gameObject.AddComponent<SpearBehaviour>();
            spearBehaviour.SetData(weapon as Spear);
            weaponBehaviour = spearBehaviour;
        }
        if(weapon is Sword) {
            var spearBehaviour = player.gameObject.AddComponent<SwordBehaviour>();
            spearBehaviour.SetData(weapon as Sword);
            weaponBehaviour = spearBehaviour;
        }
        player.ChangeWeapon(weaponBehaviour);
        Destroy(gameObject);
    } 
}
