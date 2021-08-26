using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // A and D
        // Multiply by Time.deltaTime to achieve frame rate independent 
        float xValue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime; 
        // W and S
        // Multiply by Time.deltaTime to achieve frame rate independent 
        float zValue = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        // Foundation concept of moving the player
        transform.Translate(xValue, 0, zValue);
    }
}
