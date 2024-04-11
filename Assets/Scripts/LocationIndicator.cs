using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LocationIndicator : MonoBehaviour
{
    public TMP_Text text;
    void Start() {
        var location = GameObject.Find("Loader").GetComponent<Loader>().location + 1;
        text.text = "location " + location;
    }
}