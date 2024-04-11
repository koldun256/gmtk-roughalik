using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUD : MonoBehaviour
{
    public TMP_Text hp;
    public TMP_Text dmg;
    public TMP_Text atkspd; 
    public GameObject player;
    void Update()
    {
        hp.text = player.GetComponent<Health>().health.ToString();
        dmg.text = player.GetComponent<WeaponBehaviour>().damage.ToString();
        atkspd.text = player.GetComponent<WeaponBehaviour>().attackDelay.ToString();
    }
}
