using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        PrintInstruction();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    void PrintInstruction()
    {
        Debug.Log("Welcome to the game");
        Debug.Log("Move your player with WASD or arrow keys");
        Debug.Log("Don't hit the walls!");
    }

    void MovePlayer()
    {
        // A and D
        // Multiply by Time.deltaTime to achieve frame rate independence 
        float xValue = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        
        // W and S
        // Multiply by Time.deltaTime to achieve frame rate independence 
        float zValue = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        
        // Foundation concept of moving the player
        transform.Translate(xValue, 0, zValue);
    }
}
