using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthLoot : LootBehaviour
{
    public void OnPickUp(Player player){
        player.GetComponent<Health>().Heal();
    }
}
