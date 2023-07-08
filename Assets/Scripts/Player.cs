using System.Collections;
using System.Collections.Generic;
using UnityEngine;
interface Decision {
    void Do(Player self, Room room);
}
class MoveDecision : Decision {
    public Vector2 target;
    public MoveDecision(Vector2 target) {
        this.target = target;
    }
    void Do(Player self, Room room) {
    
    }
}
class AttackDecision : Decision {
    public GameObject target;
    public AttackDecision(GameObject target){
        this.target = target
    }
    void Do(Player self, PlayerWeapon playerWeapon, Room room){
    
    }
}
class
public class Player : MonoBehaviour
{
    public GameObject room;
    public class PlayerWeapon{
        public 
    }
    Decision makeDesicion(){
        boolean enemyFlag = false;
        boolean lootFlag = false;
        foreach(var child in room.transform){
            if(child.tag == "Enemy"){
                enemyFlag = true;
                return new MoveDecision();
                break;
            }
            else if(child.tag == "Loot"){
                lootFlag = true
                break;
            }
        }
        return("Exit")

    }
    void Update()
    {
        makeDesicion().Do();
        Transform targetEnemy = null;
        float distanceToTargetEnemy = 99999.9;
        foreach(var child in room.transform){
           if(child.tag=="Enemy"){
               var distance = Vector2.Distance(gameObject.transform.position, child.transform.position)
               if(distanceToTargetEnemy>distance){
                    targetEnemy = child;
                    distanceToTargetEnemy = distance;
                    enemiesOnBattlefield = true;
               }
           }
        }
        if enemiesOnBattlefield
        if distanceToTargetEnemy<
    }
}
