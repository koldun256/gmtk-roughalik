using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardGenerator : MonoBehaviour
{
    public GameObject[] enemyCards;
    public GameObject[] weaponCards;
    public GameObject healthCard;
    public GameObject card;
    public void Start(){
        for(int i = 0; i < 4; i++){
            card = enemyCards[Random.Range(0,enemyCards.Length)];
            Instantiate(card, gameObject.transform);
        }
        for (int i = 0; i < 2; i++)
        {
            Instantiate(healthCard, gameObject.transform);
        }
        Instantiate(weaponCards[0], gameObject.transform);
        Instantiate(weaponCards[1], gameObject.transform);
    }
}
