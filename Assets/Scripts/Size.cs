using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Size : MonoBehaviour
{
    public float scale;
    void Awake(){
        gameObject.transform.localScale=new Vector2(scale, scale);
    }
}
