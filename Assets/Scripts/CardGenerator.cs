using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject[] enemyCards;
    public GameObject[] weaponCards;
    public GameObject healthCard;
    public void Start(){
        for(int i = 0; i < 4; i++){
            GameObject card = enemyCards[Random.Range(0,enemyCards.Length)]; 
            Instantiate(card, gameObject.transform);
        }
        for (int i = 0; i < 2; i++)
        {
            GameObject card = weaponCards[Random.Range(0, weaponCards.Length)];
            Instantiate(card, gameObject.transform);
            Instantiate(healthCard, gameObject.transform);
        }
    }
}
