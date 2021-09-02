using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
            gameObject.tag = "Hit";
        }
        
    }
}
