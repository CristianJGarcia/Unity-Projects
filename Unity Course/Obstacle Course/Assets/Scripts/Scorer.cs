using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scorer : MonoBehaviour
{
    private int count = 0;
    private void OnCollisionEnter(Collision other)
    {
        // If it is not tagged as hit
        if (!other.gameObject.tag.Equals("Hit"))
        {
            count += 1;
            Debug.Log("You've bumped into a " + other.gameObject.name + " this many times: " + count);
        }
        
    }
}
