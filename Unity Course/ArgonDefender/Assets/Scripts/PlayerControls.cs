using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    [Header("General Setup Settings")]
    [Tooltip(("How fast ship moves up and down upon player input"))]
    [SerializeField] float angularSpeed = 20f;
    [Tooltip("How far the player can move on the X axis of the screen")]
    [SerializeField] private float xPosRange = 18f;
    [Tooltip("How far the player can move on the Y axis of the screen")]
    [SerializeField] private float yPosRange = 14f;
    
    [Header("Lasers Array")]
    [SerializeField] private GameObject[] Lasers;
    
    [Header("Rotation Tuning")]
    [SerializeField] private float pitchFactor = -2f;
    [SerializeField] private float yawFactor = 2f;
    
    [Header("Player input tuning")]
    [SerializeField] private float rollFactor = -20f;
    [SerializeField] private float nosePitchFactor = -15f;
    
    [Header("Smoothness of Rotations")]
    [SerializeField] private float rotationsFactor = 1f;

    
    
    private float horizontal, vertical;
    
    // Update is called once per frame
    void Update()
    {
        TranslatePosition();
        RotatePosition();
        FireGun();
    }

    void FireGun()
    {
        // if pushing fire button
        if (Input.GetButton("Fire1"))
        {
            ActivateLasers(true);
        }
        else
        {
            ActivateLasers(false);
        }
    }

    private void ActivateLasers(bool isActive)
    {
        // for each of the lasers turn them on
        foreach (var laser in Lasers)
        {
            var emissionModule = laser.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
    
    private void RotatePosition()
    {
        float pitchFromPositionY = transform.localPosition.y * pitchFactor;
        float pitchNose =  vertical * nosePitchFactor;
        float yawFromPositionX = transform.localPosition.x * yawFactor;
        
        // pitch nose so that we can go in the direction of down or up and come back to our resting point
        float pitch = pitchFromPositionY + pitchNose;
        float yaw = yawFromPositionX;
        float roll = horizontal * rollFactor;
        
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        
        // Smooths our rotations to look less clunky
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationsFactor);
        // transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void TranslatePosition()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        float xOffset = horizontal * Time.deltaTime * angularSpeed;
        float yOffset = vertical * Time.deltaTime * angularSpeed;

        float newXOffset = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXOffset, -xPosRange, xPosRange);

        float newYOffset = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYOffset, -yPosRange, yPosRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
