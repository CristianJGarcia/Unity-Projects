using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] private float xAngle = 0;
    [SerializeField] private float yAngle = 0;
    [SerializeField] private float zAngle = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle, yAngle, zAngle);
    }
}
