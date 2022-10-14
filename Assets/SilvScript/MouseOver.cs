using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseOver : MonoBehaviour
{
    void Start()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }

    void OnMouseEnter()
    {
        GetComponent<Renderer>().material.color = Color.yellow;
    }

    void OnMouseExit()
    {
        GetComponent<Renderer>().material.color = Color.black;
    }
}
