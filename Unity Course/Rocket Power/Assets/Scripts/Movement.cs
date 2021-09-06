using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    
    [SerializeField] float thrust = 1;
    [SerializeField] float rotationSpeed = 1;
    
    private Rigidbody rb;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }

    void ProcessThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            // Frame rate independent   
            rb.AddRelativeForce(Vector3.up * thrust * Time.deltaTime);
            
            // if audio is not playing then play
            //if (!audioSource.isPlaying)
            //{
                //audioSource.Play();
                audioSource.mute = false;
            //}
        }
        else
        {
            // pops here
            //audioSource.Stop();
            audioSource.mute = true;
        }
    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            ApplyRotation(-rotationSpeed);
        }
    }

    private void ApplyRotation(float rotationThisFrame)
    {
        // Freezing rotation so we can manually rotate
        rb.freezeRotation = true;
        
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        
        // Unfreezing rotation so the physics system can take over
        rb.freezeRotation = false; 
    }
}
