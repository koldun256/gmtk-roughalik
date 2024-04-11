using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    public GameObject content;
    public void SetValue(float val) {
        content.transform.localScale = new Vector3(val, 1, 1);
    } 
}
