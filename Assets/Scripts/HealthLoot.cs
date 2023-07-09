using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLoot : LootBehaviour
{
    public override void OnPickUp(Player player){
        player.GetComponent<Health>().Heal();
        Destroy(gameObject);
    }
}
