using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillation : MonoBehaviour
{
    private Vector3 startPos;
    [SerializeField] private Vector3 movementVector;
    [SerializeField] [Range(0,1)] private float movementFactor;
    [SerializeField] private float period = 2f;
    
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // compare it to 0 using Epsilon the smallest number unity can offer
        // comparing two floats can be unpredictable
        if (period <= Mathf.Epsilon)
            return;
        
        const float tau = Mathf.PI * 2; // constant value of 6.283
        float cycles = Time.time / period; // continually growing over time
        float sinWave = Mathf.Sin(cycles * tau); // going from -1 to 1

        movementFactor = (sinWave + 1f) / 2f; // recalculated to go from 0 to 1 so its cleaner
    
        Vector3 offset = movementVector * movementFactor;
        transform.position = startPos + offset;
    }
}
