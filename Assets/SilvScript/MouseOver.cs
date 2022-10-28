using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MouseOver : MonoBehaviour
{
    void Start()
    {
        //GetComponent<Renderer>().material.color = Color.yellow;
        //GetComponent<TextMeshProUGUI>().color = Color.yellow;
    }

    void OnMouseEnter()
    {
        //GetComponent<Renderer>().material.color = Color.black;
        //GetComponent<TextMeshProUGUI>().color = Color.black;
        
    }

    void OnMouseExit()
    {
        //GetComponent<Renderer>().material.color = Color.yellow;
        //GetComponent<TextMeshProUGUI>().color = Color.red;
    }
}
